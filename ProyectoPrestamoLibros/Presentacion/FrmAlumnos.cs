using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmAlumnos : Form
    {
        ManejadorAlumnos ma;
        EntidadAlumnos ea = new EntidadAlumnos(0, "", "", "", "", 0);
        int fila;
        int id;
        int x = 0;
        string resultado;

        public FrmAlumnos()
        {
            InitializeComponent();
            ma = new ManejadorAlumnos();

            id = int.Parse(ea.NoControl.ToString());
        }

        void Actualizar()
        {
            dgvAlumnos.DataSource = ma.Listado(string.Format(
                "select * from alumnos where NoControl like '%{0}%'", txtBuscarAlumno.Text), "alumnos").Tables[0];

            for (int i = 0; i < dgvAlumnos.Columns.Count; i++)
            {
                dgvAlumnos.Columns[i].ReadOnly = true;
            }
        }

        private void FrmAlumnos_Load(object sender, EventArgs e)
        {
            Actualizar();
            ma.LlenarCarreras(cmbCarrera, "select Carrera from carrera", "carrera");
        }

        private void txtBuscarAlumno_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                ea.NoControl = int.Parse(dgvAlumnos.Rows[fila].Cells[0].Value.ToString());
                ea.Nombre = dgvAlumnos.Rows[fila].Cells[1].Value.ToString();
                ea.ApPaterno = dgvAlumnos.Rows[fila].Cells[2].Value.ToString();
                ea.ApMaterno = dgvAlumnos.Rows[fila].Cells[3].Value.ToString();
                ea.Carrera = dgvAlumnos.Rows[fila].Cells[4].Value.ToString();
                ea.Semestre = int.Parse(dgvAlumnos.Rows[fila].Cells[5].Value.ToString());

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
                string fkidc = ma.GetIdCarrera(cmbCarrera.Text);
                if (x > 0)
                {
                    ea = new EntidadAlumnos(int.Parse(txtNoControl.Text), txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text, fkidc, int.Parse(txtSemestre.Text));
                    string r1 = ma.Modificar(ea);
                    MessageBox.Show("El contenido se modificó correctamente.");
                    //Close();
                    Limpiar();
                    Actualizar();
                    x = 0;
                    txtNoControl.Enabled = true;
                }
                else
                {
                    string r2 = ma.Guardar(ea = new EntidadAlumnos(int.Parse(txtNoControl.Text), txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text, fkidc, int.Parse(txtSemestre.Text)));
                    MessageBox.Show("Datos guardados correctamente.");
                    MessageBox.Show(txtNoControl.Text+" "+txtNombre.Text+" "+txtApPaterno.Text+" "+txtApMaterno.Text+" "+fkidc+" "+txtSemestre.Text);
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
            if (fila >= 0 && ea.NoControl != 0)
            {
                txtNoControl.Text = ea.NoControl.ToString();
                txtNombre.Text = ea.Nombre;
                txtApPaterno.Text = ea.ApPaterno;
                txtApMaterno.Text = ea.ApMaterno;
                txtSemestre.Text = ea.Semestre.ToString();
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
            if (int.Parse(ea.NoControl.ToString()) > 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el alumno " + ea.Nombre + " "+ea.ApPaterno+" "+ea.ApMaterno+"?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    resultado = ma.Borrar(ea);
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún alumno para borrar.");
            }
        }

        void Limpiar()
        {
            txtNoControl.Clear();
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtSemestre.Clear();
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
