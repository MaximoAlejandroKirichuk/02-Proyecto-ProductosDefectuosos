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

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            crearCSV();
        }
        public void guardarusuarioCSV(usuario usuario)
        {
            //entra al archivo
            // lo unico que hace el PATH COMBINE es juntar el nombre del archivo asi no se tiene que buscar todo junto. jajaj
            //es medio dificil de explicar solo con palabras. si no se entiende le preguntan a luki, es facil.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\github\02-Proyecto-ProductosDefectuosos\02-ProductosDefectuosos\bin\Debug\usuarios.csv");
            bool archivoExiste = File.Exists(ruta);

            using (StreamWriter sw = new StreamWriter(ruta, true))
            {
                if (!archivoExiste)
                {
                    //esto escribe el encabezado si el archivo no existe
                    sw.WriteLine("FullName,Username,Mail,Password");
                }

                sw.WriteLine(usuario.ToString());
            }
        }
        
        //esto lo hice para crear el CSV cuando no exista. asi cuando nos lo pasamos se crea y fue
        public void crearCSV()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\github\02-Proyecto-ProductosDefectuosos\02-ProductosDefectuosos\bin\Debug\usuarios.csv");

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
                        sw.WriteLine("FullName,Username,Email,Password");
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
            string nombre = textBox1.Text.Trim();
            string usuario = textBox2.Text.Trim();
            string mail = textBox3.Text.Trim();
            string password = textBox5.Text;


            //esto es nada mas para manejar los errores por si no completan un txt.
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            usuario nuevoUsuario = new usuario(nombre, usuario, mail, password);
            guardarusuarioCSV(nuevoUsuario);

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
