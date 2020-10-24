using System;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace Presentacion
{
    public partial class FrmPrestamos : Form
    {
        ManejadorPrestamoAlumnos mpa;
        ManejadorPrestamoProfesores mpp;

        EntidadPrestamoAlumnos epa = new EntidadPrestamoAlumnos(0, "", 0, "", "", "");
        EntidadPrestamoProfesores epp = new EntidadPrestamoProfesores(0, "", 0, "", "", "");

        int filaAlumnos, filaProfesores;
        int ida, idp;
        int x = 0;
        string resultado;
        string opcion;

        public FrmPrestamos()
        {
            InitializeComponent();
            mpa = new ManejadorPrestamoAlumnos();
            mpp = new ManejadorPrestamoProfesores();
            ida = epa.IdPrestamo;
            idp = epp.IdPrestamo;
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void cmbPrestamos_TextChanged(object sender, EventArgs e)
        {
            opcion = cmbPrestamos.Text;
            Actualizar();
            //MessageBox.Show("opción: "+opcion);
        }

        private void txtBuscarPrestamo_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (opcion == "Alumnos")
                {
                    filaAlumnos = e.RowIndex;
                    epa.IdPrestamo = int.Parse(dgvPrestamos.Rows[filaAlumnos].Cells[0].Value.ToString());
                    epa.ISBN = dgvPrestamos.Rows[filaAlumnos].Cells[1].Value.ToString();
                    epa.NoControl = int.Parse(dgvPrestamos.Rows[filaAlumnos].Cells[2].Value.ToString());
                    epa.FechaPrestamo = dgvPrestamos.Rows[filaAlumnos].Cells[3].Value.ToString();
                    epa.FechaDevolucion = dgvPrestamos.Rows[filaAlumnos].Cells[4].Value.ToString();
                    epa.Estado = dgvPrestamos.Rows[filaAlumnos].Cells[5].Value.ToString();
                }
                else if(opcion == "Profesores")
                {
                    filaProfesores = e.RowIndex;
                    epp.IdPrestamo = int.Parse(dgvPrestamos.Rows[filaProfesores].Cells[0].Value.ToString());
                    epp.ISBN = dgvPrestamos.Rows[filaProfesores].Cells[1].Value.ToString();
                    epp.NoControl = int.Parse(dgvPrestamos.Rows[filaProfesores].Cells[2].Value.ToString());
                    epp.FechaPrestamo = dgvPrestamos.Rows[filaProfesores].Cells[3].Value.ToString();
                    epp.FechaDevolucion = dgvPrestamos.Rows[filaProfesores].Cells[4].Value.ToString();
                    epp.Estado = dgvPrestamos.Rows[filaProfesores].Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione alumnos o profesores.");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("El campo seleccionado está vacío.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("opcion guardar: "+opcion);
            if(opcion == "Alumnos")
            {
                if (txtISBN.Text != "")
                {
                    if (x > 0)
                    {
                        epa = new EntidadPrestamoAlumnos(epa.IdPrestamo, txtISBN.Text, int.Parse(txtNoControl.Text), dtpFechaPrestamo.Text, "", txtEstado.Text);
                        string r1 = mpa.Modificar(epa);
                        MessageBox.Show("El prestamo de alumno se modificó correctamente.");
                        Limpiar();
                        Actualizar();
                        x = 0;
                    }
                    else
                    {
                        string r2 = mpa.Guardar(epa = new EntidadPrestamoAlumnos(0, txtISBN.Text, int.Parse(txtNoControl.Text), dtpFechaPrestamo.Text, "", txtEstado.Text));
                        MessageBox.Show("Datos guardados correctamente.");
                        Limpiar();
                        Actualizar();
                    }
                }
                else
                {
                    MessageBox.Show("¡Error al registrar!.");
                }
                filaAlumnos = 0;
                filaProfesores = 0;
            }
            else if(opcion == "Profesores")
            {
                if (txtISBN.Text != "")
                {
                    if (x > 0)
                    {
                        epp = new EntidadPrestamoProfesores(epp.IdPrestamo, txtISBN.Text, int.Parse(txtNoControl.Text), dtpFechaPrestamo.Text, "", txtEstado.Text);
                        string r1 = mpp.Modificar(epp);
                        MessageBox.Show("El prestamo de profesor se modificó correctamente.");
                        Limpiar();
                        Actualizar();
                        x = 0;
                    }
                    else
                    {
                        string r2 = mpp.Guardar(epp = new EntidadPrestamoProfesores(0, txtISBN.Text, int.Parse(txtNoControl.Text), dtpFechaPrestamo.Text, "", txtEstado.Text));
                        MessageBox.Show("Datos guardados correctamente.");
                        Limpiar();
                        Actualizar();
                    }
                }
                else
                {
                    MessageBox.Show("¡Error al registrar!.");
                }
                filaAlumnos = 0;
                filaProfesores = 0;
            }
            else
            {
                MessageBox.Show("No se pudo guardar.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(opcion == "Alumnos")
            {
                if (filaAlumnos >= 0 && epa.ISBN != "")
                {
                    txtISBN.Text = epa.ISBN;
                    txtNoControl.Text = epa.NoControl.ToString();
                    txtFechaDevolucion.Text = epa.FechaDevolucion;
                    txtEstado.Text = epa.Estado;
                    dtpFechaPrestamo.Text = epa.FechaPrestamo;

                    x++;
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("No seleccionaste ningún dato para modificar.");
                }
            }
            else if (opcion == "Profesores")
            {
                if (filaProfesores >= 0 && epa.ISBN != "")
                {
                    txtISBN.Text = epp.ISBN;
                    txtNoControl.Text = epp.NoControl.ToString();
                    txtFechaDevolucion.Text = epp.FechaDevolucion;
                    txtEstado.Text = epp.Estado;
                    dtpFechaPrestamo.Text = epp.FechaPrestamo;

                    x++;
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("No seleccionaste ningún dato para modificar.");
                }
            }
            else
            {
                MessageBox.Show("No se pudo modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (opcion == "Alumnos")
            {
                if (int.Parse(epa.ISBN) > 0)
                {
                    DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el registro del libro " + epa.ISBN + "?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        resultado = mpa.Borrar(epa);
                        Actualizar();
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionaste ningún registro para borrar.");
                }
            }
            else if(opcion == "Profesores")
            {
                if (int.Parse(epp.ISBN) > 0)
                {
                    DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el registro del libro " + epp.ISBN + "?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        resultado = mpp.Borrar(epp);
                        Actualizar();
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionaste ningún registro para borrar.");
                }
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro.");
            }
            
        }

        void Actualizar()
        {
            if (opcion == "Alumnos")
            {
                dgvPrestamos.DataSource = mpa.Listado(string.Format(
                "select * from prestamosalumnos where ISBN like '%{0}%'", txtBuscarPrestamo.Text), "prestamosalumnos").Tables[0];

                for (int i = 0; i < dgvPrestamos.Columns.Count; i++)
                {
                    dgvPrestamos.Columns[i].ReadOnly = true;
                }
            }
            else if (opcion == "Profesores")
            {
                dgvPrestamos.DataSource = mpa.Listado(string.Format(
               "select * from prestamosprofesores where ISBN like '%{0}%'", txtBuscarPrestamo.Text), "prestamosprofesores").Tables[0];

                for (int i = 0; i < dgvPrestamos.Columns.Count; i++)
                {
                    dgvPrestamos.Columns[i].ReadOnly = true;
                }
            }
            //MessageBox.Show("Combo: "+cmbPrestamos.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            x = 0;
            filaAlumnos = 0;
            filaProfesores = 0;
        }

        void Limpiar()
        {
            txtISBN.Clear();
            txtNoControl.Clear();
            txtFechaDevolucion.Clear();
            txtEstado.Clear();
        }
    }
}
