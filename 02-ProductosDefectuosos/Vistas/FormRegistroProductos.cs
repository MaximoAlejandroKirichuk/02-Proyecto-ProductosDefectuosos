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
using static _02_ProductosDefectuosos.Modelos.AreaResponsable;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormRegistroProductos : Form
    {
        public FormRegistroProductos(int idioma)
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
            label1.Text = Res_español.persona_responsable;
            label2.Text = Res_español.codigo_producto;
            label3.Text = Res_español.nombre_producto;
            label4.Text = Res_español.Costo_producto_;
            label5.Text = Res_español.Gasto_generado__antes_de_ser_defectuoso__;
            label14.Text = Res_español.Cantidad_de_productos_dañada_;
            label15.Text = Res_español.Problema_por_el_que_llega_;

            tabPage1.Text = Res_español.Datos_del_Producto_;
            tabPage2.Text = Res_español.Ubicación_Geográfica;
            tabPage3.Text = Res_español.Estado_del_producto;
            tabPage4.Text = Res_español.Seguimiento;
            tabPage5.Text = Res_español.Finalizar_formulario_;

            label10.Text = Res_español.Deposito_almacenado;
            label9.Text = Res_español.Estante;
            label8.Text = Res_español.Nivel_de_estante;
            label7.Text = Res_español.Columna;

            label6.Text = Res_español.Estado_del_producto;
            label11.Text = Res_español.Costo_de_perdida_de_materia_prima;
            label12.Text = Res_español.Costo_de_mano_de_obra;
            label13.Text = Res_español.Paso_al_seguimiento;

            btnAgregarPaso.Text = Res_español.Agregar;
            btnTerminarCarga.Text = Res_español.Terminar_Carga;
        }
        public void gettextingles()
        {
            label1.Text = Res_ingles.Responsible_person;
            label2.Text = Res_ingles.Product_code;
            label3.Text = Res_ingles.Product_name;
            label4.Text = Res_ingles.Product_Cost_;
            label5.Text = Res_ingles.Cost_Incurred__before_becoming_faulty__;
            label14.Text = Res_ingles.Damaged_Product_Quantity_;
            label15.Text = Res_ingles.Input_problem;

            tabPage1.Text = Res_ingles.Product_information;
            tabPage2.Text = Res_ingles.Geographical_Location_;
            tabPage3.Text = Res_ingles.Product_Status_;
            tabPage4.Text = Res_ingles.Follow_up;
            tabPage5.Text = Res_ingles.finish_upload;

            label10.Text = Res_ingles.Storage_bin;
            label9.Text = Res_ingles.Shelf;
            label8.Text = Res_ingles.Shelf_level;
            label7.Text = Res_ingles.Column;

            label6.Text = Res_ingles.product_condition;
            label11.Text = Res_ingles.cost_of_raw_material_loss;
            label12.Text = Res_ingles.Labor_cost;
            label13.Text = Res_ingles.Steps_of_Follow_up;

            btnAgregarPaso.Text = Res_ingles.Add;
            btnTerminarCarga.Text = Res_ingles.finish_upload;
        }
        public void gettextportugues()
        {
            label1.Text = Res_portugues.Pessoa_Responsável;
            label2.Text = Res_portugues.Condição_do_produto;
            label3.Text = Res_portugues.Nome_do_Produto;
            label4.Text = Res_portugues.Custo_do_Produto;
            label5.Text = Res_portugues.Gasto_Gerado__antes_de_apresentar_defeito_;
            label14.Text = Res_portugues.Quantidade_de_Produtos_Danificados;
            label15.Text = Res_portugues.Problema_de_entrada;

            tabPage1.Text = Res_portugues.Dados_do_Produto;
            tabPage2.Text = Res_portugues.Localização_Geográfica;
            tabPage3.Text = Res_portugues.Estado_do_Produto;
            tabPage4.Text = Res_portugues.Acompanhamento;
            tabPage5.Text = Res_portugues.Finalizar_Formulário;

            label10.Text = Res_portugues.Caixa_de_armazenamento;
            label9.Text = Res_portugues.Prateleira;
            label8.Text = Res_portugues.Nível_da_prateleira;
            label7.Text = Res_portugues.Coluna;

            label6.Text = Res_portugues.Estado_do_Produto;
            label11.Text = Res_portugues.Custo_da_perda_de_matéria_prima;
            label12.Text = Res_portugues.Custo_da_mão_de_obra;
            label13.Text = Res_portugues.Adicionar_etapas_ao_rastreamento;

            btnAgregarPaso.Text = Res_portugues.Adicionar;
            btnTerminarCarga.Text = Res_portugues.Finalizar_Formulário;
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
                numericUpDownCostoManoObra.Value = 0;
            }
            else{
                numericUpDownCostoManoObra.Enabled = true;
                numericUpDownCostoPerdidaMateriaPrima.Enabled = false;
                numericUpDownCostoPerdidaMateriaPrima.Value = 0;
            }
        }


        public void ingresarDatos()
        {
            try
            {
                //Generar producto
                Usuario personaResponsable = (Usuario)comboBoxPersonaResponsable.SelectedItem;
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
                    estadoProducto = new EstadoProducto(costoPerdida, EstadoProducto.TipoEstado.Desechado);
                }
                else if (estado == "Reacondicionable")
                {
                    decimal costoManoObra = Convert.ToDecimal(numericUpDownCostoManoObra.Value);
                    estadoProducto = new EstadoProducto(costoManoObra, EstadoProducto.TipoEstado.Reacondicionable);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con el estado del producto");
                }

                //Generar el area responsable 
                AreaPosibles areaEnum;
                AreaResponsable area = null;

                if (comboBoxAreaResponsable.SelectedItem != null &&
                    Enum.TryParse(comboBoxAreaResponsable.SelectedItem.ToString(), out areaEnum))
                {
                    area = new AreaResponsable(areaEnum);
                }
                else
                {
                    MessageBox.Show("El valor seleccionado para el área responsable no es válido.");
                    return;
                }
                
                
                //Generar producto Defectuoso
                Producto nuevoProductoDefectuoso = new Producto(codigoProducto, nombreProducto, costoProducto, gastoGeneradoAntesDefectuoso, cantidadProductoDañada, problemaEntrada, personaResponsable, ubicacionProducto, estadoProducto, seguimiento, area);
                MessageBox.Show("Se creo un nuevo Producto Defectuoso con exito");

                ListadoProductoDefectuosos.Instancia.agregarProducto(nuevoProductoDefectuoso);
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al generar la carga     " + ex.Message + "   " + ex.Source );
            }
        }
        private void btnTerminarCarga_Click(object sender, EventArgs e)
        {
            ingresarDatos();
            
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

       

       
    }
}
