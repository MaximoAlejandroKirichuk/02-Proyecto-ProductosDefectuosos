using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _02_ProductosDefectuosos.Modelos;
using static _02_ProductosDefectuosos.Modelos.EstadoProducto;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            crearCSV();
        }
        public void guardarusuarioCSV(Usuario usuario)
        {
            //entra al archivo
            // lo unico que hace el PATH COMBINE es juntar el nombre del archivo asi no se tiene que buscar todo junto. jajaj
            //es medio dificil de explicar solo con palabras. si no se entiende le preguntan a luki, es facil.

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Datos\Usuario.csv");

            bool archivoExiste = File.Exists(ruta);

            using (StreamWriter sw = new StreamWriter(ruta, true))
            {
                if (!archivoExiste)
                {
                    //esto escribe el encabezado si el archivo no existe
                    sw.WriteLine("NombreCompleto,Email,Password,Rol,NombreCuenta");
                }

                sw.WriteLine(usuario.ToString());
            }
        }
        
        //esto lo hice para crear el CSV cuando no exista. asi cuando nos lo pasamos se crea y fue
        public void crearCSV()
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
                        sw.WriteLine("NombreCompleto,Email,Password,Rol, NombreCuenta");
                    }

                    MessageBox.Show("Archivo de usuarios creado correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el archivo: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //el trim lo unico que hace es sacar los espacios del principio y del final.
            string nombreCompleto = txtFullName.Text.Trim();
            string usuario = txtUserName.Text.Trim();
            string mail = txtMail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string rolTexto = comboBoxRol.Text.ToString();
            
            //esto es nada mas para manejar los errores por si no completan un txt.
            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(rolTexto))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Convertir el string a enum
            if (!Enum.TryParse(rolTexto, out RolEmpresa rol))
            {
                MessageBox.Show("Rol no válido.");
                return;
            }

            switch (rol)
            {
                case RolEmpresa.Administrador:
                    Admin nuevoUsuario = new Admin(nombreCompleto,usuario,mail,password,rolTexto);
                    guardarusuarioCSV(nuevoUsuario);
                    break;
                case RolEmpresa.Empleado:
                    Empleado nuevoEmpleado = new Empleado(nombreCompleto,usuario,mail,password,rolTexto);
                    guardarusuarioCSV(nuevoEmpleado);
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.");
                    break;
            }


            MessageBox.Show("Usuario registrado con éxito.");

            // aca te manda a login cuando te registras
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
    }
}
