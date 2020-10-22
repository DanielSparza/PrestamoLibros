namespace Entidades
{
    public class EntidadAlumnos
    {
        public int NoControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Carrera { get; set; }
        public int Semestre { get; set; }

        public EntidadAlumnos(int nocontrol, string nombre, string appaterno, string apmaterno, string carrera, int semestre)
        {
            NoControl = nocontrol;
            Nombre = nombre;
            ApPaterno = appaterno;
            ApMaterno = apmaterno;
            Carrera = carrera;
            Semestre = semestre;
        }
    }
}
