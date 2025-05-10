using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class ListadoEmpleados
    {
        public List<Empleado> Empleados { get; private set; }
        //clase singleton
        private static ListadoEmpleados _instancia;

        //constructor privado para que no se pueda crear desde fuera
        public static ListadoEmpleados Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ListadoEmpleados();
                return _instancia;
            }
        }

        public void agregarEmpleado (Empleado nuevoEmpleado)
        {
            Empleados.Add(nuevoEmpleado);
        }

    }
}
