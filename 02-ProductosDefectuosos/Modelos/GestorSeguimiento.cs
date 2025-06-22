using _02_ProductosDefectuosos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class GestorSeguimiento : IGestorSeguimiento
    {
        private List<Seguimiento> listaSeguimientos;

        public GestorSeguimiento()
        {
            listaSeguimientos = new List<Seguimiento>();
        }

        public void AgregarSeguimiento()
        {
            // Implementar agregar seguimiento
        }

        public void BorrarSeguimiento()
        {
            // Implementar borrar seguimiento
        }

        public void ModificarSeguimiento()
        {
            // Implementar modificar seguimiento
        }

        public void ModificarEstadoSeguimiento()
        {
            // Implementar modificar estado seguimiento
        }

        // Métodos adicionales con parámetros para trabajar con listaSeguimientos, etc.
    }
}
