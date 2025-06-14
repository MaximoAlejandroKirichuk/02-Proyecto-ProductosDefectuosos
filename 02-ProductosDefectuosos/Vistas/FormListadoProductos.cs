using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections;
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
            comboBoxPersonaResponsable.DataSource = ListadoEmpleados.Instancia.Empleados;
            comboBoxPersonaResponsable.DisplayMember = "NombreCompleto";
            Servicios.ServiciosUsuariosCSV.EmpleadosActivos();
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
                Producto p = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos[indice];
                try
                {
                   
                    //INFORMACION PRODUCTO
                    txtCodigoProducto.Text = p.CodigoProducto;
                    txtNombreProducto.Text = p.NombreProducto;
                    numericUpDownCostoProducto.Value = p.CostoProducto;
                    numericUpDownGastoAdicional.Value = p.GastoAdicionalAntesDefecto;
                    txtCantidadDaniada.Text = p.CantidadDaniada.ToString();
                    comboBoxProblemaEntrada.Text = p.ProblemaEntrada.ToString();
                    comboBoxPersonaResponsable.Text = p.PersonaResponsable.Fullname;
                    //UBICACION
                    comboBoxDepositoAlmacenado.Text = p.UbicacionProducto.DepositoAlmacenado.ToString();
                    numericUpDownEstante.Value = p.UbicacionProducto.NumeroEstante;
                    numericUpDownNivelEstante.Value = p.UbicacionProducto.NivelEstante;
                    numericUpDownColumna.Value = p.UbicacionProducto.NumeroColumna;

                    //ESTADO
                    comboBoxEstadoProducto.Text = p.EstadoProducto.Estado;
                    numericUpDownCostoManoObra.Value = p.EstadoProducto.CostoManoObra;
                    numericUpDownCostoPerdidaMateriaPrima.Value = p.EstadoProducto.CostoPerdida;

                }
                catch (Exception )
                {
                    MessageBox.Show("Ocurrio un error al mostrar los datos del producto: " + p.NombreProducto );
                }
                
            }
            else
            {
                MessageBox.Show("Índice fuera de rango o lista vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewListadoProductosDefectuosos.SelectedRows.Count > 0)
            {
                int indice = dataGridViewListadoProductosDefectuosos.SelectedRows[0].Index;
                var p = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos[indice];
                var admin = (Administrador)SesionActiva.Instancia.UsuarioActivo;
                admin.BorrarProducto(p);
                actualizarLista();
            }
            else
            {
                MessageBox.Show("Seleccione un producto a borrar ");
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewListadoProductosDefectuosos.SelectedRows.Count > 0)
            {
                try
                {
                    // Estado
                    string estado = comboBoxEstadoProducto.SelectedItem.ToString();
                    EstadoProducto estadoProducto = null;

                    if (estado == "Desechado")
                    {
                        // podés guardar este valor si lo necesitás después
                        decimal costoPerdida = Convert.ToDecimal(numericUpDownCostoPerdidaMateriaPrima.Value);
                        estadoProducto = new EstadoProducto(costoPerdida,EstadoProducto.TipoEstado.Desechado);
                    }
                    else if (estado == "Reacondicionable")
                    {
                        decimal costoManoObra = Convert.ToDecimal(numericUpDownCostoManoObra.Value);
                        estadoProducto = new EstadoProducto(costoManoObra,EstadoProducto.TipoEstado.Reacondicionable);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error con el estado del producto.");
                        return;
                    }
                    Producto productoModificado = new Producto
                    {
                        //Informacion
                        CodigoProducto = txtCodigoProducto.Text,
                        NombreProducto = txtNombreProducto.Text,
                        CostoProducto = Convert.ToDecimal(numericUpDownCostoProducto.Value),
                        GastoAdicionalAntesDefecto = Convert.ToDecimal(numericUpDownGastoAdicional.Value),
                        CantidadDaniada = Convert.ToInt16(txtCantidadDaniada.Text),
                        ProblemaEntrada = comboBoxProblemaEntrada.Text,
                        PersonaResponsable = new Empleado(comboBoxPersonaResponsable.Text),
                        //Ubicacion
                        UbicacionProducto = new Ubicacion(
                            comboBoxDepositoAlmacenado.Text,
                            Convert.ToInt16(numericUpDownEstante.Value),
                            Convert.ToInt16(numericUpDownNivelEstante.Value),
                            Convert.ToInt16(numericUpDownColumna.Value)
                         ),
                        EstadoProducto = estadoProducto,
                        
                        
                    };

                    var admin = (Administrador)SesionActiva.Instancia.UsuarioActivo;
                    admin.ModificarProducto(productoModificado);
                    actualizarLista();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al crear el producto");
                }

            }
            else
            {
                MessageBox.Show("Seleccione un producto a borrar ");
                return;
            }
        }

        
    }
}
