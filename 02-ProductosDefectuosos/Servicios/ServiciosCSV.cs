using _02_ProductosDefectuosos.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _02_ProductosDefectuosos.Servicios
{
    public static class ServiciosCSV
    {
       
        public static void CrearCSV()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Usuario.csv");

            if (!File.Exists(ruta))
            {
                try
                {
                    // Crear la carpeta si no existe: con el path obtenes donde esta el CSV y despues con el if
                    //preguntas si el path encontro la carpeta que se esta buscando, sino la encuentra la crea.
                    string carpeta = Path.GetDirectoryName(ruta);
                    if (!Directory.Exists(carpeta))
                    {
                        //aca se crea el archivo
                        Directory.CreateDirectory(carpeta);
                    }

                    //aca se crea el encabezado
                    using (StreamWriter sw = new StreamWriter(ruta))
                    {
                        sw.WriteLine("NombreCompleto;Email;Password;Rol;NombreCuenta");
                    }

                    MessageBox.Show("Archivo de usuarios creado correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el archivo: " + ex.Message);
                }
            }
        }
        private static bool ValidarUsuario(string username, string password)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Usuario.csv");

            //esto es por si funciona mal y no encuentra el excel
            if (!File.Exists(ruta))
            {
                MessageBox.Show("el programa esta funcionando mal");
                return false;
            }

            using (StreamReader sr = new StreamReader(ruta))
            {
                string linea;
                bool esPrimeraLinea = true;

                while ((linea = sr.ReadLine()) != null)
                {
                    //cuando "esPrimeraLinea" es true pasa por aca, si es false no.
                    if (esPrimeraLinea)
                    {
                        esPrimeraLinea = false;
                        continue; // saltamos encabezado
                    }
                    //esto es lo de separar las lineas q haciamos antes
                    string[] datos = linea.Split(';');

                    //esto creo que se fija en el archivo de registros si estan los 4 datos con los que habia que registrarse.
                    if (datos.Length == 5)
                    {
                        //aca guarda el usuario y la contraseña asi compara abajo si coinciden con lo que puso recien..
                        //en el inicio de sesion.
                        string usuarioCSV = datos[4];
                        string contraseñaCSV = datos[2];

                        if (usuarioCSV == username && contraseñaCSV == password)
                        {
                            return true;
                        }
                    }
                }
            }

            return false; //cuando no se encuentra.
        }

      
        public static void Ingresar(string nombreUsuarioTxt, string ContraseniaTxt)
        {
            bool respuesta = ValidarUsuario(nombreUsuarioTxt, ContraseniaTxt);
            if (!respuesta) return;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Usuario.csv");
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                //NombreCompleto,Email,Password,Rol,NombreCuenta
                //lucas,123,123,Administrador,luki
                string[] vLinea = linea.Split(';');
                string nombre = vLinea[0];
                string contrasenia = vLinea[2];
                string rol = vLinea[3];
                string nombreCuenta = vLinea[4];
                string email = vLinea[1];


                if (nombreCuenta == nombreUsuarioTxt && contrasenia == ContraseniaTxt)
                {
                    sr.Close();
                    fs.Close();
                    if (rol == "Administrador")
                    {
                        //arreglar esto
                        //NombreCompleto,Email,Password,Rol,NombreCuenta
                        //lucas,123,123,Administrador,luki
                        Administrador adminActivo = new Administrador(nombre, nombreCuenta, email , contrasenia, rol);
                        SesionActiva.Instancia.IniciarSesion(adminActivo);
                    }
                    if (rol == "Empleado")
                    {
                        //arreglar esto
                        Empleado empleadoActivo = new Empleado( nombre, nombreCuenta, email, contrasenia, rol);
                        SesionActiva.Instancia.IniciarSesion(empleadoActivo);
                    }


                    return;
                }
            }
            sr.Close();
            fs.Close();
            MessageBox.Show("Credenciales incorrectas");
        }

        public static void GuardarUsuarioCSV(Usuario usuario)
        {
            //entra al archivo

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Usuario.csv");
            bool archivoExiste = File.Exists(ruta);

            using (StreamWriter sw = new StreamWriter(ruta, true))
            {
                if (!archivoExiste)
                {
                    //esto escribe el encabezado si el archivo no existe
                    sw.WriteLine("NombreCompleto;Email;Password;Rol;NombreCuenta");
                }

                sw.WriteLine(usuario.DameUsuarioString());
            }
        }

        public static void EmpleadosActivos()
        {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Datos/Usuario.csv");
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                //NombreCompleto,Email,Password,Rol,NombreCuenta
                //lucas,123,123,Administrador,luki
                string[] vLinea = linea.Split(';');
                string nombre = vLinea[0];
                string contrasenia = vLinea[2];
                string rol = vLinea[3];
                string nombreCuenta = vLinea[4];
                string email = vLinea[1];
                
                if(rol == "Empleado")
                {
                    Empleado usuarioActual = new Empleado(nombre, nombreCuenta, email, contrasenia, rol);
                    ListadoEmpleados.Instancia.agregarEmpleado(usuarioActual);
                }
                
            }
            sr.Close();
            fs.Close();
           

        }




    }
}
