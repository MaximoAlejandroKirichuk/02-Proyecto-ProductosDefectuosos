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
using System.Drawing.Drawing2D;

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 30; // radio del borde redondeado
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            Rectangle rect = panel1.ClientRectangle;
            int arcSize = borderRadius * 2;

            path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90); // Esquina superior izquierda
            path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90); // Superior derecha
            path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90); // Inferior izquierda
            path.CloseAllFigures();

            panel1.Region = new Region(path); // Establece la forma redondeada
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Load(object sender, EventArgs e)
        {
            int borderRadius = 30; // radio del borde redondeado
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            Rectangle rect = pictureBox1.ClientRectangle;
            int arcSize = borderRadius * 2;

            path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90); // Esquina superior izquierda
            path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90); // Superior derecha
            path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90); // Inferior izquierda
            path.CloseAllFigures();

            pictureBox1.Region = new Region(path); // Establece la forma redondeada

        }
        private void MakePictureBoxCircular(PictureBox pic)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pic.Width, pic.Height);
            pic.Region = new Region(gp);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            MakePictureBoxCircular(pictureBox1);
        }
        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            RedondearControl(txtUsername, 15);
            RedondearControl(txtContrasenia, 15);
        }

        //eventos para que el boton cambie de color
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightBlue; // Color cuando pasás el mouse
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White; // Vuelve al color original
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.MouseEnter += btnLogin_MouseEnter;
            button2.MouseLeave += btnLogin_MouseLeave;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.MouseEnter += btnLogin_MouseEnter;
            button2.MouseLeave += btnLogin_MouseLeave;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mostrar el formulario como una ventana modal (bloquea el anterior hasta cerrarse)
            Signup formSignup = new Signup();
            formSignup.ShowDialog();
        }
    }
}
