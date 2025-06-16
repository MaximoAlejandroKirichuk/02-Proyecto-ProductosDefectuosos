namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormReportesUbicacion
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
            this.flowLayoutPanelUbicaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelUbicaciones
            // 
            this.flowLayoutPanelUbicaciones.AutoScroll = true;
            this.flowLayoutPanelUbicaciones.BackColor = System.Drawing.Color.BurlyWood;
            this.flowLayoutPanelUbicaciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelUbicaciones.Location = new System.Drawing.Point(237, 55);
            this.flowLayoutPanelUbicaciones.Name = "flowLayoutPanelUbicaciones";
            this.flowLayoutPanelUbicaciones.Size = new System.Drawing.Size(326, 341);
            this.flowLayoutPanelUbicaciones.TabIndex = 7;
            this.flowLayoutPanelUbicaciones.WrapContents = false;
            // 
            // FormReportesUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelUbicaciones);
            this.Name = "FormReportesUbicacion";
            this.Text = "FormReportesUbicacion";
            this.Load += new System.EventHandler(this.FormReportesUbicacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUbicaciones;
    }
}