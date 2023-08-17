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
            nomeTextbox.Location = new Point(206, 151);
            nomeTextbox.Name = "nomeTextbox";
            nomeTextbox.PlaceholderText = "Nome";
            nomeTextbox.Size = new Size(110, 25);
            nomeTextbox.TabIndex = 0;
            // 
            // cpfTextbox
            // 
            cpfTextbox.Location = new Point(206, 199);
            cpfTextbox.Name = "cpfTextbox";
            cpfTextbox.PlaceholderText = "CPF";
            cpfTextbox.Size = new Size(110, 25);
            cpfTextbox.TabIndex = 1;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(206, 245);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PlaceholderText = "Password";
            passwordTextbox.Size = new Size(110, 25);
            passwordTextbox.TabIndex = 2;
            // 
            // cadastroButton
            // 
            cadastroButton.Location = new Point(206, 354);
            cadastroButton.Name = "cadastroButton";
            cadastroButton.Size = new Size(120, 40);
            cadastroButton.TabIndex = 3;
            cadastroButton.Text = "Cadastrar";
            cadastroButton.UseVisualStyleBackColor = true;
            cadastroButton.Click += cadastroButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(224, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 92);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // passwordConfirmTextbox
            // 
            passwordConfirmTextbox.Location = new Point(206, 286);
            passwordConfirmTextbox.Name = "passwordConfirmTextbox";
            passwordConfirmTextbox.PlaceholderText = "Password confirmation";
            passwordConfirmTextbox.Size = new Size(110, 25);
            passwordConfirmTextbox.TabIndex = 5;
            // 
            // CadastroPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 503);
            Controls.Add(passwordConfirmTextbox);
            Controls.Add(pictureBox1);
            Controls.Add(cadastroButton);
            Controls.Add(passwordTextbox);
            Controls.Add(cpfTextbox);
            Controls.Add(nomeTextbox);
            Name = "CadastroPage";
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