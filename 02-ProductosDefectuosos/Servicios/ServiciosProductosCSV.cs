using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static _02_ProductosDefectuosos.Modelos.AreaResponsable;

namespace _02_ProductosDefectuosos.Servicios
{
    public static class ServiciosProductosCSV
    {
        public static void GuardarProducto()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Productos.csv");
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            List<Producto> listaGuardar = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;

            sw.WriteLine("Codigo Producto;Nombre Producto;Costo Producto;Gasto Adicional;Cantidad Dañada;Problema de entrada;Personal responsable;Deposito;Estante;Nivel;Columna;Estado Producto;Costo Estado;Area Responsable");

            foreach (var producto in ListadoProductoDefectuosos.Instancia.ProductosDefectuosos)
            {
                sw.WriteLine(producto.ToCsv());
            }

            sw.Close();
            fs.Close();
            MessageBox.Show("Se guardo correctamente");
        }

        public static void CargarDatosDesdeArchivo()
        {
            if (ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Count > 0) return;

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Productos.csv");
            using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine(); // Saltar encabezado

                while ((linea = sr.ReadLine()) != null)
                {
                    string[] vLinea = linea.Split(';');


                    string codigo = vLinea[0];
                    string nombreProducto = vLinea[1];
                    decimal costoProducto = Convert.ToDecimal(vLinea[2]);

                    decimal gastoAdicional = Convert.ToDecimal(vLinea[3]);
                    int cantidadDaniada = Convert.ToInt16(vLinea[4]);
                    string problemaEntrada = vLinea[5];
                    Empleado empleadoResponsable = new Empleado(vLinea[6]);
                    string deposito = vLinea[7];
                    int estante = Convert.ToInt16(vLinea[8]);
                    int nivelEstante = Convert.ToInt16(vLinea[9]);
                    int columna = Convert.ToInt16(vLinea[10]);
                    Ubicacion ubicacion = new Ubicacion(deposito, estante, nivelEstante, columna);
                    string estadoTexto = vLinea[11].Trim();
                    decimal costoEstado = Convert.ToDecimal(vLinea[12]);
                    EstadoProducto.TipoEstado tipoEstado = (EstadoProducto.TipoEstado)Enum.Parse(typeof(EstadoProducto.TipoEstado), estadoTexto, true);
                    EstadoProducto estado = new EstadoProducto(costoEstado, tipoEstado);
                    List<Seguimiento> seguimiento = new List<Seguimiento>();
                    AreaPosibles areaEnum = (AreaPosibles)Enum.Parse(typeof(AreaPosibles), vLinea[13]);
                    AreaResponsable area = new AreaResponsable(areaEnum);
                    //TODO: tengo que crear el nuevo producto aca
                    Producto nuevoProducto = new Producto(codigo, nombreProducto, costoProducto, gastoAdicional, cantidadDaniada, problemaEntrada, empleadoResponsable, ubicacion, estado, seguimiento, area);
                    ListadoProductoDefectuosos.Instancia.ProductosDefectuosos.Add(nuevoProducto);
                }
            }
        }
        public static void GuardarSeguimientoProducto()
        {
            string pathSeguimiento = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Seguimientos.csv");
            List<Producto> listaGuardar = ListadoProductoDefectuosos.Instancia.ProductosDefectuosos;
            using (StreamWriter swSeguimiento = new StreamWriter(pathSeguimiento))
            {
                swSeguimiento.WriteLine("Codigo Producto;Fecha;Mensaje;Responsable;Fecha Modificacion");
                foreach (var p in listaGuardar)
                {
                    foreach (var paso in p.Seguimiento)
                    {
                        swSeguimiento.WriteLine($"{p.CodigoProducto};{paso.Fecha:yyyy-MM-dd};{paso.Mensaje};{paso.Responsable};{paso.FechaModificiacion}");
                    }
                }
            }

        }

    }
}
