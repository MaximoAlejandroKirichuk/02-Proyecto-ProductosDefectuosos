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
        public override string ToString()
        {
            return $"Fecha Ingreso: {Fecha: yyyy-MM-dd};{Mensaje};{Responsable};Fecha modificacion: {FechaModificiacion: yyyy-MM-dd}";
        }
        public Seguimiento(DateTime fecha ,string mensaje, string responsbale)
        {
            this.Fecha = fecha;
            this.Mensaje = mensaje;
            this.Responsable = responsbale;
            this.FechaModificiacion = DateTime.Now;
        }
    }
}
