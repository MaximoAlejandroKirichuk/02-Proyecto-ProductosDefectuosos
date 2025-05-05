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
        private decimal costoProducto;
        private int costoAcumuladoAntesDefecto;
        private int gastoAdicionalAntesDefecto;
        private int cantidadDañada;
        private string problemaEntrada;


        private string personaResponsable;
        private Ubicacion ubicacionProducto;
        private EstadoProducto estadoProducto;

        

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

       

        public decimal CostoProducto
        {
            get { return costoProducto; }
            set { costoProducto = value; }
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


        public string ProblemaEntrada
        {
            get { return problemaEntrada; }
            set { problemaEntrada = value; }
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

        public EstadoProducto EstadoProducto
        {
            get { return estadoProducto; }
            set { estadoProducto = value; }
        }

        public Producto(
            string codigoProducto,
            string nombreProducto,
            decimal costoProducto,
            int costoAcumuladoAntesDefecto,
            int cantidadDañada,
            string problemaEntrada,
            string personaResponsable,
            Ubicacion ubicacionProducto,
            EstadoProducto estadoProducto,
            List<string> seguimiento 
            // QUE HAGO CON ESTO
            //int gastoAdicionalAntesDefecto

            )
        {
            this.CodigoProducto = codigoProducto;
            this.NombreProducto = nombreProducto;
            this.CostoProducto = costoProducto;
            this.CostoAcumuladoAntesDefecto = costoAcumuladoAntesDefecto;
            this.CantidadDañada = cantidadDañada;
            this.ProblemaEntrada = problemaEntrada;
            this.PersonaResponsable = personaResponsable;
            this.UbicacionProducto = ubicacionProducto;
            this.EstadoProducto = estadoProducto;
            this.Seguimiento = seguimiento;
            //this.GastoAdicionalAntesDefecto = gastoAdicionalAntesDefecto;
        }
    }
}
