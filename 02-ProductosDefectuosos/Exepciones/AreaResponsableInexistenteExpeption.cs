using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Exepciones
{
    public class AreaResponsableInexistenteExpeption : Exception
    {
        public string Area { get; set; }
        public AreaResponsableInexistenteExpeption(string area)
        {
            Area = area;            
        }
        public override string Message => $"El {Area} no existe en el contexto actual. ";
    }
}
