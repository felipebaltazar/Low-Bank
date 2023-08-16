namespace LowBank_Windows
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            loginButton = new CustomButton();
            pictureBox1 = new PictureBox();
            avatarImage = new PictureBox();
            cadastroButton = new CustomButton();
            cpfTextbox = new TextBox();
            passwordTextbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarImage).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(253, 201, 46);
            loginButton.FlatAppearance.BorderColor = Color.FromArgb(253, 201, 46);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            loginButton.Location = new Point(113, 330);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(120, 40);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(120, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 148);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += LoginPage_MouseDown;
            pictureBox1.MouseMove += LoginPage_MouseMove;
            pictureBox1.MouseUp += LoginPage_MouseUp;
            // 
            // avatarImage
            // 
            avatarImage.Image = (Image)resources.GetObject("avatarImage.Image");
            avatarImage.Location = new Point(218, 232);
            avatarImage.Name = "avatarImage";
            avatarImage.Size = new Size(48, 48);
            avatarImage.TabIndex = 5;
            avatarImage.TabStop = false;
            // 
            // cadastroButton
            // 
            cadastroButton.BackColor = Color.FromArgb(253, 201, 46);
            cadastroButton.FlatAppearance.BorderColor = Color.FromArgb(253, 201, 46);
            cadastroButton.FlatStyle = FlatStyle.Flat;
            cadastroButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            cadastroButton.Location = new Point(256, 330);
            cadastroButton.Name = "cadastroButton";
            cadastroButton.Size = new Size(120, 40);
            cadastroButton.TabIndex = 6;
            cadastroButton.Text = "Cadastro";
            cadastroButton.UseVisualStyleBackColor = false;
            // 
            // cpfTextbox
            // 
            cpfTextbox.Location = new Point(181, 229);
            cpfTextbox.Name = "cpfTextbox";
            cpfTextbox.PlaceholderText = "CPF";
            cpfTextbox.Size = new Size(122, 25);
            cpfTextbox.TabIndex = 7;
            cpfTextbox.Visible = false;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(181, 265);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PlaceholderText = "Password";
            passwordTextbox.Size = new Size(122, 25);
            passwordTextbox.TabIndex = 8;
            passwordTextbox.UseSystemPasswordChar = true;
            passwordTextbox.Visible = false;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(485, 437);
            Controls.Add(passwordTextbox);
            Controls.Add(cpfTextbox);
            Controls.Add(cadastroButton);
            Controls.Add(avatarImage);
            Controls.Add(pictureBox1);
            Controls.Add(loginButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPage";
            DoubleClick += LoginPage_DoubleClick;
            MouseDown += LoginPage_MouseDown;
            MouseMove += LoginPage_MouseMove;
            MouseUp += LoginPage_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox avatarImage;
        private CustomButton cadastroButton;
        private CustomButton loginButton;
        private TextBox cpfTextbox;
        private TextBox passwordTextbox;
    }
}