using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class SesionActiva
    {
        private static SesionActiva _instancia;

        public Usuario UsuarioActivo { get; private set; }

        private SesionActiva() { }

        public static SesionActiva Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new SesionActiva();
                }
                return _instancia;
            }
        }
        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public void CerrarSesion()
        {
            UsuarioActivo = null;
        }

        
    }
}
