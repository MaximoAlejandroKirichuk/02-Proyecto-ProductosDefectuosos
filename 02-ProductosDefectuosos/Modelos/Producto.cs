using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Producto
    {
		private string codigoProducto;
		private string nombreProducto;
        private int costoAcumuladoAntesDefecto;
        private int gastoAdicionalAntesDefecto;
        private string personaResponsable;
        private int cantidadDañada;
        private Ubicacion ubicacionProducto;

        //Es una lista del tipo string => se anota cada paso del producto
        public List<string> Seguimiento { get; set; } = new List<string>();

        public string CodigoProducto
		{
			get { return codigoProducto; }
			set { codigoProducto = value; }
		}


		public string NombreProducto
		{
			get { return nombreProducto; }
			set { nombreProducto = value; }
		}

        // Costo acumulado hasta el defecto
		public int CostoAcumuladoAntesDefecto
        {
			get { return costoAcumuladoAntesDefecto; }
			set { costoAcumuladoAntesDefecto = value; }
		}

        //Gasto adicional antes del defecto
        public int GastoAdicionalAntesDefecto
		{
			get { return gastoAdicionalAntesDefecto; }
			set { gastoAdicionalAntesDefecto = value; }
		}


		public int CantidadDañada
		{
			get { return cantidadDañada; }
			set { cantidadDañada = value; }
		}

		
		public string PersonaResponsable
		{
			get { return personaResponsable; }
			set { personaResponsable = value; }
		}

		

		public Ubicacion UbicacionProducto
		{
			get { return ubicacionProducto; }
			set { ubicacionProducto = value; }
		}


	}
}
