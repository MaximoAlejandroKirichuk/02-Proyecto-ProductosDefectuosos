namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormListadoProductos
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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListadoProductosDefectuosos
            // 
            this.dataGridViewListadoProductosDefectuosos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListadoProductosDefectuosos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewListadoProductosDefectuosos.Name = "dataGridViewListadoProductosDefectuosos";
            this.dataGridViewListadoProductosDefectuosos.Size = new System.Drawing.Size(1297, 309);
            this.dataGridViewListadoProductosDefectuosos.TabIndex = 0;
            this.dataGridViewListadoProductosDefectuosos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListadoProductosDefectuosos_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormListadoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewListadoProductosDefectuosos);
            this.Name = "FormListadoProductos";
            this.Text = "FormListadoProductos";
            this.Load += new System.EventHandler(this.FormListadoProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListadoProductosDefectuosos;
        private System.Windows.Forms.Button button1;
    }
}