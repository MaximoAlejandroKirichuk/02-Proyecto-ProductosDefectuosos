using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos.Modelos
{
    public class ListadoProductoDefectuosos
    {
        private static ListadoProductoDefectuosos _instancia;
        public List<Producto> ProductosDefectuosos { get; private set; }

        // Constructor privado para que no se pueda crear desde fuera
        private ListadoProductoDefectuosos()
        {
            ProductosDefectuosos = new List<Producto>();
        }

        // Método público para acceder a la única instancia
        public static ListadoProductoDefectuosos Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ListadoProductoDefectuosos();
                return _instancia;
            }
        }

        public void agregarProducto(Producto nuevoProducto)
        {
            ProductosDefectuosos.Add(nuevoProducto);
        }
    }
}
