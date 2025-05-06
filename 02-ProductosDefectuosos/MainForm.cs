using _02_ProductosDefectuosos.Modelos;
using _02_ProductosDefectuosos.Vistas;
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

namespace _02_ProductosDefectuosos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistroProductos formRegistro = new FormRegistroProductos();
            formRegistro.ShowDialog();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoProductos formListado = new FormListadoProductos();
            formListado.ShowDialog();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void CargarDatosDesdeArchivo()
        {
            //PROBAR ESTO

            //string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\datos\productos_defectuosos.csv");

            //@"E:\facultad 2025\POO\02-ProductosDefectuosos\02-ProductosDefectuosos\bin\Debug\productos_defectuosos.csv";
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos_defectuosos.csv");

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        bool esPrimeraLinea = true;

                        while ((linea = sr.ReadLine()) != null)
                        {
                            if (esPrimeraLinea)
                            {
                                esPrimeraLinea = false; // Saltea encabezado
                                continue;
                            }

                            string[] datos = linea.Split(',');

                            if (datos.Length == 6)
                            {
                                // Validación antes de la conversión
                                if (decimal.TryParse(datos[2], out decimal costoProducto) &&
                                    decimal.TryParse(datos[3], out decimal gastoAdicional) &&
                                    int.TryParse(datos[5], out int cantidadDañada))
                                {
                                    Producto producto = new Producto
                                    {
                                        CodigoProducto = datos[0],
                                        NombreProducto = datos[1],
                                        CostoProducto = costoProducto,
                                        GastoAdicionalAntesDefecto = gastoAdicional,
                                        PersonaResponsable = datos[4],
                                        CantidadDañada = cantidadDañada
                                    };

                                    ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Add(producto);
                                }
                                else
                                {
                                    MessageBox.Show($"Datos incorrectos en la línea: {linea}", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }

                    dataGridViewListadoProductosDefectuosos.DataSource = null;
                    dataGridViewListadoProductosDefectuosos.DataSource = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
                    dataGridViewListadoProductosDefectuosos.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El archivo de productos no se encontró.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarDatosDesdeArchivo();
        }
    }
}
