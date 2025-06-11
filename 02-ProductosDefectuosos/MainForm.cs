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
        Usuario usuarioActivo = SesionActiva.Instancia.UsuarioActivo;
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
            CargarDatosDesdeArchivo();
            
            actualizarLista();
            Servicios.ServiciosCSV.EmpleadosActivos();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
            GuardarSeguimientoProducto();
        }
        private void GuardarProducto()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Productos.csv");
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            List<Producto> listaGuardar = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
            sw.WriteLine("Codigo Producto;Nombre Producto;Costo Producto;Gasto Adicional;Cantidad Dañada;Problema de entrada;Personal responsable;Deposito;Estante;Nivel;Columna;Estado Producto");

            foreach (Producto p in listaGuardar)
            {
                var ubicacion = p.UbicacionProducto;
                sw.WriteLine($"{p.CodigoProducto};{p.NombreProducto};{p.CostoProducto};{p.GastoAdicionalAntesDefecto};{p.CantidadDaniada};{p.ProblemaEntrada};{p.PersonaResponsable.Fullname};{ubicacion.DepositoAlmacenado};{ubicacion.NumeroEstante};{ubicacion.NivelEstante};{ubicacion.NumeroColumna};{p.EstadoProducto}");
            }

            sw.Close();
            fs.Close();
            MessageBox.Show("Se guardo correctamente");
        }
        private void GuardarSeguimientoProducto()
        {
            string pathSeguimiento = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Seguimientos.csv");
            List<Producto> listaGuardar = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
            using (StreamWriter swSeguimiento = new StreamWriter(pathSeguimiento))
            {
                swSeguimiento.WriteLine("Codigo Producto;Fecha;Mensaje;Responsable");
                foreach (var p in listaGuardar)
                {
                    foreach (var paso in p.Seguimiento)
                    {
                        swSeguimiento.WriteLine($"{p.CodigoProducto};{paso.Fecha:yyyy-MM-dd};{paso.Mensaje};{paso.Responsable}");
                    }
                }
            }

        }
        private void CargarDatosDesdeArchivo()
        {
            if (ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Count > 0) return;

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Productos.csv");
            using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine(); // Saltar encabezado

                while ((linea = sr.ReadLine()) != null)
                {
                    string[] vLinea = linea.Split(';');
                   
                   
                    string codigo = vLinea[0];
                    string nombreProducto = vLinea[1];
                    decimal costoProducto = Convert.ToDecimal(vLinea[2]);

                    decimal gastoAdicional = Convert.ToDecimal(vLinea[3]);
                    int cantidadDaniada = Convert.ToInt16(vLinea[4]);
                    string problemaEntrada = vLinea[5];
                    Empleado empleadoResponsable = new Empleado(vLinea[6]);
                    string deposito = vLinea[7];
                    int estante = Convert.ToInt16(vLinea[8]);
                    int nivelEstante = Convert.ToInt16(vLinea[9]);
                    int columna = Convert.ToInt16(vLinea[10]);
                    Ubicacion ubicacion = new Ubicacion(deposito, estante, nivelEstante, columna);
                    string estadoTexto = vLinea[11].Trim();
                    EstadoProducto estado = new EstadoProducto((EstadoProducto.TipoEstado)Enum.Parse(typeof(EstadoProducto.TipoEstado), estadoTexto, true));
                    List<Seguimiento> seguimiento = new List<Seguimiento>();

                    //TODO: tengo que crear el nuevo producto aca
                    Producto nuevoProducto = new Producto(codigo,nombreProducto,costoProducto, gastoAdicional, cantidadDaniada,problemaEntrada, empleadoResponsable, ubicacion, estado, seguimiento);
                    ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Add(nuevoProducto);
                }
            }
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


        private void dataGridViewUbicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionActiva.Instancia.CerrarSesion();
            MessageBox.Show("Se cerro sesión");
            Close();
            Form form = new Login();
            form.Show();
        }
    }
}
