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
    public partial class FormRegistroProductos : Form
    {
        public FormRegistroProductos()
        {
            InitializeComponent();
        }

        private void FormRegistroProductos_Load(object sender, EventArgs e)
        {
            comboBoxPersonaResponsable.DataSource = null;
            comboBoxPersonaResponsable.DataSource = ListadoEmpleados.Instancia.Empleados;
            comboBoxPersonaResponsable.DisplayMember = "NombreCompleto";


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuesta = comboBoxEstadoProducto.SelectedItem.ToString();

            if(respuesta == "Desechado")
            {
               numericUpDownCostoPerdidaMateriaPrima.Enabled = true;
                numericUpDownCostoManoObra.Enabled = false;
            }
            else{
                numericUpDownCostoManoObra.Enabled = true;
                numericUpDownCostoPerdidaMateriaPrima.Enabled = false;
            }
        }

        

        private void btnTerminarCarga_Click(object sender, EventArgs e)
        {
            try
            {
                //Generar producto
                Usuario personaResponsable =(Usuario)comboBoxPersonaResponsable.SelectedItem;
                string codigoProducto = txtCodigoProducto.Text;
                string nombreProducto = txtNombreProducto.Text;
                decimal costoProducto = Convert.ToDecimal(txtCostoProducto.Text);
                decimal gastoGeneradoAntesDefectuoso = Convert.ToDecimal(txtGastoGenerado.Text);
                
                int cantidadProductoDañada = Convert.ToInt32(txtCantidadProductosDañada.Text);
                string problemaEntrada = comboBoxProblemaEntrada.SelectedItem.ToString();

                //Generar ubicación
                string depositoAlmacenado = comboBoxDepositoAlmacenado.SelectedItem.ToString();
                int nroEstante = Convert.ToInt32(numericUpDownEstante.Value);
                int nivelEstante = Convert.ToInt32(numericUpDownNivelEstante.Value);
                int nroColumna = Convert.ToInt32(numericUpDownColumna.Value);
                Ubicacion ubicacionProducto = new Ubicacion(depositoAlmacenado, nroEstante, nivelEstante, nroColumna);

                //Generar seguimiento

                List<Seguimiento> seguimiento = listBox1.Items.Cast<Seguimiento>().ToList();


                //Generar estado
                string estado = comboBoxEstadoProducto.SelectedItem.ToString();
                EstadoProducto estadoProducto = null; //declaro null

                if (estado == "Desechado")
                {
                    decimal costoPerdida = Convert.ToDecimal(numericUpDownCostoPerdidaMateriaPrima.Value);
                    estadoProducto = new EstadoProducto(costoPerdida,EstadoProducto.TipoEstado.Desechado);
                }
                else if(estado == "Reacondicionable")
                {
                    decimal costoManoObra = Convert.ToDecimal(numericUpDownCostoManoObra.Value);
                    estadoProducto = new EstadoProducto(costoManoObra, EstadoProducto.TipoEstado.Reacondicionable);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con el estado del producto");
                }

                //Generar producto Defectuoso
                Producto nuevoProductoDefectuoso = new Producto(codigoProducto, nombreProducto, costoProducto, gastoGeneradoAntesDefectuoso, cantidadProductoDañada, problemaEntrada, personaResponsable, ubicacionProducto, estadoProducto, seguimiento);
                MessageBox.Show("Se creo un nuevo Producto Defectuoso con exito");
               
                ListadoProductoDefectuosos.Instancia.agregarProducto(nuevoProductoDefectuoso);
                Close(); // Cierra el formulario 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al generar la carga" + ex.TargetSite);
            }
        }
        
        private void btnAgregarPaso_Click(object sender, EventArgs e)
        {
            DateTime dia = dateTimePickerFecha.Value;
            string mensaje = txtAgregarPaso.Text;
            string creadorSeguimiento = SesionActiva.Instancia.UsuarioActivo.Fullname;
            Seguimiento nuevo = new Seguimiento(dia,mensaje, creadorSeguimiento);
            
            listBox1.Items.Add(nuevo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
