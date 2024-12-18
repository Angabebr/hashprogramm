namespace HASHPROGRAMM
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            buttonLogin = new Button();
            passBox = new TextBox();
            loginBox = new TextBox();
            label1 = new Label();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            resources.ApplyResources(buttonLogin, "buttonLogin");
            buttonLogin.Name = "buttonLogin";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // passBox
            // 
            resources.ApplyResources(passBox, "passBox");
            passBox.Name = "passBox";
            // 
            // loginBox
            // 
            resources.ApplyResources(loginBox, "loginBox");
            loginBox.Name = "loginBox";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // buttonExit
            // 
            resources.ApplyResources(buttonExit, "buttonExit");
            buttonExit.Name = "buttonExit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonExit);
            Controls.Add(label1);
            Controls.Add(loginBox);
            Controls.Add(passBox);
            Controls.Add(buttonLogin);
            Name = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogin;
        private TextBox passBox;
        private TextBox loginBox;
        private Label label1;
        private Button buttonExit;
    }
}