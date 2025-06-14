using _02_ProductosDefectuosos.Modelos;
using _02_ProductosDefectuosos.Servicios;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsername.Text.Trim();
            string contrasenia = ServiciosUsuariosCSV.HashPassword(txtContrasenia.Text.Trim());

            //esta funcion es media rara pero es facil. nada mas es para fijarse si esta vacio el txtbox.
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }
            //aca iniciar sesion
            // singleton
            ServiciosUsuariosCSV.Ingresar(nombreUsuario, contrasenia);

            Usuario usuarioActivo = SesionActiva.Instancia.UsuarioActivo;
            if (usuarioActivo != null)
            {
                MessageBox.Show("Inicio de sesión exitoso. Bienvenido: " + usuarioActivo.Fullname);
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
