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
        private decimal costoManoObra;
        private decimal costoPerdida;


        public event Action<string, string> EstadoInternoCambiado;

        public string Estado
        {
            get { return estado; }
            set
            {
                if (estado != value)
                {
                    string anterior = estado;
                    estado = value;
                    EstadoInternoCambiado?.Invoke(anterior, estado);
                }
            }
        }



        public decimal CostoPerdida
        {
            get { return costoPerdida; }
            set { costoPerdida = value; }
        }


        public decimal CostoManoObra
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
            Desechado,
            Reacondicionado
        }

        public EstadoProducto(decimal costo, TipoEstado tipo)
        {
            switch (tipo)
            {
                case TipoEstado.Desechado:
                    Estado = "Desechado";
                    CostoPerdida = costo;
                    break;
                case TipoEstado.Reacondicionable:
                    Estado = "Reacondicionable";
                    CostoManoObra = costo;
                    break;
                case TipoEstado.Reacondicionado:
                    Estado = "Reacondicionado";
                    CostoManoObra = costo;
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
                    Estado = "Reacondicionable";
                    break;
            }
        }

        public EstadoProducto()
        {
                
        }
        public override string ToString()
        {
            switch (Estado)
            {
                case "Desechado":
                    return $"{Estado};{CostoPerdida}";

                case "Reacondicionable":
                case "Reacondicionado":
                    return $"{Estado};{CostoManoObra}";

                default:
                    return "No hay info";
            }
        }


    }
}
