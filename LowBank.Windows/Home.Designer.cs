namespace LowBank.Windows
{
    partial class Home
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
            this.accountTextbox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.amountLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountTextbox
            // 
            this.accountTextbox.Location = new System.Drawing.Point(15, 63);
            this.accountTextbox.Name = "accountTextbox";
            this.accountTextbox.PlaceholderText = "Numero de conta";
            this.accountTextbox.Size = new System.Drawing.Size(110, 25);
            this.accountTextbox.TabIndex = 0;
            this.accountTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountTextbox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(131, 63);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(101, 25);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Mostrar Saldo";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(15, 91);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(138, 17);
            this.amountLabel.TabIndex = 2;
            this.amountLabel.Text = "Valor em conta: 21323";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(15, 9);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(160, 51);
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "Bem vindo: Teste\nEmail: Teste@teste.com.br\nCPF: 4891845465";
            // 
            // Home
            // 
            this.ClientSize = new System.Drawing.Size(1076, 597);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.accountTextbox);
            this.Name = "Home";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountTextbox_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox accountTextbox;
        private Button searchButton;
        private Label amountLabel;
        private Label userLabel;
    }
}