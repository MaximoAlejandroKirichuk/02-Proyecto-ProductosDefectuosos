using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class ReporteResponsable
    {
        public string Responsable { get; set; }                    // Nombre del responsable
        public int CantidadProductos { get; set; }                 // Cantidad total de productos defectuosos
        public decimal CostoTotal { get; set; }                    // Suma de costos de esos productos
        public int CantidadDañadaTotal { get; set; }               // Suma de las cantidades dañadas
        public int Reacondicionables { get; set; }                 // Cuántos están en estado "Reacondicionable"
        public int Desechados { get; set; }
    }
}
