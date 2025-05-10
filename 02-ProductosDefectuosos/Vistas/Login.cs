using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario como una ventana modal (bloquea el anterior hasta cerrarse)
            Signup formSignup = new Signup();
            formSignup.ShowDialog();

        }

        public bool ValidarUsuario(string username, string password)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "E:\\facultad 2025\\POO\\02-ProductosDefectuosos\\02-ProductosDefectuosos\\bin\\Debug\\Usuario.csv");

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
                    //aca nose porque se escribe asi pero nada mas cuando "esPrimeraLinea" es true pasa por aca, si es false no.
                    if (esPrimeraLinea)
                    {
                        esPrimeraLinea = false;
                        continue; // saltamos encabezado
                    }
                    //esto es lo de separar las lineas q haciamos antes
                    string[] datos = linea.Split(',');

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string contraseña = textBox2.Text.Trim();

            //esta funcion es media rara pero es facil. nada mas es para fijarse si esta vacio el txtbox.
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            bool loginExitoso = ValidarUsuario(usuario, contraseña);

            if (loginExitoso)
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                // aca es para que nos redireccione al formulario principal una vez que iniciamos.
                MainForm frm = new MainForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
