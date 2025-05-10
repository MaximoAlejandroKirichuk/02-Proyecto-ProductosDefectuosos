namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormAyuda
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

            this.richTextBoxAyuda = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
           
            this.richTextBoxAyuda.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBoxAyuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAyuda.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAyuda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTextBoxAyuda.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxAyuda.Name = "richTextBoxAyuda";
            this.richTextBoxAyuda.ReadOnly = true;
            this.richTextBoxAyuda.Size = new System.Drawing.Size(800, 450);
            this.richTextBoxAyuda.TabIndex = 0;
            this.richTextBoxAyuda.Text = "";
            this.richTextBoxAyuda.TextChanged += new System.EventHandler(this.richTextBoxAyuda_TextChanged);

            this.SuspendLayout();
          
            // 
            // FormAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.richTextBoxAyuda);
            this.Name = "FormAyuda";
            this.Text = "FormAyuda";
            this.Load += new System.EventHandler(this.FormAyuda_Load);

            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxAyuda;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;

    }
}