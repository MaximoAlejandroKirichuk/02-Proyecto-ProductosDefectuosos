using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Producto: ICloneable, IComparable<Producto>
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
        public AreaResponsable AreaDevolver { get; set; }


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

        public delegate void EstadoProductoCambiadoHandler(Producto producto, string estadoAnterior, string estadoNuevo);
        public event EstadoProductoCambiadoHandler EstadoProductoCambiado;

        public EstadoProducto EstadoProducto
        {
            get { return estadoProducto; }
            set
            {
                if (estadoProducto != null)
                {
                    estadoProducto.EstadoInternoCambiado -= ManejarCambioInterno;
                }

                if (estadoProducto == null || estadoProducto.Estado != value.Estado)
                {
                    string anterior = estadoProducto?.Estado;
                    estadoProducto = value;

                    estadoProducto.EstadoInternoCambiado += ManejarCambioInterno;

                    EstadoProductoCambiado?.Invoke(this, anterior, estadoProducto.Estado);
                }
                else
                {
                    estadoProducto = value;
                    estadoProducto.EstadoInternoCambiado += ManejarCambioInterno;
                }
            }
        }

        private void ManejarCambioInterno(string anterior, string nuevo)
        {
            EstadoProductoCambiado?.Invoke(this, anterior, nuevo);
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
            List<Seguimiento> seguimiento,
            AreaResponsable areaDevolver
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
            AreaDevolver = areaDevolver;
        }

        public Producto()
        {
            
        }

        public int CompareTo(Producto other)
        {
            if (other == null) return 1;

            decimal thisTotal = this.CostoProducto + this.GastoAdicionalAntesDefecto;
            decimal otherTotal = other.CostoProducto + other.GastoAdicionalAntesDefecto;

            return otherTotal.CompareTo(thisTotal); // Orden descendente
        }

        public object Clone()
        {
            return new Producto
            {
                CodigoProducto = this.CodigoProducto,
                NombreProducto = this.NombreProducto,
                CostoProducto = this.CostoProducto,
                GastoAdicionalAntesDefecto = this.GastoAdicionalAntesDefecto,
                CantidadDaniada = this.CantidadDaniada,
                ProblemaEntrada = this.ProblemaEntrada,
                PersonaResponsable = new Empleado(this.personaResponsable.Fullname),
                UbicacionProducto = new Ubicacion
                {
                    DepositoAlmacenado = this.UbicacionProducto.DepositoAlmacenado,
                    NumeroEstante = this.UbicacionProducto.NumeroEstante,
                    NivelEstante = this.UbicacionProducto.NivelEstante,
                    NumeroColumna = this.UbicacionProducto.NumeroColumna
                },
                EstadoProducto = new EstadoProducto
                {
                    Estado = this.EstadoProducto.Estado,
                    CostoManoObra = this.EstadoProducto.CostoManoObra,
                    CostoPerdida = this.EstadoProducto.CostoPerdida
                },
                Seguimiento = new List<Seguimiento>(this.Seguimiento), // Clona referencias, pero no profundo
                AreaDevolver = new AreaResponsable(this.AreaDevolver.Area)
                
            };
        }

        public override string ToString()
        {
            return $"{CodigoProducto};{NombreProducto};{CostoProducto};{GastoAdicionalAntesDefecto};{CantidadDaniada};{ProblemaEntrada};{PersonaResponsable.Fullname};{AreaDevolver.Area}";
        }
        public List<Ubicacion> DevolverUbicacionProductos()
        {
            return new List<Ubicacion> { this.UbicacionProducto };
        }
        public string ToCsv()
        {
            // Obtener el costo correcto según el tipo de estado
            decimal costoEstado = 0;

            if (EstadoProducto.Estado == "Desechado")
            {
                costoEstado = EstadoProducto.CostoPerdida;
            }
            else if (EstadoProducto.Estado == "Reacondicionable")
            {
                costoEstado = EstadoProducto.CostoManoObra;
            }

            return $"{CodigoProducto};{NombreProducto};{CostoProducto};{GastoAdicionalAntesDefecto};{CantidadDaniada};{ProblemaEntrada};{PersonaResponsable.Fullname};{UbicacionProducto.DepositoAlmacenado};{UbicacionProducto.NumeroEstante};{UbicacionProducto.NivelEstante};{UbicacionProducto.NumeroColumna};{EstadoProducto.Estado};{costoEstado};{AreaDevolver.Area}";
        }

    }
}
