namespace Entidades
{
    public class EntidadMaestros
    {
        public int NoControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Especialidad { get; set; }

        public EntidadMaestros(int nocontrol, string nombre, string appaterno, string apmaterno, string especialidad)
        {
            NoControl = nocontrol;
            Nombre = nombre;
            ApPaterno = appaterno;
            ApMaterno = apmaterno;
            Especialidad = especialidad;
        }
    }
}
