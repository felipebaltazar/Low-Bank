namespace LowBank.Windows
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
            this.loadButton = new System.Windows.Forms.Button();
            this.accountTextbox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(162, 37);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(118, 25);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Carregar Saldo";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountTextbox
            // 
            this.accountTextbox.Location = new System.Drawing.Point(36, 37);
            this.accountTextbox.Name = "accountTextbox";
            this.accountTextbox.Size = new System.Drawing.Size(110, 25);
            this.accountTextbox.TabIndex = 1;
            this.accountTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accountTextbox_KeyPress);
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(36, 81);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(0, 17);
            this.amountLabel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.accountTextbox);
            this.Controls.Add(this.loadButton);
            this.Name = "Form1";
            this.Text = "Cachorro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loadButton;
        private TextBox accountTextbox;
        private Label amountLabel;
    }
}