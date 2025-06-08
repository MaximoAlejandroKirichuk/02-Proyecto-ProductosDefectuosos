using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Empleado : Usuario
    {
        public override void MostrarPermisos()
        {
            
        }
        public Empleado(string nombreCompleto, string usuario, string mail, string password, string rol)
        {
            this.Mail = mail;
            this.Fullname = nombreCompleto;
            this.Password = password;
            this.Username = usuario;
            this.Rol = rol;
        }
        public Empleado(string nombreCompleto)
        {
            this.Fullname = nombreCompleto;
        }
    }
}
