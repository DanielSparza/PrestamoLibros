using Entidades;
using AccesoDatos;
using System.Data;

namespace Manejadores
{
    public class ManejadorMaestros
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();

        //Guardar Maestro
        public string Guardar(EntidadMaestros maestros)
        {
            return cl.Comando(string.Format("insert into profesores values" +
                "({0}, '{1}', '{2}', '{3}', '{4}')", maestros.NoControl, maestros.Nombre, maestros.ApPaterno, maestros.ApMaterno, maestros.Especialidad));
        }

        //Borrar Maestro
        public string Borrar(EntidadMaestros maestros)
        {
            return cl.Comando(string.Format("delete from profesores where NoControl={0}", maestros.NoControl));
        }

        //Modificar Maestro
        public string Modificar(EntidadMaestros maestros)
        {
            return cl.Comando(string.Format("update profesores set Nombre='{0}', ApPaterno='{1}', ApMaterno='{2}', Especialidad='{3}' where NoControl={4}",
                maestros.Nombre, maestros.ApPaterno, maestros.ApMaterno, maestros.Especialidad, maestros.NoControl));
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return cl.Mostrar(q, tabla);
        }

    }
}
