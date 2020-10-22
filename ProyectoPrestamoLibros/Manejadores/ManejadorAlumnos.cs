using System;
using Entidades;
using AccesoDatos;
using System.Data;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorAlumnos
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();

        //Extraer id Carrera
        public string GetIdCategoria(string carrera)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cl.Mostrar(string.Format("select Id_Carrera from carrera where Carrera = '{0}'",
                    carrera), "carrera").Tables[0];

                DataRow r = dt.Rows[0];
                return r["Id_Carrera"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("No seleccionaste ninguna Carrera.");
                return "";
            }
        }

        //Guardar Alumno
        public string Guardar(EntidadAlumnos alumnos)
        {
            return cl.Comando(string.Format("insert into alumnos values" +
                "({0}, '{1}', '{2}', '{3}', '{4}', {5})", alumnos.NoControl, alumnos.Nombre, alumnos.ApPaterno, alumnos.ApMaterno, alumnos.Carrera, alumnos.Semestre));
        }

        //Borrar Alumno
        public string Borrar(EntidadAlumnos alumnos)
        {
            return cl.Comando(string.Format("delete from alumnos where NoControl={0}", alumnos.NoControl));
        }

        //Modificar Alumno
        public string Modificar(EntidadAlumnos alumnos)
        {
            return cl.Comando(string.Format("update alumnos set Nombre='{0}', ApPaterno='{1}', ApMaterno='{2}', Carrera='{3}', Semestre={4} where NoControl={5}",
                alumnos.Nombre, alumnos.ApPaterno, alumnos.ApMaterno, alumnos.Carrera, alumnos.Semestre, alumnos.NoControl));
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return cl.Mostrar(q, tabla);
        }

        //Mostrar Carreras en Combobox
        public void LlenarCarreras(ComboBox combo, string q, string tabla)
        {
            combo.DataSource = cl.Mostrar(q, tabla).Tables[0];
            combo.DisplayMember = "Carrera";
        }
    }
}
