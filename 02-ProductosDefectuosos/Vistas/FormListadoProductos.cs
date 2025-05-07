using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormListadoProductos : Form
    {
        public FormListadoProductos()
        {
            InitializeComponent();
        }

        private void FormListadoProductos_Load(object sender, EventArgs e)
        {
            actualizarLista();
        }

        private void actualizarLista()
        {
            dataGridViewListadoProductosDefectuosos.DataSource = null;
            dataGridViewListadoProductosDefectuosos.DataSource = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarLista();
        }

        private void dataGridViewListadoProductosDefectuosos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
