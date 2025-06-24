using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _02_ProductosDefectuosos.Modelos.EstadoProducto;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormSeguimiento : Form
    {
        public FormSeguimiento(int idioma)
        {
            InitializeComponent();

            AplicarIdioma(idioma);

        }

        public void AplicarIdioma(int idiomanuevo)
        {
            if (idiomanuevo == 1)
                gettextespañol();
            else if (idiomanuevo == 2)
                gettextingles();
            else if (idiomanuevo == 3)
                gettextportugues();
        }


        public void gettextespañol()
        {
            groupBox1.Text = Res_español.Seguimiento;
            groupBox2.Text = Res_español.informacion_producto;

            btnAgregarPaso.Text = Res_español.Agregar;
            btnModificar.Text = Res_español.Modificar;
            btnBorrar.Text = Res_español.Borrar;
            label1.Text = Res_español.codigo_producto;
            label2.Text = Res_español.nombre_producto;
            label10.Text = Res_español.problema_de_entrada;
            label13.Text = Res_español.Paso_al_seguimiento; 
            label9.Text = Res_español.persona_responsable;

        }
        public void gettextingles()
        {
            groupBox1.Text = Res_ingles.Follow_up;
            groupBox2.Text = Res_ingles.Product_information;

            btnAgregarPaso.Text = Res_ingles.Add;
            btnModificar.Text = Res_ingles.Modify;
            btnBorrar.Text = Res_ingles.Delete;
            label1.Text = Res_ingles.Product_code;
            label2.Text = Res_ingles.Product_name;
            label10.Text = Res_ingles.Reported_Issue_;
            label13.Text = Res_ingles.Steps_of_Follow_up;
            label9.Text = Res_ingles.Responsible_person;
        }
        public void gettextportugues()
        {
            groupBox1.Text = Res_portugues.Acompanhamento;
            groupBox2.Text = Res_portugues.Informações_do_produto;

            btnAgregarPaso.Text = Res_portugues.Adicionar;
            btnModificar.Text = Res_portugues.Modificar;
            btnBorrar.Text = Res_portugues.Deletar;
            label1.Text = Res_portugues.Condição_do_produto;
            label2.Text = Res_portugues.Nome_do_Produto;
            label10.Text = Res_portugues.Problema_de_entrada;
            label13.Text = Res_portugues.steps_Acompanhamento;
            label9.Text = Res_portugues.Pessoa_Responsável;
        }


        private void actualizarLista()
        {
            dataGridViewListadoProductosDefectuosos.DataSource = null;
            dataGridViewListadoProductosDefectuosos.DataSource = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
        }
        private void FormSeguimiento_Load(object sender, EventArgs e)
        {
            Servicios.ServiciosProductosCSV.CargarDatosDesdeArchivo();
            actualizarLista();
        }


        
        public void CargarDatosArchivosSeguimiento(string codigoProducto)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Seguimientos.csv");
            //Servicios.ServiciosProductosCSV.GuardarSeguimientoProducto();
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
                        Seguimiento seguimiento = new Seguimiento(fecha, mensaje, responsable.Fullname, codigoProductoGuardado);
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

        private void dataGridViewListadoProductosDefectuosos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho clic en una fila valida
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewListadoProductosDefectuosos.Rows.Count)
                return;

            // Obtener el índice real de la fila seleccionada
            int indice = e.RowIndex;

            // Validación extra por seguridad
            if (indice >= 0 && indice < ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Count)
            {

                Producto p = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos[indice];
                txtCodigoProducto.Text = p.CodigoProducto;
                txtNombreProducto.Text = p.NombreProducto;
                txtPersonaResponsable.Text = p.PersonaResponsable.Fullname;
                txtAreaRespoonsable.Text = p.AreaDevolver.ToString();
                comboBoxProblemaEntrada.Text = p.ProblemaEntrada.ToString();
                comboBoxEstadoProducto.Text = p.EstadoProducto.Estado;
                CargarDatosArchivosSeguimiento(p.CodigoProducto);
            }
            else
            {
                MessageBox.Show("Índice fuera de rango o lista vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void dataGridViewSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho clic en una fila valida
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewSeguimiento.Rows.Count)
                return;

            // Obtener el índice real de la fila seleccionada
            int indice = e.RowIndex;

            // Validación extra por seguridad
            try
            {
                Seguimiento s = (Seguimiento)dataGridViewSeguimiento.Rows[e.RowIndex].DataBoundItem;

                // Mostrar detalles en controles auxiliares
                DateTime fecha = s.Fecha;
                string mensaje = s.Mensaje;
                string responsable = s.Responsable;
                listBox1.DataSource = new List<string> { s.ToString() }; ;
                dateTimePickerFecha.Value = fecha;
                txtAgregarPaso.Text = mensaje;
                
                MessageBox.Show("Se cargo correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al mostrar los datos: " + ex.Message);
            }
       
        }
        private void btnAgregarPaso_Click(object sender, EventArgs e)
        {
            //GESTOR CLASE

            {
                try
                {
                    string codigoProducto = txtCodigoProducto.Text;

                    if (string.IsNullOrEmpty(codigoProducto))
                    {
                        MessageBox.Show("Primero seleccioná un producto.");
                        return;
                    }

                    Producto producto = ListadoProductoDefectuosos.Instancia.filtarProductoId(codigoProducto);

                    Seguimiento nuevo = new Seguimiento(
                        dateTimePickerFecha.Value,
                        txtAgregarPaso.Text,
                        txtPersonaResponsable.Text,
                        codigoProducto
                    );

                    CargarSeguimientosEnProducto(producto);
                    // Agrega el paso a la lista en memoria
                    producto.Seguimiento.Add(nuevo);

                    // Guarda la lista actualizada en el CSV
                    GuardarSeguimientosDeProducto(producto.CodigoProducto, producto.Seguimiento);

                    // Refresca el DataGridView
                    CargarDatosArchivosSeguimiento(producto.CodigoProducto);

                    actualizarLista();
                    MessageBox.Show("Paso agregado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar paso: " + ex.Message);
                }
            }
        }

        public void GuardarSeguimientosDeProducto(string codigoProducto, List<Seguimiento> lista)
        {
            string pathSeguimiento = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Seguimientos.csv");

            // Leer todas las líneas existentes
            List<string> lineasExistentes = File.Exists(pathSeguimiento)
                ? File.ReadAllLines(pathSeguimiento).ToList()
                : new List<string>();

            // Filtrar las líneas que NO son del producto actual (deja todo lo demás intacto)
            var nuevasLineas = lineasExistentes
                .Where(linea => !linea.StartsWith(codigoProducto + ";") || linea.StartsWith("Codigo Producto"))
                .ToList();

            // Agregar los pasos actualizados del producto
            foreach (var paso in lista)
            {
                string nuevaLinea = $"{codigoProducto};{paso.Fecha:yyyy-MM-dd};{paso.Mensaje};{paso.Responsable}";
                nuevasLineas.Add(nuevaLinea);
            }

            // Escribir todo de nuevo
            File.WriteAllLines(pathSeguimiento, nuevasLineas);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoProducto = txtCodigoProducto.Text;
                if (string.IsNullOrEmpty(codigoProducto))
                {
                    MessageBox.Show("Seleccioná un producto.");
                    return;
                }

                Producto producto = ListadoProductoDefectuosos.Instancia.filtarProductoId(codigoProducto);
                CargarSeguimientosEnProducto(producto);
                if (dataGridViewSeguimiento.CurrentRow?.DataBoundItem is Seguimiento paso)
                {
                    paso.Fecha = dateTimePickerFecha.Value;
                    paso.Mensaje = txtAgregarPaso.Text;
                    paso.Responsable = txtPersonaResponsable.Text;

                    // Guardar cambios en archivo CSV
                    producto.Seguimiento.Add(paso);
                    GuardarSeguimientosDeProducto(codigoProducto, producto.Seguimiento);

                    // Refrescar visualmente el DataGridView
                    CargarDatosArchivosSeguimiento(codigoProducto);
                    actualizarLista();

                    MessageBox.Show("Paso modificado correctamente.");
                }
                else
                {
                    MessageBox.Show("Seleccioná un paso para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar paso: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoProducto = txtCodigoProducto.Text;

                if (string.IsNullOrEmpty(codigoProducto))
                {
                    MessageBox.Show("Seleccioná un producto.");
                    return;
                }

                Producto producto = ListadoProductoDefectuosos.Instancia.filtarProductoId(codigoProducto);
                
                CargarSeguimientosEnProducto(producto);
                int index = dataGridViewSeguimiento.CurrentRow?.Index ?? -1;

                if (index >= 0 && index < producto.Seguimiento.Count)
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este paso?", "Confirmar", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                        producto.Seguimiento.RemoveAt(index);

                        // Guardar cambios
                        GuardarSeguimientosDeProducto(codigoProducto, producto.Seguimiento);

                        // Refrescar grilla
                        CargarDatosArchivosSeguimiento(codigoProducto);
                        actualizarLista();

                        MessageBox.Show("Paso eliminado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccioná un paso válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar paso: " + ex.Message);
            }
        }
        public void CargarSeguimientosEnProducto(Producto producto)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Seguimientos.csv");

            if (!File.Exists(ruta))
                return;

            List<Seguimiento> listaSeguimientos = new List<Seguimiento>();

            using (StreamReader sr = new StreamReader(ruta))
            {
                string linea = sr.ReadLine(); // Saltar encabezado

                while ((linea = sr.ReadLine()) != null)
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length >= 4 && partes[0] == producto.CodigoProducto)
                    {
                        DateTime fecha = DateTime.Parse(partes[1]);
                        string mensaje = partes[2];
                        string responsable = partes[3];
                        Seguimiento paso = new Seguimiento(fecha, mensaje, responsable, producto.CodigoProducto);
                        listaSeguimientos.Add(paso);
                    }
                }
            }

            producto.Seguimiento = listaSeguimientos;
        }
        private void btnModificarSeguimiento_Click(object sender, EventArgs e)
        {
            string codigoProducto = txtCodigoProducto.Text;
            Producto p = ListadoProductoDefectuosos.Instancia.filtarProductoId(codigoProducto);

            //  SUSCRIPCIÓN AL EVENTO (solo si no está ya suscripto)
            p.EstadoProductoCambiado -= Producto_EstadoProductoCambiado; // para evitar suscripciones duplicadas
            p.EstadoProductoCambiado += Producto_EstadoProductoCambiado;

            string valorSeleccionado = comboBoxEstadoProducto.SelectedItem.ToString();

            if (Enum.TryParse(valorSeleccionado, out EstadoProducto.TipoEstado estadoActual))
            {
                // si ya tenés un objeto y solo cambiás el estado interno
                p.EstadoProducto.Estado = estadoActual.ToString();
                p.EstadoProducto.CostoPerdida = p.EstadoProducto.CostoPerdida;
                p.EstadoProducto.CostoManoObra = p.EstadoProducto.CostoManoObra;
                MessageBox.Show($"Estado modificado a: {p.EstadoProducto.Estado}");
            }
            else
            {
                MessageBox.Show("El estado seleccionado no es válido.");
            }
        }

        private void Producto_EstadoProductoCambiado(Producto producto, string estadoAnterior, string estadoNuevo)
        {
            MessageBox.Show($"El estado del producto {producto.CodigoProducto} cambió de {estadoAnterior} a {estadoNuevo}");
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void FormSeguimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés cerrar este formulario?", "Confirmar salida",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true; // esto cancela el cierre del formulario
            }
            if(resultado == DialogResult.Yes)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }

        
    }

}


