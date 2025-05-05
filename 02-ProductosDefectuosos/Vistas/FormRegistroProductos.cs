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
    public partial class FormRegistroProductos : Form
    {
        //Uso el singleton para acceder a la lista de productos defectuosos
        ListadoProductoDefectuosos ListaProductos = ListadoProductoDefectuosos.Instancia;

        public FormRegistroProductos()
        {
            InitializeComponent();
        }

        private void FormRegistroProductos_Load(object sender, EventArgs e)
        {
            
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
                string personaResponsable = txtPersonaResponsable.Text;
                string codigoProducto = txtCodigoProducto.Text;
                string nombreProducto = txtNombreProducto.Text;
                decimal costoProducto = Convert.ToDecimal(txtCostoProducto.Text);
                int gastoGeneradoAntesDefectuoso = Convert.ToInt32(txtGastoGenerado.Text);
                int cantidadProductoDañada = Convert.ToInt32(txtCantidadProductosDañada.Text);
                string problemaEntrada = comboBoxProblemaEntrada.SelectedItem.ToString();

                //Generar ubicación
                string depositoAlmacenado = comboBoxDepositoAlmacenado.SelectedItem.ToString();
                int nroEstante = Convert.ToInt32(numericUpDownEstante.Value);
                int nivelEstante = Convert.ToInt32(numericUpDownNivelEstante.Value);
                int nroColumna = Convert.ToInt32(numericUpDownColumna.Value);
                Ubicacion ubicacionProducto = new Ubicacion(depositoAlmacenado, nroEstante, nivelEstante, nroColumna);
                
                //Generar seguimiento
                List<string> seguimiento = new List<string>();
                
                //Generar estado
                string estado = comboBoxEstadoProducto.SelectedItem.ToString();
                EstadoProducto estadoProducto = null; //declaro null

                if (estado == "Desechado")
                {
                    int costoPerdida = Convert.ToInt32(numericUpDownCostoPerdidaMateriaPrima.Value);
                    estadoProducto = new EstadoProducto(costoPerdida,EstadoProducto.TipoCosto.Perdida );
                }
                else if(estado == "Reacondicionable")
                {
                    int costoManoObra = Convert.ToInt32(numericUpDownCostoManoObra.Value);
                    estadoProducto = new EstadoProducto(costoManoObra,EstadoProducto.TipoCosto.ManoObra);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con el estado del producto");
                }

                //Generar producto Defectuoso
                Producto nuevoProductoDefectuoso = new Producto(codigoProducto, nombreProducto, costoProducto, gastoGeneradoAntesDefectuoso, cantidadProductoDañada, problemaEntrada, personaResponsable, ubicacionProducto, estadoProducto, seguimiento);
                MessageBox.Show("Se creo un nuevo Producto Defectuoso con exito");
               
                ListaProductos.agregarProducto(nuevoProductoDefectuoso);
                Close(); // Cierra el formulario 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al generar la carga" + ex.TargetSite);
            }
        }

        private void btnAgregarPaso_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtAgregarPaso.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
