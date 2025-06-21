using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Interfaces
{
    public interface IGestorSeguimiento
    {
        void AgregarSeguimiento();
        void BorrarSeguimiento();
        void ModificarSeguimiento();
        void ModificarEstadoSeguimiento();
    }
}
