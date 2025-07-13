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
        // Lista general de seguimientos para todos los productos
        private List<Seguimiento> listaSeguimientos;

        public GestorSeguimiento()
        {
            listaSeguimientos = new List<Seguimiento>();
        }

        // Agrega un nuevo seguimiento a la lista
        public void AgregarSeguimiento(string codigoProducto, Seguimiento nuevoSeguimiento)
        {
            if (nuevoSeguimiento == null)
                throw new ArgumentNullException(nameof(nuevoSeguimiento));

            nuevoSeguimiento.CodigoProducto = codigoProducto; // Asegurar código asignado

            listaSeguimientos.Add(nuevoSeguimiento);
        }

        // Borra un seguimiento dado el código de producto y las propiedades del seguimiento
        public bool BorrarSeguimiento(string codigoProducto, Seguimiento seguimientoABorrar)
        {
            var seguimientoExistente = listaSeguimientos.FirstOrDefault(s =>
                s.CodigoProducto == codigoProducto &&
                s.Fecha == seguimientoABorrar.Fecha &&
                s.Mensaje == seguimientoABorrar.Mensaje &&
                s.Responsable == seguimientoABorrar.Responsable);

            if (seguimientoExistente != null)
            {
                listaSeguimientos.Remove(seguimientoExistente);
                return true;
            }
            return false;
        }

        // Modifica un seguimiento buscando por código y fecha (asumiendo fecha como identificador único)
        public bool ModificarSeguimiento(string codigoProducto, DateTime fechaOriginal, Seguimiento seguimientoModificado)
        {
            var seguimientoExistente = listaSeguimientos.FirstOrDefault(s =>
                s.CodigoProducto == codigoProducto &&
                s.Fecha == fechaOriginal);

            if (seguimientoExistente != null)
            {
                seguimientoExistente.Fecha = seguimientoModificado.Fecha;
                seguimientoExistente.Mensaje = seguimientoModificado.Mensaje;
                seguimientoExistente.Responsable = seguimientoModificado.Responsable;
                return true;
            }
            return false;
        }

        
        public void ModificarEstadoSeguimiento()
        {
        }

        // Retorna los seguimientos para un producto específico
        public List<Seguimiento> ObtenerSeguimientosPorProducto(string codigoProducto)
        {
            return listaSeguimientos
                .Where(s => s.CodigoProducto == codigoProducto)
                .OrderBy(s => s.Fecha)
                .ToList();
        }

        // Método para cargar lista de seguimientos desde archivo, si hace falta
        public void CargarSeguimientosDesdeArchivo(List<Seguimiento> seguimientos)
        {
            listaSeguimientos = seguimientos ?? new List<Seguimiento>();
        }

        // Método para obtener la lista completa 
        public List<Seguimiento> ObtenerTodosLosSeguimientos()
        {
            return listaSeguimientos;
        }
    }
}