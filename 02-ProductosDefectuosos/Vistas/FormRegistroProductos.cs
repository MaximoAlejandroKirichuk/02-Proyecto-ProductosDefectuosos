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
            string respuesta = comboBox2.SelectedItem.ToString();

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

       
    }
}
