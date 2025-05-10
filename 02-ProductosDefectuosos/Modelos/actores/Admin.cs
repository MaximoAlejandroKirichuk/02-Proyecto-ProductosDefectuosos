using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Modelos
{
    internal class Admin : Usuario
    {
        
        public Admin(string nombreCompleto, string usuarioNombreCuenta, string mail, string password, string rol)
        {
            this.Username = usuarioNombreCuenta;
            this.Fullname = nombreCompleto;
            this.Mail = mail;
            this.Password = password;
            this.Rol = rol;
        }
        public override void MostrarPermisos()
        {
            MessageBox.Show($"Mis rol es el de: Admin. mi nombre es {Fullname} ");
        }

        public void agregarUsuarios()
        {

        }
    }
}
