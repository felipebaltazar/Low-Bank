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
            this.SuspendLayout();
            // 
            // accountTextbox
            // 
            this.accountTextbox.Location = new System.Drawing.Point(65, 57);
            this.accountTextbox.Name = "accountTextbox";
            this.accountTextbox.Size = new System.Drawing.Size(110, 25);
            this.accountTextbox.TabIndex = 0;
            this.accountTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountTextbox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(196, 57);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(129, 25);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Mostrar Saldo";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Home
            // 
            this.ClientSize = new System.Drawing.Size(1076, 597);
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
    }
}