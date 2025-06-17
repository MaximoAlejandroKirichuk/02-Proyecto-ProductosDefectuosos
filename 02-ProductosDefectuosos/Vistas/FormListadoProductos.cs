using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormListadoProductos : Form
    {
        public FormListadoProductos(int idioma)
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
            btnEliminar.Text = Res_español.Borrar;
            btnModificar.Text = Res_español.Modificar;
            button1.Text = Res_español.Actualizar;

            groupBox2.Text = Res_español.informacion_producto;
            label1.Text = Res_español.codigo_producto;
            label2.Text = Res_español.nombre_producto;
            label3.Text = Res_español.Costo_producto_;
            label4.Text = Res_español.Gasto_adicional;
            label5.Text = Res_español.Cantidad_de_productos_dañada_;
            label10.Text = Res_español.problema_de_entrada;
            label9.Text = Res_español.persona_responsable;

            label13.Text = Res_español.Deposito_almacenado;
            label12.Text = Res_español.Estante;
            label11.Text = Res_español.Nivel_de_estante;
            label6.Text = Res_español.Columna;

            groupBox1.Text = Res_español.Estado_del_producto;
            label15.Text = Res_español.Estado_del_producto;
            label14.Text = Res_español.Costo_de_perdida_de_materia_prima;
            label8.Text = Res_español.Costo_de_mano_de_obra;
        }
        public void gettextingles()
        {
            btnEliminar.Text = Res_ingles.Delete;
            btnModificar.Text = Res_ingles.Modify;
            button1.Text = Res_ingles.Update;

            groupBox2.Text = Res_ingles.Product_information;
            label1.Text = Res_ingles.Product_code;
            label2.Text = Res_ingles.Product_name;
            label3.Text = Res_ingles.Product_Cost_;
            label4.Text = Res_ingles.Additional_expense;
            label5.Text = Res_ingles.Damaged_Product_Quantity_;
            label10.Text = Res_ingles.Reported_Issue_;
            label9.Text = Res_ingles.Responsible_person;

            label13.Text = Res_ingles.Storage_bin;
            label12.Text = Res_ingles.Shelf;
            label11.Text = Res_ingles.Shelf_level;
            label6.Text = Res_ingles.Column;

            groupBox1.Text = Res_ingles.Product_Status_;
            label15.Text = Res_ingles.Product_Status_;
            label14.Text = Res_ingles.cost_of_raw_material_loss;
            label8.Text = Res_ingles.Labor_cost;
        }
        public void gettextportugues()
        {
            btnEliminar.Text = Res_portugues.Deletar;
            btnModificar.Text = Res_portugues.Modificar;
            button1.Text = Res_portugues.Atualizar;

            groupBox2.Text = Res_portugues.Informações_do_produto;
            label1.Text = Res_portugues.Condição_do_produto;
            label2.Text = Res_portugues.Nome_do_Produto;
            label3.Text = Res_portugues.Custo_da_mão_de_obra;
            label4.Text = Res_portugues.Adicionar;
            label5.Text = Res_portugues.Quantidade_de_Produtos_Danificados;
            label10.Text = Res_portugues.Problema_de_entrada;
            label9.Text = Res_portugues.Responsável;

            label13.Text = Res_portugues.Caixa_de_armazenamento;
            label12.Text = Res_portugues.Prateleira;
            label11.Text = Res_portugues.Nível_da_prateleira;
            label6.Text = Res_portugues.Coluna;

            groupBox1.Text = Res_portugues.Estado_do_Produto;
            label15.Text = Res_portugues.Estado_do_Produto;
            label14.Text = Res_portugues.Custo_da_perda_de_matéria_prima;
            label8.Text = Res_portugues.Custo_da_mão_de_obra;
        }


        private void FormListadoProductos_Load(object sender, EventArgs e)
        {
            actualizarLista();
            comboBoxPersonaResponsable.DataSource = ListadoEmpleados.Instancia.Empleados;
            comboBoxPersonaResponsable.DisplayMember = "NombreCompleto";
            if (ListadoEmpleados.Instancia.Empleados.Count > 0) return;
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

        private void comboBoxEstadoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuesta = comboBoxEstadoProducto.SelectedItem.ToString();

            if (respuesta == "Desechado")
            {
                numericUpDownCostoPerdidaMateriaPrima.Enabled = true;
                numericUpDownCostoManoObra.Enabled = false;
            }
            else
            {
                numericUpDownCostoManoObra.Enabled = true;
                numericUpDownCostoPerdidaMateriaPrima.Enabled = false;
            }
        }
    }
}
