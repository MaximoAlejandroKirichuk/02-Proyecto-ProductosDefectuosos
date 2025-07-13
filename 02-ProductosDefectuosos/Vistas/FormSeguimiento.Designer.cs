namespace _02_ProductosDefectuosos.Vistas
{
    partial class FormSeguimiento
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
            this.dataGridViewSeguimiento = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModificarEstado = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAreaRespoonsable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEstadoProducto = new System.Windows.Forms.ComboBox();
            this.comboBoxProblemaEntrada = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPersonaResponsable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.txtAgregarPaso = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAgregarPaso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimiento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListadoProductosDefectuosos
            // 
            this.dataGridViewListadoProductosDefectuosos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListadoProductosDefectuosos.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewListadoProductosDefectuosos.Name = "dataGridViewListadoProductosDefectuosos";
            this.dataGridViewListadoProductosDefectuosos.Size = new System.Drawing.Size(713, 309);
            this.dataGridViewListadoProductosDefectuosos.TabIndex = 2;
            this.dataGridViewListadoProductosDefectuosos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListadoProductosDefectuosos_CellClick_1);
            // 
            // dataGridViewSeguimiento
            // 
            this.dataGridViewSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeguimiento.Location = new System.Drawing.Point(762, 12);
            this.dataGridViewSeguimiento.Name = "dataGridViewSeguimiento";
            this.dataGridViewSeguimiento.Size = new System.Drawing.Size(573, 309);
            this.dataGridViewSeguimiento.TabIndex = 10;
            this.dataGridViewSeguimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeguimiento_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificarEstado);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.dateTimePickerFecha);
            this.groupBox1.Controls.Add(this.txtAgregarPaso);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnAgregarPaso);
            this.groupBox1.Location = new System.Drawing.Point(12, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1340, 396);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seguimiento ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnModificarEstado
            // 
            this.btnModificarEstado.Location = new System.Drawing.Point(403, 345);
            this.btnModificarEstado.Name = "btnModificarEstado";
            this.btnModificarEstado.Size = new System.Drawing.Size(237, 30);
            this.btnModificarEstado.TabIndex = 37;
            this.btnModificarEstado.Text = "Modificar Estado";
            this.btnModificarEstado.UseVisualStyleBackColor = true;
            this.btnModificarEstado.Click += new System.EventHandler(this.btnModificarSeguimiento_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAreaRespoonsable);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxEstadoProducto);
            this.groupBox2.Controls.Add(this.comboBoxProblemaEntrada);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtPersonaResponsable);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCodigoProducto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNombreProducto);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(720, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 163);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Producto";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Area responsable";
            // 
            // txtAreaRespoonsable
            // 
            this.txtAreaRespoonsable.Enabled = false;
            this.txtAreaRespoonsable.Location = new System.Drawing.Point(376, 111);
            this.txtAreaRespoonsable.Name = "txtAreaRespoonsable";
            this.txtAreaRespoonsable.Size = new System.Drawing.Size(136, 20);
            this.txtAreaRespoonsable.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Estado del producto";
            // 
            // comboBoxEstadoProducto
            // 
            this.comboBoxEstadoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstadoProducto.FormattingEnabled = true;
            this.comboBoxEstadoProducto.Items.AddRange(new object[] {
            "Reacondicionable",
            "Desechado",
            "Reacondicionado"});
            this.comboBoxEstadoProducto.Location = new System.Drawing.Point(376, 47);
            this.comboBoxEstadoProducto.Name = "comboBoxEstadoProducto";
            this.comboBoxEstadoProducto.Size = new System.Drawing.Size(161, 28);
            this.comboBoxEstadoProducto.TabIndex = 37;
            // 
            // comboBoxProblemaEntrada
            // 
            this.comboBoxProblemaEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProblemaEntrada.Enabled = false;
            this.comboBoxProblemaEntrada.FormattingEnabled = true;
            this.comboBoxProblemaEntrada.Items.AddRange(new object[] {
            "Manufactura",
            "Deteriodo de almacen",
            "Accidente de tránsito"});
            this.comboBoxProblemaEntrada.Location = new System.Drawing.Point(186, 52);
            this.comboBoxProblemaEntrada.Name = "comboBoxProblemaEntrada";
            this.comboBoxProblemaEntrada.Size = new System.Drawing.Size(147, 21);
            this.comboBoxProblemaEntrada.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Problema de Entrada";
            // 
            // txtPersonaResponsable
            // 
            this.txtPersonaResponsable.Location = new System.Drawing.Point(186, 111);
            this.txtPersonaResponsable.Name = "txtPersonaResponsable";
            this.txtPersonaResponsable.Size = new System.Drawing.Size(142, 20);
            this.txtPersonaResponsable.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codigo Producto";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(9, 52);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(136, 20);
            this.txtCodigoProducto.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre Producto";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Enabled = false;
            this.txtNombreProducto.Location = new System.Drawing.Point(9, 111);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(136, 20);
            this.txtNombreProducto.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(199, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Persona Responsable";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(484, 309);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(565, 309);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 30);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Gray;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(10, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1313, 184);
            this.listBox1.TabIndex = 9;
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Location = new System.Drawing.Point(10, 336);
            this.dateTimePickerFecha.MaxDate = new System.DateTime(2040, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFecha.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(296, 20);
            this.dateTimePickerFecha.TabIndex = 10;
            // 
            // txtAgregarPaso
            // 
            this.txtAgregarPaso.BackColor = System.Drawing.Color.Gray;
            this.txtAgregarPaso.Location = new System.Drawing.Point(10, 239);
            this.txtAgregarPaso.Multiline = true;
            this.txtAgregarPaso.Name = "txtAgregarPaso";
            this.txtAgregarPaso.Size = new System.Drawing.Size(583, 64);
            this.txtAgregarPaso.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(180, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Paso al seguiemiento";
            // 
            // btnAgregarPaso
            // 
            this.btnAgregarPaso.Location = new System.Drawing.Point(403, 309);
            this.btnAgregarPaso.Name = "btnAgregarPaso";
            this.btnAgregarPaso.Size = new System.Drawing.Size(75, 30);
            this.btnAgregarPaso.TabIndex = 8;
            this.btnAgregarPaso.Text = "Agregar";
            this.btnAgregarPaso.UseVisualStyleBackColor = true;
            this.btnAgregarPaso.Click += new System.EventHandler(this.btnAgregarPaso_Click);
            // 
            // FormSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1363, 749);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewSeguimiento);
            this.Controls.Add(this.dataGridViewListadoProductosDefectuosos);
            this.Name = "FormSeguimiento";
            this.Text = "FormSeguimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSeguimiento_FormClosing);
            this.Load += new System.EventHandler(this.FormSeguimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListadoProductosDefectuosos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimiento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListadoProductosDefectuosos;
        private System.Windows.Forms.DataGridView dataGridViewSeguimiento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.TextBox txtAgregarPaso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAgregarPaso;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtPersonaResponsable;
        private System.Windows.Forms.ComboBox comboBoxProblemaEntrada;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxEstadoProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAreaRespoonsable;
        private System.Windows.Forms.Button btnModificarEstado;
    }
}