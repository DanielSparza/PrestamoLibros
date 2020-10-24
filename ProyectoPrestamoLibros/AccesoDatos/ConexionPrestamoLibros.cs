using System.Data;
using Bases;

namespace AccesoDatos
{
    public class ConexionPrestamoLibros
    {
        Conectar c = new Conectar("localhost", "root", "", "prestamolibros");

        //Metodo para insertar, eliminar, modificar
        public string Comando(string q)
        {
            return c.Comando(q);
        }

        //Metodo para consultar
        public DataSet Mostrar(string q, string tabla)
        {
            return c.Consultar(q, tabla);
        }

        //Metodo para verificar usuario y contraseña
        public bool verificar(string tabla, string campousuario, string campocontrasena, string usuario, string contrasena)
        {
            return c.IniciarSesion(tabla, campousuario, campocontrasena, usuario, contrasena);
        }
    }
}
