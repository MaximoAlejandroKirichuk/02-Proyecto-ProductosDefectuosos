using _02_ProductosDefectuosos.Modelos;
using _02_ProductosDefectuosos.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

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
            FormAyuda ventanaAyuda = new FormAyuda();
            ventanaAyuda.ShowDialog();
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

        private void MostrarDatosUbicacion(int indice)
        {
            Producto producto = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos[indice];
            dataGridViewUbicacion.DataSource = null;
            dataGridViewUbicacion.DataSource = producto.DevolverUbicacionProductos(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            actualizarLista();
            
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            if(SesionActiva.Instancia.UsuarioActivo.Rol == "Empleado")
            {
                ModificarToolStripMenuItem.Visible = false;
                reportesToolStripMenuItem.Visible = false;
            }
            Servicios.ServiciosProductosCSV.CargarDatosDesdeArchivo();
            actualizarLista();
            if (ListadoEmpleados.Instancia.Empleados.Count > 0) return;
            Servicios.ServiciosUsuariosCSV.EmpleadosActivos();
        }

        public void GetTextIngles()
        {
            registrarToolStripMenuItem.Text = Resource1.Register;
            seguimientoToolStripMenuItem.Text = Resource1.Follow_up;
            reportesToolStripMenuItem.Text = Resource1.Report;
            ModificarToolStripMenuItem.Text = Resource1.Modify_Product;
            ayudaToolStripMenuItem.Text = Resource1.Help;
            cerrarSesiónToolStripMenuItem.Text = Resource1.Log_Out;
            cambiarIdiomaToolStripMenuItem.Text = Resource1.Change_Lenguaje;


            button1.Text = Resource1.Update;
            btnGuardar.Text = Resource1.Save;

            //esto hay que ponerlo cuando el toolstrip tiene submenus.
            cambiarIdiomaToolStripMenuItem.DropDownItems[0].Text = "English";
            cambiarIdiomaToolStripMenuItem.DropDownItems[1].Text = "Español";
        }

        public void GetTextPortugues()
        {
            registrarToolStripMenuItem.Text = Resource_portugues.Registrar;
            seguimientoToolStripMenuItem.Text = Resource_portugues.Acompanhamento;
            reportesToolStripMenuItem.Text = Resource_portugues.Relatórios;
            ModificarToolStripMenuItem.Text = Resource_portugues._Modificar_produto;
            ayudaToolStripMenuItem.Text = Resource_portugues.Ajuda;
            cerrarSesiónToolStripMenuItem.Text = Resource_portugues.Sair;
            cambiarIdiomaToolStripMenuItem.Text = Resource_portugues.Alterar_idioma;

            button1.Text = Resource_portugues.Atualizar;
            btnGuardar.Text = Resource_portugues.Salvar;

            //esto hay que ponerlo cuando el toolstrip tiene submenus.
            cambiarIdiomaToolStripMenuItem.DropDownItems[0].Text = "English";
            cambiarIdiomaToolStripMenuItem.DropDownItems[1].Text = "Español";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Servicios.ServiciosProductosCSV.GuardarProducto();
            Servicios.ServiciosProductosCSV.GuardarSeguimientoProducto();
        }
       

        private void dataGridViewListadoProductosDefectuosos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho clic en una fila valida
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewListadoProductosDefectuosos.Rows.Count)
                return;

            // Obtener el índice real de la fila seleccionada
            int indice = e.RowIndex;

            // Validación extra por seguridad
            if (indice >= 0 && indice < ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Count)
            {
                MostrarDatosUbicacion(indice);
                Producto p = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos[indice]; 
                CargarDatosArchivosSeguimiento(p.CodigoProducto);
            }
            else
            {
                MessageBox.Show("Índice fuera de rango o lista vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void CargarDatosArchivosSeguimiento(string codigoProducto)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Seguimientos.csv");

            List<Seguimiento> listaSeguimientos = new List<Seguimiento>();

            using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine(); // Saltar encabezado

                while ((linea = sr.ReadLine()) != null)
                {
                    // Codigo Producto;Fecha;Mensaje;Responsable
                    string[] vLinea = linea.Split(';');
                    string codigoProductoGuardado = vLinea[0];

                    if (codigoProducto == codigoProductoGuardado)
                    {
                        DateTime fecha = Convert.ToDateTime(vLinea[1]);
                        string mensaje = vLinea[2];
                        Usuario responsable = new Empleado(vLinea[3]);
                        Seguimiento seguimiento = new Seguimiento(fecha, mensaje, responsable.Fullname);
                        listaSeguimientos.Add(seguimiento);
                    }
                }
            }

            if (listaSeguimientos.Count > 0)
            {
                dataGridViewSeguimiento.DataSource = null;
                dataGridViewSeguimiento.DataSource = listaSeguimientos;
            }
            else
            {
                MessageBox.Show("No se encontró un seguimiento para el producto: " + codigoProducto);
            }
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionActiva.Instancia.CerrarSesion();
            MessageBox.Show("Se cerro sesión");
            Close();
            Form form = new Login();
            form.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportes f = new FormReportes();
            f.ShowDialog();
        }

        private void seguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSeguimiento f = new FormSeguimiento();
            f.ShowDialog();
        }

        private void dataGridViewListadoProductosDefectuosos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cambiarIdiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTextIngles();
  

        }

        private void portugueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTextPortugues();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
