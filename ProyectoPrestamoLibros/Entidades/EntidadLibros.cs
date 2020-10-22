namespace Entidades
{
    public class EntidadLibros
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int NoPaginas { get; set; }

        public EntidadLibros(string isbn, string titulo, string autor, string genero, int nopaginas)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            NoPaginas = nopaginas;
        }
    }
}
