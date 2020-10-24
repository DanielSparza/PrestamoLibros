using System;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace Presentacion
{
    public partial class FrmLibros : Form
    {
        ManejadorLibros ml;
        EntidadLibros el = new EntidadLibros("", "", "", "", 0);
        int fila;
        string id;
        int x = 0;
        string resultado;

        public FrmLibros()
        {
            InitializeComponent();
            ml = new ManejadorLibros();
            id = el.ISBN.ToString();
        }

        private void FrmLibros_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            dgvLibros.DataSource = ml.Listado(string.Format(
                "select * from libros where ISBN like '%{0}%'", txtBuscarLibro.Text), "libros").Tables[0];

            for (int i = 0; i < dgvLibros.Columns.Count; i++)
            {
                dgvLibros.Columns[i].ReadOnly = true;
            }
        }

        private void txtBuscarLibro_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                el.ISBN = dgvLibros.Rows[fila].Cells[0].Value.ToString();
                el.Titulo = dgvLibros.Rows[fila].Cells[1].Value.ToString();
                el.Autor = dgvLibros.Rows[fila].Cells[2].Value.ToString();
                el.Genero = dgvLibros.Rows[fila].Cells[3].Value.ToString();
                el.NoPaginas = int.Parse(dgvLibros.Rows[fila].Cells[4].Value.ToString());

                //MessageBox.Show(fila.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("El campo seleccionado está vacío.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text != "")
            {
                if (x > 0)
                {
                    el = new EntidadLibros(txtISBN.Text, txtTtitulo.Text, txtAutor.Text, txtGenero.Text, int.Parse(txtPaginas.Text)); 
                    string r1 = ml.Modificar(el);
                    MessageBox.Show("El contenido se modificó correctamente.");
                    //Close();
                    Limpiar();
                    Actualizar();
                    x = 0;
                    txtISBN.Enabled = true;
                }
                else
                {
                    string r2 = ml.Guardar(el = new EntidadLibros(txtISBN.Text, txtTtitulo.Text, txtAutor.Text, txtGenero.Text, int.Parse(txtPaginas.Text)));
                    MessageBox.Show("Datos guardados correctamente.");
                    //Close();
                    Limpiar();
                    Actualizar();
                    txtISBN.Enabled = true;
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
            if (fila >= 0 && el.ISBN != "")
            {
                txtISBN.Text = el.ISBN;
                txtTtitulo.Text = el.Titulo;
                txtAutor.Text = el.Autor;
                txtGenero.Text = el.Genero;
                txtPaginas.Text = el.NoPaginas.ToString();
                txtISBN.Enabled = false;

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
            if (int.Parse(el.ISBN) > 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el libro " + el.Titulo + "?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    resultado = ml.Borrar(el);
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún libro para borrar.");
            }
        }

        void Limpiar()
        {
            txtISBN.Clear();
            txtTtitulo.Clear();
            txtAutor.Clear();
            txtGenero.Clear();
            txtPaginas.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            x = 0;
            fila = 0;
            txtISBN.Enabled = true;
        }
    }
}
