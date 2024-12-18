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
            // Добавляем алгоритмы в ComboBox
            comboBoxAlgorithm.Items.Add("MD5");
            comboBoxAlgorithm.Items.Add("SHA1");
            comboBoxAlgorithm.Items.Add("SHA256");
            comboBoxAlgorithm.SelectedIndex = 2; // По умолчанию SHA256

            progressBarHash.Minimum = 0;
            progressBarHash.Value = 0;

            // Подписываемся на события
            comboBoxAlgorithm.SelectedIndexChanged += (s, e) => StartHashing();
            textBoxFilePath.TextChanged += (s, e) => StartHashing();
        }

        // Обработчик для кнопки "Обзор" для выбора файла
        private static readonly string SupabaseUrl = "https://jlrtwbtgkuefoezwgwxs.supabase.co"; // Укажите ваш URL Supabase
        private static readonly string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImpscnR3YnRna3VlZm9lendnd3hzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzIyNjY3MjcsImV4cCI6MjA0Nzg0MjcyN30.wbtYB0UxYDAfPkcQrN2Yji_r7gzUYMWkZRfndRSVHVo"; // Укажите ваш API-ключ Supabase


        // Метод для запуска хеширования
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

                    MessageBox.Show($"Хеширование завершено успешно!\nАлгоритм: {algorithm}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Метод для вычисления хеша
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
        // Метод для добавления информации о хеше в файл "HASHFILESAVE.txt"
        private void SaveHashToFile(string filePath, string hash)
        {
            // Определяем путь для сохранения нового файла
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string newFilePath = Path.Combine(directory, fileNameWithoutExtension + ".txt");

            // Формируем текст для записи: имя файла, хеш и дата хеширования
            string outputText = $"Файл: {Path.GetFileName(filePath)}\n" +
                                $"Хеш: {hash}\n" +
                                $"Дата хеширования: {DateTime.Now}\n";

            try
            {
                // Записываем текст в новый файл
                File.WriteAllText(newFilePath, outputText);

                // Сообщение о том, что хеш сохранен
                labelStatus.Text = $"Хеш файла сохранен в {newFilePath}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении хеша: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для вычисления хеша файла
        private string ComputeHash(string filePath)
        {
            using (var hashAlgorithm = System.Security.Cryptography.SHA256.Create())
            {
                // Чтение файла и вычисление хеша
                byte[] fileBytes = File.ReadAllBytes(filePath);
                byte[] hashBytes = hashAlgorithm.ComputeHash(fileBytes);

                // Конвертация хеша в строку (Hex)
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonHashFile_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text;  // Путь к файлу, который нужно хешировать
            if (File.Exists(filePath))
            {
                try
                {
                    // Вычисляем хеш файла
                    string hash = ComputeHash(filePath);

                    // Сохраняем хеш в новый файл
                    SaveHashToFile(filePath, hash);

                    MessageBox.Show("Хеш успешно сохранен в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Поле hash не должно быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = await SendHashToSupabase(hashValue);

            if (success)
            {
                MessageBox.Show("Данные успешно отправлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHash.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка при отправке данных. Проверьте настройки Supabase.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
        
    