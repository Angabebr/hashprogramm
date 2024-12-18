namespace HASHPROGRAMM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonOpenEncodingForm = new Button();
            progressBarHash = new ProgressBar();
            textBoxFilePath = new TextBox();
            label1 = new Label();
            textBoxHash = new TextBox();
            buttonBrowse = new Button();
            label2 = new Label();
            comboBoxAlgorithm = new ComboBox();
            buttonHashFile = new Button();
            labelStatus = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOpenEncodingForm
            // 
            buttonOpenEncodingForm.Location = new Point(675, 415);
            buttonOpenEncodingForm.Name = "buttonOpenEncodingForm";
            buttonOpenEncodingForm.Size = new Size(113, 23);
            buttonOpenEncodingForm.TabIndex = 6;
            buttonOpenEncodingForm.Text = "ENCODE_FORM";
            buttonOpenEncodingForm.UseVisualStyleBackColor = true;
            buttonOpenEncodingForm.Click += buttonOpenEncoding_Click;
            // 
            // progressBarHash
            // 
            progressBarHash.Location = new Point(32, 108);
            progressBarHash.Name = "progressBarHash";
            progressBarHash.Size = new Size(156, 23);
            progressBarHash.TabIndex = 1;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(32, 32);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(260, 23);
            textBoxFilePath.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "hash";
            label1.Click += label1_Click;
            // 
            // textBoxHash
            // 
            textBoxHash.Location = new Point(36, 29);
            textBoxHash.Name = "textBoxHash";
            textBoxHash.Size = new Size(246, 23);
            textBoxHash.TabIndex = 3;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(32, 61);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 7;
            buttonBrowse.Text = "browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 14);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 5;
            label2.Text = "Путь к файлу";
            // 
            // comboBoxAlgorithm
            // 
            comboBoxAlgorithm.FormattingEnabled = true;
            comboBoxAlgorithm.Location = new Point(124, 62);
            comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            comboBoxAlgorithm.Size = new Size(121, 23);
            comboBoxAlgorithm.TabIndex = 0;
            // 
            // buttonHashFile
            // 
            buttonHashFile.BackgroundImageLayout = ImageLayout.None;
            buttonHashFile.Location = new Point(36, 58);
            buttonHashFile.Name = "buttonHashFile";
            buttonHashFile.Size = new Size(75, 23);
            buttonHashFile.TabIndex = 9;
            buttonHashFile.Text = "HashToFile";
            buttonHashFile.UseVisualStyleBackColor = true;
            buttonHashFile.Click += buttonHashFile_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(36, 84);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(38, 15);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "label3";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(comboBoxAlgorithm);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonBrowse);
            panel1.Controls.Add(textBoxFilePath);
            panel1.Controls.Add(progressBarHash);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-1, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 465);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(buttonHashFile);
            panel2.Controls.Add(labelStatus);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBoxHash);
            panel2.Location = new Point(386, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(420, 462);
            panel2.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(207, 59);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "HashToDB";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 459);
            Controls.Add(buttonOpenEncodingForm);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "HashF";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonOpenEncodingForm;
        private ProgressBar progressBarHash;
        private TextBox textBoxFilePath;
        private Label label1;
        private TextBox textBoxHash;
        private Button buttonBrowse;
        private Label label2;
        private ComboBox comboBoxAlgorithm;
        private Button buttonHashFile;
        private Label labelStatus;
        private Panel panel1;
        private Panel panel2;
        private Button hashtodb;
        private Button button1;
    }
}
