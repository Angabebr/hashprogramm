using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASHPROGRAMM
{
    public partial class EncodingForm : Form
    {
        public EncodingForm()
        {
            InitializeComponent();
        }

        private string EncodeFileToBase64(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes);
        }

        private void DecodeFileFromBase64(string encodedFilePath, string outputFilePath)
        {
            // Чтение закодированного контента из файла
            string encodedContent = File.ReadAllText(encodedFilePath);
            // Декодирование содержимого из Base64
            byte[] decodedBytes = Convert.FromBase64String(encodedContent);
            // Сохранение декодированного файла
            File.WriteAllBytes(outputFilePath, decodedBytes);
        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void buttonEncode_Click_1(object sender, EventArgs e)
        {

            string filePath = textBoxFilePath.Text;
            if (File.Exists(filePath))
            {
                try
                {
                    // Кодируем файл в Base64
                    string encodedContent = EncodeFileToBase64(filePath);
                    // Сохраняем закодированный контент в файл с расширением .b64
                    string encodedFilePath = filePath + ".b64";
                    File.WriteAllText(encodedFilePath, encodedContent);
                    labelStatus.Text = $"Файл закодирован: {encodedFilePath}";
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

        private void buttonDecode_Click_1(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text; // Путь к закодированному файлу
            if (File.Exists(filePath))
            {
                try
                {
                    // Определяем путь для декодированного файла
                    string decodedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));

                    // Декодируем файл
                    DecodeFileFromBase64(filePath, decodedFilePath);
                    labelStatus.Text = $"Файл декодирован: {decodedFilePath}";

                    // Удаление исходного .b64 файла после успешного декодирования
                    File.Delete(filePath);
                    MessageBox.Show("Файл успешно декодирован и исходный .b64 файл удалён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
