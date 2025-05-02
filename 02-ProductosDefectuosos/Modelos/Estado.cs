using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class EstadoProducto
    {
        private string estado;
        private int costoManoObra;
        private int costoPerdida;
        public string Estado

        {
            get { return estado; }
            set { estado = value; }
        }


        public int CostoPerdida
        {
            get { return costoPerdida; }
            set { costoPerdida = value; }
        }


        public int CostoManoObra
        {
            get { return costoManoObra; }
            set { costoManoObra = value; }
        }



    }
}
