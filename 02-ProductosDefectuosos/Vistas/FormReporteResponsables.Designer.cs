namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormReporteResponsables
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
            this.flowLayoutPanelFacturas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelFacturas
            // 
            this.flowLayoutPanelFacturas.AutoScroll = true;
            this.flowLayoutPanelFacturas.BackColor = System.Drawing.Color.BurlyWood;
            this.flowLayoutPanelFacturas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFacturas.Location = new System.Drawing.Point(91, 101);
            this.flowLayoutPanelFacturas.Name = "flowLayoutPanelFacturas";
            this.flowLayoutPanelFacturas.Size = new System.Drawing.Size(326, 341);
            this.flowLayoutPanelFacturas.TabIndex = 6;
            this.flowLayoutPanelFacturas.WrapContents = false;
            // 
            // FormReporteResponsables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(516, 719);
            this.Controls.Add(this.flowLayoutPanelFacturas);
            this.Name = "FormReporteResponsables";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFacturas;
    }
}