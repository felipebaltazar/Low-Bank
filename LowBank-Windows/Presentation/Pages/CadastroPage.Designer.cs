namespace LowBank_Windows
{
    partial class CadastroPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroPage));
            nomeTextbox = new TextBox();
            cpfTextbox = new TextBox();
            passwordTextbox = new TextBox();
            cadastroButton = new CustomButton();
            pictureBox1 = new PictureBox();
            passwordConfirmTextbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // nomeTextbox
            // 
            nomeTextbox.Location = new Point(172, 147);
            nomeTextbox.Name = "nomeTextbox";
            nomeTextbox.PlaceholderText = "Nome";
            nomeTextbox.Size = new Size(122, 25);
            nomeTextbox.TabIndex = 0;
            // 
            // cpfTextbox
            // 
            cpfTextbox.Location = new Point(172, 193);
            cpfTextbox.Name = "cpfTextbox";
            cpfTextbox.PlaceholderText = "CPF";
            cpfTextbox.Size = new Size(122, 25);
            cpfTextbox.TabIndex = 1;
            cpfTextbox.TextChanged += cpfTextbox_TextChanged;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(172, 235);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PlaceholderText = "Password";
            passwordTextbox.Size = new Size(122, 25);
            passwordTextbox.TabIndex = 2;
            // 
            // cadastroButton
            // 
            cadastroButton.BackColor = Color.FromArgb(253, 201, 46);
            cadastroButton.FlatStyle = FlatStyle.Flat;
            cadastroButton.Location = new Point(172, 327);
            cadastroButton.Name = "cadastroButton";
            cadastroButton.Size = new Size(120, 40);
            cadastroButton.TabIndex = 3;
            cadastroButton.Text = "Cadastrar";
            cadastroButton.UseVisualStyleBackColor = false;
            cadastroButton.Click += cadastroButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(189, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 92);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // passwordConfirmTextbox
            // 
            passwordConfirmTextbox.Location = new Point(172, 281);
            passwordConfirmTextbox.Name = "passwordConfirmTextbox";
            passwordConfirmTextbox.PlaceholderText = "Password confirmation";
            passwordConfirmTextbox.Size = new Size(122, 25);
            passwordConfirmTextbox.TabIndex = 5;
            // 
            // CadastroPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(469, 396);
            Controls.Add(passwordConfirmTextbox);
            Controls.Add(pictureBox1);
            Controls.Add(cadastroButton);
            Controls.Add(passwordTextbox);
            Controls.Add(cpfTextbox);
            Controls.Add(nomeTextbox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CadastroPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastroPage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nomeTextbox;
        private TextBox cpfTextbox;
        private TextBox passwordTextbox;
        private CustomButton cadastroButton;
        private PictureBox pictureBox1;
        private TextBox passwordConfirmTextbox;
    }
}