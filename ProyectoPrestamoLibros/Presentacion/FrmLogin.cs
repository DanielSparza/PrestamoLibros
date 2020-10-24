using System;
using System.Windows.Forms;
using AccesoDatos;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cl.verificar("usuarios", "NombreUsuario", "Contrasena", txtUsuario.Text, txtContrasena.Text))
            {
                FrmPrincipal fp = new FrmPrincipal();
                fp.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña no validos.");
            }
        }

        public void Cerrar()
        {
            Close();
        }
    }
}
