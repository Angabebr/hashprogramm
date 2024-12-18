namespace HASHPROGRAMM
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonHashFile.Click += buttonHashFile_Click;
            // ��������� ��������� � ComboBox
            comboBoxAlgorithm.Items.Add("MD5");
            comboBoxAlgorithm.Items.Add("SHA1");
            comboBoxAlgorithm.Items.Add("SHA256");
            comboBoxAlgorithm.SelectedIndex = 2; // �� ��������� SHA256

            progressBarHash.Minimum = 0;
            progressBarHash.Value = 0;

            // ������������� �� �������
            comboBoxAlgorithm.SelectedIndexChanged += (s, e) => StartHashing();
            textBoxFilePath.TextChanged += (s, e) => StartHashing();
        }

        // ���������� ��� ������ "�����" ��� ������ �����
        private static readonly string SupabaseUrl = "https://jlrtwbtgkuefoezwgwxs.supabase.co"; // ������� ��� URL Supabase
        private static readonly string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImpscnR3YnRna3VlZm9lendnd3hzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzIyNjY3MjcsImV4cCI6MjA0Nzg0MjcyN30.wbtYB0UxYDAfPkcQrN2Yji_r7gzUYMWkZRfndRSVHVo"; // ������� ��� API-���� Supabase


        // ����� ��� ������� �����������
        private void StartHashing()
        {
            string filePath = textBoxFilePath.Text;
            if (File.Exists(filePath))
            {
                try
                {
                    progressBarHash.Value = 0;
                    string algorithm = comboBoxAlgorithm.SelectedItem.ToString();
                    string hash = ComputeHash(filePath, algorithm);
                    textBoxHash.Text = hash;

                    MessageBox.Show($"����������� ��������� �������!\n��������: {algorithm}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("���� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ����� ��� ���������� ����
        private string ComputeHash(string filePath, string algorithm)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                progressBarHash.Maximum = (int)(stream.Length / 1024);

                HashAlgorithm hashAlgorithm = algorithm switch
                {
                    "MD5" => MD5.Create(),
                    "SHA1" => SHA1.Create(),
                    _ => SHA256.Create(),
                };

                byte[] buffer = new byte[8192];
                int bytesRead;
                long totalBytesRead = 0;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                    hashAlgorithm.TransformBlock(buffer, 0, bytesRead, buffer, 0);

                    if (totalBytesRead % 1024 == 0)
                    {
                        progressBarHash.Value = (int)(totalBytesRead / 1024);
                        progressBarHash.Refresh();
                    }
                }

                hashAlgorithm.TransformFinalBlock(buffer, 0, 0);
                byte[] hashBytes = hashAlgorithm.Hash;

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private void buttonOpenEncoding_Click(object sender, EventArgs e)
        {
            EncodingForm encodingForm = new EncodingForm();
            encodingForm.Show();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
            }
        }
        // ����� ��� ���������� ���������� � ���� � ���� "HASHFILESAVE.txt"
        private void SaveHashToFile(string filePath, string hash)
        {
            // ���������� ���� ��� ���������� ������ �����
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string newFilePath = Path.Combine(directory, fileNameWithoutExtension + ".txt");

            // ��������� ����� ��� ������: ��� �����, ��� � ���� �����������
            string outputText = $"����: {Path.GetFileName(filePath)}\n" +
                                $"���: {hash}\n" +
                                $"���� �����������: {DateTime.Now}\n";

            try
            {
                // ���������� ����� � ����� ����
                File.WriteAllText(newFilePath, outputText);

                // ��������� � ���, ��� ��� ��������
                labelStatus.Text = $"��� ����� �������� � {newFilePath}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ����� ��� ���������� ���� �����
        private string ComputeHash(string filePath)
        {
            using (var hashAlgorithm = System.Security.Cryptography.SHA256.Create())
            {
                // ������ ����� � ���������� ����
                byte[] fileBytes = File.ReadAllBytes(filePath);
                byte[] hashBytes = hashAlgorithm.ComputeHash(fileBytes);

                // ����������� ���� � ������ (Hex)
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonHashFile_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text;  // ���� � �����, ������� ����� ����������
            if (File.Exists(filePath))
            {
                try
                {
                    // ��������� ��� �����
                    string hash = ComputeHash(filePath);

                    // ��������� ��� � ����� ����
                    SaveHashToFile(filePath, hash);

                    MessageBox.Show("��� ������� �������� � ����.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("���� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string hashValue = textBoxHash.Text;

            if (string.IsNullOrWhiteSpace(hashValue))
            {
                MessageBox.Show("���� hash �� ������ ���� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = await SendHashToSupabase(hashValue);

            if (success)
            {
                MessageBox.Show("������ ������� ����������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHash.Clear();
            }
            else
            {
                MessageBox.Show("������ ��� �������� ������. ��������� ��������� Supabase.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task<bool> SendHashToSupabase(string hash)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apikey", SupabaseKey);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseKey}");

                    var content = new StringContent(
                        $"{{\"hash\": \"{hash}\"}}",
                        Encoding.UTF8,
                        "application/json"
                    );

                    HttpResponseMessage response = await client.PostAsync($"{SupabaseUrl}/rest/v1/file", content);
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
        
    