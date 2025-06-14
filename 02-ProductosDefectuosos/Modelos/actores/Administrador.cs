using _02_ProductosDefectuosos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Modelos
{
    internal class Administrador : Usuario, IProductoABM
    {
        
        public Administrador(string nombreCompleto, string usuarioNombreCuenta, string mail, string password, string rol)
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

        

        public void AgregarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void BorrarProducto(Producto borrarProducto)
        {
            ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Remove(borrarProducto);
        }

        public void ModificarProducto(Producto productoModificado)
        {
            var lista = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
            var productoExistente = lista.FirstOrDefault(p => p.CodigoProducto == productoModificado.CodigoProducto);
            if (productoExistente != null)
            {
                productoExistente.NombreProducto = productoModificado.NombreProducto;
                productoExistente.CostoProducto = productoModificado.CostoProducto;
                productoExistente.GastoAdicionalAntesDefecto = productoModificado.GastoAdicionalAntesDefecto;
                productoExistente.CantidadDaniada = productoModificado.CantidadDaniada;
                productoExistente.ProblemaEntrada = productoModificado.ProblemaEntrada;
                productoExistente.PersonaResponsable = productoModificado.PersonaResponsable;
                productoExistente.UbicacionProducto = productoModificado.UbicacionProducto;
                productoExistente.EstadoProducto = productoModificado.EstadoProducto;
            }
        }
    }
}
