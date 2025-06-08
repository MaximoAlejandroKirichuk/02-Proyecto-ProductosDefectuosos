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
        private decimal costoAcumuladoAntesDefecto;
        private decimal gastoAdicionalAntesDefecto;
        private int cantidadDaniada;
        private string problemaEntrada;


        private Usuario personaResponsable;
        private Ubicacion ubicacionProducto;
        private EstadoProducto estadoProducto;

        

        //Es una lista del tipo string => se anota cada paso del producto
        public List<Seguimiento> Seguimiento { get; set; } = new List<Seguimiento>();
        
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



        //Gasto adicional antes del defecto
        public decimal GastoAdicionalAntesDefecto
        {
            get { return gastoAdicionalAntesDefecto; }
            set { gastoAdicionalAntesDefecto = value; }
        }


        public int CantidadDaniada
        {
            get { return cantidadDaniada; }
            set { cantidadDaniada = value; }
        }


        public string ProblemaEntrada
        {
            get { return problemaEntrada; }
            set { problemaEntrada = value; }
        }
        public Usuario PersonaResponsable
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
            decimal gastoAdicionalAntesDefecto,
            int cantidadDaniada,
            string problemaEntrada,
            Usuario personaResponsable,
            Ubicacion ubicacionProducto,
            EstadoProducto estadoProducto,
            // QUE HAGO CON ESTO
            List<Seguimiento> seguimiento
            )
        {
            this.CodigoProducto = codigoProducto;
            this.NombreProducto = nombreProducto;
            this.CostoProducto = costoProducto;
            this.CantidadDaniada = cantidadDaniada;
            this.ProblemaEntrada = problemaEntrada;
            this.PersonaResponsable = personaResponsable;
            this.UbicacionProducto = ubicacionProducto;
            this.EstadoProducto = estadoProducto;
            this.Seguimiento = seguimiento;
            this.GastoAdicionalAntesDefecto = gastoAdicionalAntesDefecto;
        }

    

        public override string ToString()
        {
            return $"{CodigoProducto};{NombreProducto};{CostoProducto};{GastoAdicionalAntesDefecto};{CantidadDaniada};{ProblemaEntrada};{PersonaResponsable.Fullname}";
        }
        public List<Ubicacion> DevolverUbicacionProductos()
        {
            return new List<Ubicacion> { this.UbicacionProducto };
        }

    }
}
