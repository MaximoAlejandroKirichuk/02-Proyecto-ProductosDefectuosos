namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormReporteFinanciero
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
            this.dataGridViewListadoProductosDefectuosos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalProductos = new System.Windows.Forms.Label();
            this.txtCostoTotal = new System.Windows.Forms.Label();
            this.txtReacondiconables = new System.Windows.Forms.Label();
            this.txtDesechados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListadoProductosDefectuosos
            // 
            this.dataGridViewListadoProductosDefectuosos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListadoProductosDefectuosos.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewListadoProductosDefectuosos.Name = "dataGridViewListadoProductosDefectuosos";
            this.dataGridViewListadoProductosDefectuosos.Size = new System.Drawing.Size(976, 309);
            this.dataGridViewListadoProductosDefectuosos.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total producto defectuosos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Costo total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Reacondicionables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(673, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Desechados";
            // 
            // txtTotalProductos
            // 
            this.txtTotalProductos.AutoSize = true;
            this.txtTotalProductos.Location = new System.Drawing.Point(9, 369);
            this.txtTotalProductos.Name = "txtTotalProductos";
            this.txtTotalProductos.Size = new System.Drawing.Size(35, 13);
            this.txtTotalProductos.TabIndex = 12;
            this.txtTotalProductos.Text = "label5";
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.AutoSize = true;
            this.txtCostoTotal.Location = new System.Drawing.Point(219, 369);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.Size = new System.Drawing.Size(35, 13);
            this.txtCostoTotal.TabIndex = 13;
            this.txtCostoTotal.Text = "label6";
            // 
            // txtReacondiconables
            // 
            this.txtReacondiconables.AutoSize = true;
            this.txtReacondiconables.Location = new System.Drawing.Point(431, 369);
            this.txtReacondiconables.Name = "txtReacondiconables";
            this.txtReacondiconables.Size = new System.Drawing.Size(35, 13);
            this.txtReacondiconables.TabIndex = 14;
            this.txtReacondiconables.Text = "label6";
            // 
            // txtDesechados
            // 
            this.txtDesechados.AutoSize = true;
            this.txtDesechados.Location = new System.Drawing.Point(658, 369);
            this.txtDesechados.Name = "txtDesechados";
            this.txtDesechados.Size = new System.Drawing.Size(35, 13);
            this.txtDesechados.TabIndex = 15;
            this.txtDesechados.Text = "label6";
            // 
            // FormReporteFinanciero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1456, 450);
            this.Controls.Add(this.txtDesechados);
            this.Controls.Add(this.txtReacondiconables);
            this.Controls.Add(this.txtCostoTotal);
            this.Controls.Add(this.txtTotalProductos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewListadoProductosDefectuosos);
            this.Name = "FormReporteFinanciero";
            this.Text = "FormReporteFinanciero";
            this.Load += new System.EventHandler(this.FormReporteFinanciero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListadoProductosDefectuosos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtTotalProductos;
        private System.Windows.Forms.Label txtCostoTotal;
        private System.Windows.Forms.Label txtReacondiconables;
        private System.Windows.Forms.Label txtDesechados;
    }
}