using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin fl = new FrmLogin();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
            cerrarForms();
            fl.Cerrar();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            bool abierto = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Alumnos")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }

            if (abierto == false)
            {
                FrmAlumnos fa = new FrmAlumnos();
                fa.MdiParent = this;
                fa.Show();
            }
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            bool abierto = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Profesores")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }

            if (abierto == false)
            {
                FrmProfesores fm = new FrmProfesores();
                fm.MdiParent = this;
                fm.Show();
            }
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            bool abierto = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Libros")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }

            if (abierto == false)
            {
                FrmLibros fl = new FrmLibros();
                fl.MdiParent = this;
                fl.Show();
            }
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            bool abierto = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Prestamos")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }

            if (abierto == false)
            {
                FrmPrestamos fp = new FrmPrestamos();
                fp.MdiParent = this;
                fp.Show();
            }
        }

        void cerrarForms()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }
        }
    }
}
