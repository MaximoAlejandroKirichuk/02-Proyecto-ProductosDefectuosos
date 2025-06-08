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

        public enum TipoCosto
        {
            Perdida,
            ManoObra
        }
        public enum TipoEstado
        {
            Reacondicionable,
            Desechado
        }

        public EstadoProducto(int costo, TipoCosto tipo)
        {
            switch (tipo)
            {
                case TipoCosto.Perdida:
                    this.CostoPerdida = costo;
                    Estado = "Desechado";
                    break;
                case TipoCosto.ManoObra:
                    this.CostoManoObra = costo;
                    Estado = "ManoObra";
                    break;
            }
        }
        public EstadoProducto(TipoEstado tipo)
        {
            switch (tipo)
            {
                case TipoEstado.Desechado:
                    Estado = "Desechado";
                    break;
                case TipoEstado.Reacondicionable:
                    Estado = "Reparado";
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Estado}";
        }


    }
}
