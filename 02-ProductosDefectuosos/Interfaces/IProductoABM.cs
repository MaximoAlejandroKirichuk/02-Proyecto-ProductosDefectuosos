using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Interfaces
{
    public interface IProductoABM
    {
        void AgregarProducto(Producto producto);
        void BorrarProducto(Producto borrarProducto);
        void ModificarProducto(Producto productoModificado);
    }
}
