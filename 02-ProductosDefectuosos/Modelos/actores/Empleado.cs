using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class Empleado : Usuario
    {
        
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

        public override void AltaProductos(Producto nuevoProductoDefectuoso)
        {
            ListadoProductoDefectuosos.Instancia.agregarProducto(nuevoProductoDefectuoso);
        }

        public override void AltaSeguimientoProducto(Seguimiento nuevoSeguimiento)
        {
            throw new NotImplementedException();
        }

        public override void BajaSeguimientoProducto(Seguimiento nuevoSeguimiento)
        {
            throw new NotImplementedException();
        }

        public override void ModificadorSeguimientoProducto(Seguimiento nuevoSeguimiento)
        {
            throw new NotImplementedException();
        }
    }
}
