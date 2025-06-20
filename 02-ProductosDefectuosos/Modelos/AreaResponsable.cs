using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class AreaResponsable
    {
        public enum AreaPosibles
        {
            Administracion,
            Ventas,
            Sistemas,
            Distribución,
            Producción,

        }
        public AreaPosibles Area { get; set; }

        public AreaResponsable(AreaPosibles area)
        {
            Area = area;
        }
        public override string ToString()
        {
            return Area.ToString();
        }


    }
}
