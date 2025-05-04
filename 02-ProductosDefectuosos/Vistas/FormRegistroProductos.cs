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
            //TODO: MEJORAR ESTO
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
                int cantidadProductoDañada = Convert.ToInt32(txtCantidadProductosDañada.Text);
                
                //Generar ubicación
                string depositoAlmacenado = comboBoxDepositoAlmacenado.SelectedItem.ToString();
                int nroEstante = Convert.ToInt32(numericUpDownEstante.Value);
                int nivelEstante = Convert.ToInt32(numericUpDownNivelEstante.Value);
                int nroColumna = Convert.ToInt32(numericUpDownColumna.Value);
                Ubicacion ubicacionProducto = new Ubicacion(depositoAlmacenado, nroEstante, nivelEstante, nroColumna);
                
                //Generar seguimiento
                List<string> seguimiento = new List<string>();
                
                //Generar estado

                //falta hacer si no es desechado
                string estado = comboBoxEstadoProducto.SelectedItem.ToString();
                int costoPerdida = Convert.ToInt32(numericUpDownCostoPerdidaMateriaPrima.Value);
                EstadoProducto estadoProducto = new EstadoProducto(costoPerdida);


                //Generar producto Defectuoso
                Producto nuevoProductoDefectuoso = new Producto(codigoProducto, nombreProducto, costoProducto, cantidadProductoDañada, personaResponsable, ubicacionProducto, seguimiento);
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
    }
}
