using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormReporteResponsables : Form
    {
        public FormReporteResponsables()
        {
            InitializeComponent();
        }
        
        private void FormReportes_Load(object sender, EventArgs e)
        {
            MostrarFacturasPorResponsable(ListadoProductoDefectuosos.Instancia.ProductosDefectuosos);
        }

        private void MostrarFacturasPorResponsable(List<Producto> productos)
        {
            flowLayoutPanelFacturas.Controls.Clear();

            var reportes = GenerarReportePorResponsable(productos);

            foreach (var r in reportes)
            {
                GroupBox gb = new GroupBox();
                gb.Text = r.Responsable;
                gb.Width = 300;
                gb.Height = 200;

                var lblProductos = new Label()
                {
                    Text = $"📦 Productos defectuosos: {r.CantidadProductos}",
                    AutoSize = true,
                    Top = 20,
                    Left = 10
                };

                var lblCosto = new Label()
                {
                    Text = $"💸 Costo total: {r.CostoTotal:C}",
                    AutoSize = true,
                    Top = 40,
                    Left = 10
                };

                var lblCantidad = new Label()
                {
                    Text = $"❗ Cantidad dañada: {r.CantidadDañadaTotal}",
                    AutoSize = true,
                    Top = 60,
                    Left = 10
                };

                var lblReac = new Label()
                {
                    Text = $"🔧 Reacondicionables: {r.Reacondicionables}",
                    AutoSize = true,
                    Top = 80,
                    Left = 10,
                    ForeColor = r.Reacondicionables > 2 ? Color.Green : Color.DarkGoldenrod
                };

                var lblDes = new Label()
                {
                    Text = $"🗑️ Desechados: {r.Desechados}",
                    AutoSize = true,
                    Top = 100,
                    Left = 10
                };

                // Cambia color y estilo si hay muchos productos desechados
                if (r.Desechados >= 3)
                {
                    lblDes.ForeColor = Color.Red;
                    lblDes.Font = new Font(lblDes.Font, FontStyle.Bold);
                    lblDes.Text += " ⚠️";
                }
                else
                {
                    lblDes.ForeColor = Color.OrangeRed;
                }

                gb.Controls.Add(lblProductos);
                gb.Controls.Add(lblCosto);
                gb.Controls.Add(lblCantidad);
                gb.Controls.Add(lblReac);
                gb.Controls.Add(lblDes);

                flowLayoutPanelFacturas.Controls.Add(gb);
            }
        }

        private List<ReporteResponsable> GenerarReportePorResponsable(List<Producto> productos)
        {
            var reporte = productos
                .GroupBy(p => p.PersonaResponsable.Fullname)
                .Select(g => new ReporteResponsable
                {
                    Responsable = g.Key,
                    CantidadProductos = g.Count(),
                    CostoTotal = g.Sum(p => p.CostoProducto),
                    CantidadDañadaTotal = g.Sum(p => p.CantidadDaniada),
                    Reacondicionables = g.Count(p => p.EstadoProducto.Estado == "Reacondicionable"),
                    Desechados = g.Count(p => p.EstadoProducto.Estado == "Desechado")
                }).ToList();

            return reporte;
        }
    }

}
