using System;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace Presentacion
{
    public partial class FrmProfesores : Form
    {
        ManejadorMaestros mm;
        EntidadMaestros em = new EntidadMaestros(0, "", "", "", "");
        int fila;
        int id;
        int x = 0;
        string resultado;

        public FrmProfesores()
        {
            InitializeComponent();
            mm = new ManejadorMaestros();
            id = int.Parse(em.NoControl.ToString());
        }

        private void FrmProfesores_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            dgvProfesores.DataSource = mm.Listado(string.Format(
                "select * from profesores where NoControl like '%{0}%'", txtBuscarProfesor.Text), "profesores").Tables[0];

            for (int i = 0; i < dgvProfesores.Columns.Count; i++)
            {
                dgvProfesores.Columns[i].ReadOnly = true;
            }
        }

        private void txtBuscarProfesor_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvProfesores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                em.NoControl = int.Parse(dgvProfesores.Rows[fila].Cells[0].Value.ToString());
                em.Nombre = dgvProfesores.Rows[fila].Cells[1].Value.ToString();
                em.ApPaterno = dgvProfesores.Rows[fila].Cells[2].Value.ToString();
                em.ApMaterno = dgvProfesores.Rows[fila].Cells[3].Value.ToString();
                em.Especialidad = dgvProfesores.Rows[fila].Cells[4].Value.ToString();

                //MessageBox.Show(fila.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("El campo seleccionado está vacío.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNoControl.Text != "")
            {
                if (x > 0)
                {
                    em = new EntidadMaestros(int.Parse(txtNoControl.Text), txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text, txtEspecialidad.Text);
                    string r1 = mm.Modificar(em);
                    MessageBox.Show("El contenido se modificó correctamente.");
                    //Close();
                    Limpiar();
                    Actualizar();
                    x = 0;
                    txtNoControl.Enabled = true;
                }
                else
                {
                    string r2 = mm.Guardar(em = new EntidadMaestros(int.Parse(txtNoControl.Text), txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text, txtEspecialidad.Text));
                    MessageBox.Show("Datos guardados correctamente.");
                    //Close();
                    Limpiar();
                    Actualizar();
                    txtNoControl.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("¡Error al registrar!.");
                //validar.validarContenido(txtNoControl, epCategorias);
            }
            fila = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0 && em.NoControl != 0)
            {
                txtNoControl.Text = em.NoControl.ToString();
                txtNombre.Text = em.Nombre;
                txtApPaterno.Text = em.ApPaterno;
                txtApMaterno.Text = em.ApMaterno;
                txtEspecialidad.Text = em.Especialidad;
                txtNoControl.Enabled = false;

                x++;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún dato para modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.Parse(em.NoControl.ToString()) > 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el profesor " + em.Nombre + " " + em.ApPaterno + " " + em.ApMaterno + "?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    resultado = mm.Borrar(em);
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún profesor para borrar.");
            }
        }

        void Limpiar()
        {
            txtNoControl.Clear();
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtEspecialidad.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            x = 0;
            fila = 0;
            txtNoControl.Enabled = true;
        }
    }
}
