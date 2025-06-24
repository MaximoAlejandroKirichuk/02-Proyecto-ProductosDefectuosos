using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Seguimiento
    {
        public DateTime Fecha { get; set;}
        public string Mensaje { get; set;}
        public string Responsable { get; set;}
        public DateTime FechaModificiacion { get; set; }
        public string CodigoProducto { get; set; }
        public override string ToString()
        {
            return $"Fecha: {Fecha: yyyy-MM-dd};{Mensaje};{Responsable};Fecha modificacion: {FechaModificiacion: yyyy-MM-dd} Codigo Producto:{this.CodigoProducto} ";
        }
        public Seguimiento(DateTime fecha ,string mensaje, string responsbale,string cod)
        {
            this.Fecha = fecha;
            this.Mensaje = mensaje;
            this.Responsable = responsbale;
            this.FechaModificiacion = DateTime.Now;
            this.CodigoProducto = cod;
        }
    }
}
