using AccesoDatos;
using Entidades;
using System.Data;

namespace Manejadores
{
    public class ManejadorLibros
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();

        //Guardar Libro
        public string Guardar(EntidadLibros libros)
        {
            return cl.Comando(string.Format("insert into libros values" +
                "('{0}', '{1}', '{2}', '{3}', {4})", libros.ISBN, libros.Titulo, libros.Autor, libros.Genero, libros.NoPaginas));
        }

        //Borrar Libro
        public string Borrar(EntidadLibros libros)
        {
            return cl.Comando(string.Format("delete from libros where ISBN='{0}'", libros.ISBN));
        }

        //Modificar Libro
        public string Modificar(EntidadLibros libros)
        {
            return cl.Comando(string.Format("update libros set Titulo='{0}', Autor='{1}', Genero='{2}', NoPaginas={3} where ISBN='{4}'",
                libros.Titulo, libros.Autor, libros.Genero, libros.NoPaginas, libros.ISBN));
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return cl.Mostrar(q, tabla);
        }
    }
}
