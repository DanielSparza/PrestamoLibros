namespace Entidades
{
    public class EntidadPrestamoAlumnos
    {
        public int IdPrestamo { get; set; }
        public string ISBN { get; set; }
        public int NoControl { get; set; }
        public string FechaPrestamo { get; set; }
        public string FechaDevolucion { get; set; }
        public string Estado { get; set; }

        public EntidadPrestamoAlumnos(int idprestamo, string isbn, int nocontrol, string fechaprestamo, string fechadevolucion, string estado)
        {
            IdPrestamo = idprestamo;
            ISBN = isbn;
            NoControl = nocontrol;
            FechaPrestamo = fechaprestamo;
            FechaDevolucion = fechadevolucion;
            Estado = estado;
        }
    }
}
