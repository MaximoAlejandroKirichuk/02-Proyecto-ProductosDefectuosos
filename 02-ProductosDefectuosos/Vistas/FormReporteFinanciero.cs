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
    public partial class FormReporteFinanciero : Form
    {
        public FormReporteFinanciero()
        {
            InitializeComponent();
        }
        private void actualizarLista()
        {
            dataGridViewListadoProductosDefectuosos.DataSource = null;
            dataGridViewListadoProductosDefectuosos.DataSource = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
        }
        

        private void MostrarResumen(List<Producto> productos)
        {
            int total = productos.Count;
            decimal costoTotal = productos.Sum(p => p.CostoProducto);
            int reacondicionables = productos.Count(p => p.EstadoProducto.Estado == "Reacondicionable");
            int desechados = productos.Count(p => p.EstadoProducto.Estado == "Desechado");

            // Texto con emojis
            txtTotalProductos.Text = $"📦 Total productos defectuosos: {total}";
            txtCostoTotal.Text = $"💰 Costo total: {costoTotal:C}";
            txtReacondiconables.Text = $"🔧 Reacondicionables: {reacondicionables}";
            txtDesechados.Text = $"🗑️ Desechados: {desechados}";

            // Colores condicionales
            txtDesechados.ForeColor = desechados > 3 ? Color.Red : Color.OrangeRed;
            txtReacondiconables.ForeColor = reacondicionables > 3 ? Color.Green : Color.DarkGoldenrod;

            // Estilo negrita si el costo total supera cierto umbral
            if (costoTotal > 100)
            {
                txtCostoTotal.Font = new Font(txtCostoTotal.Font, FontStyle.Bold);
                txtCostoTotal.ForeColor = Color.DarkRed;
                txtCostoTotal.Text += " ⚠️";
            }
            else
            {
                txtCostoTotal.ForeColor = Color.DarkBlue;
            }
        }

        private void FormReporteFinanciero_Load(object sender, EventArgs e)
        {
            actualizarLista();
            MostrarResumen(ListadoProductoDefectuosos.Instancia.ProductosDefectuosos);
        }
    }
}
