namespace HASHPROGRAMM
{
    partial class EncodingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxFilePath = new TextBox();
            labelStatus = new Label();
            buttonBrowse = new Button();
            buttonEncode = new Button();
            buttonDecode = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(168, 131);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(289, 23);
            textBoxFilePath.TabIndex = 0;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(60, 61);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(38, 15);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "label1";
            labelStatus.Click += labelStatus_Click;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(60, 119);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(120, 34);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click_1;
            // 
            // buttonEncode
            // 
            buttonEncode.Location = new Point(337, 172);
            buttonEncode.Name = "buttonEncode";
            buttonEncode.Size = new Size(120, 33);
            buttonEncode.TabIndex = 3;
            buttonEncode.Text = "Кодирование";
            buttonEncode.UseVisualStyleBackColor = true;
            buttonEncode.Click += buttonEncode_Click_1;
            // 
            // buttonDecode
            // 
            buttonDecode.Location = new Point(251, 227);
            buttonDecode.Name = "buttonDecode";
            buttonDecode.Size = new Size(120, 33);
            buttonDecode.TabIndex = 4;
            buttonDecode.Text = "Декодирование";
            buttonDecode.UseVisualStyleBackColor = true;
            buttonDecode.Click += buttonDecode_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(labelStatus);
            panel1.Controls.Add(buttonBrowse);
            panel1.Location = new Point(108, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 285);
            panel1.TabIndex = 5;
            // 
            // EncodingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 421);
            Controls.Add(buttonDecode);
            Controls.Add(buttonEncode);
            Controls.Add(textBoxFilePath);
            Controls.Add(panel1);
            Name = "EncodingForm";
            Text = "EncodeF";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFilePath;
        private Label labelStatus;
        private Button buttonBrowse;
        private Button buttonEncode;
        private Button buttonDecode;
        private Panel panel1;
    }
}