using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Ubicacion
    {
		private string depositoAlmacenado;
        private int numeroEstante;
        private int nivelEstante;

        public string DepositoAlmacenado
		{
			get { return depositoAlmacenado; }
			set { depositoAlmacenado = value; }
		}

	
		public int NumeroEstante
		{
			get { return numeroEstante; }
			set { numeroEstante = value; }
		}

		
		public int NivelEstante
		{
			get { return nivelEstante; }
			set { nivelEstante = value; }
		}

		private int numeroColumna;

		public int NumeroColumna
		{
			get { return numeroColumna; }
			set { numeroColumna = value; }
		}


        public Ubicacion(string nroDeposito, int nroEstante, int nivelEstante, int nroColumna)
        {
			this.DepositoAlmacenado = nroDeposito;
			this.NumeroColumna = nroColumna ;
			this.NivelEstante = nivelEstante;
			this.numeroEstante = nroEstante;
        }

        public override string ToString()
        {
            return $"{DepositoAlmacenado};{NumeroColumna};{NivelEstante};{NumeroEstante}";
        }
    }
}
