using System.Data;
using Entidades;
using AccesoDatos;

namespace Manejadores
{
    class ManejadorPrestamoProfesores
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();
        string Fecha;

        int anio;
        int mes;
        int dia;

        //Guardar Prestamo de Profesor
        public string Guardar(EntidadPrestamoProfesores prestamoProfesores)
        {
            return aumentarFecha(prestamoProfesores.ISBN, prestamoProfesores.NoControl, prestamoProfesores.FechaPrestamo, prestamoProfesores.Estado);
        }

        //Borrar Prestamo de Profesor
        public string Borrar(EntidadPrestamoProfesores prestamoProfesores)
        {
            return cl.Comando(string.Format("delete from prestamosprofesores where Id_Prestamo={0}", prestamoProfesores.IdPrestamo));
        }

        //Modificar Prestamo de Profesor
        public string Modificar(EntidadPrestamoProfesores prestamoProfesores)
        {
            string[] nuevafecha = prestamoProfesores.FechaPrestamo.Split('-'); //Separa la fecha ingresada por año, mes y dia

            anio = int.Parse(nuevafecha[0]); //se asigna el año a la variable
            mes = int.Parse(nuevafecha[1]); //Se asigna el mes a la variable
            dia = int.Parse(nuevafecha[2]); //Se asigna el dia a la variable

            bisiesto(anio); //Calcula si el año es bisiesto
            dias_mes(mes, anio); //Calcula los dias del mes
            evaluar(dia, mes, anio); //Devuelve la fecha aumentada

            return cl.Comando(string.Format("update prestamosprofesores set ISBN='{0}', NoControl={1}, FechaPrestamo='{2}', FechaDevolucion='{3}', Estado='{4}' where Id_Prestamo={5}",
                prestamoProfesores.ISBN, prestamoProfesores.NoControl, prestamoProfesores.FechaPrestamo, Fecha, prestamoProfesores.Estado, prestamoProfesores.IdPrestamo));
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return cl.Mostrar(q, tabla);
        }

        //Metodo para aumentar la fecha automaticamente
        public string aumentarFecha(string isbn, int nocontrol, string fechaprestamo, string estado)
        {
            string[] nuevafecha = fechaprestamo.Split('-'); //Separa la fecha ingresada por año, mes y dia

            anio = int.Parse(nuevafecha[0]); //se asigna el año a la variable
            mes = int.Parse(nuevafecha[1]); //Se asigna el mes a la variable
            dia = int.Parse(nuevafecha[2]); //Se asigna el dia a la variable

            bisiesto(anio); //Calcula si el año es bisiesto
            dias_mes(mes, anio); //Calcula los dias del mes
            evaluar(dia, mes, anio); //Devuelve la fecha aumentada

            return cl.Comando(string.Format("insert into prestamosalumnos values" +
                "(NULL, '{0}', {1}, '{2}', '{3}', '{4}')", isbn, nocontrol, fechaprestamo, Fecha, estado));
        }

        //Metodo para saber si el año es bisiesto
        public bool bisiesto(int anio)
        {
            return ((anio % 4) == 0 && (anio % 100) != 0) || ((anio % 400) == 0);
        }

        //Metodo para obtener cuantos dias tiene cada mes
        int dias_mes(int mes, int anio)
        {
            int dias = 31;
            if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                dias = 30;
            }
            else if (mes == 2)
            {
                if (bisiesto(anio))
                {
                    dias = 29;
                }
                else
                {
                    dias = 28;
                }
            }
            return dias;
        }

        //Metodo para definir la fecha de salida
        public string evaluar(int day, int mont, int year)
        {
            day = day + 3;

            if (day > dias_mes(mont, year))
            {
                if (day == 34)
                {
                    day = 3;
                    mont++;
                    if (mont > 12)
                    {
                        mont = 1;
                        year++;
                    }
                }
                else if (day == 33 && mont == 4 || day == 33 && mont == 6 || day == 33 && mont == 9 || day == 33 && mont == 11)
                {
                    day = 3;
                    mont++;
                    if (mont > 12)
                    {
                        mont = 1;
                        year++;
                    }
                }
                else if (day == 33)
                {
                    day = 2;
                    mont++;
                    if (mont > 12)
                    {
                        mont = 1;
                        year++;
                    }
                }
                else
                {
                    day = 3;
                    mont++;
                    if (mont > 12)
                    {
                        mont = 1;
                        year++;
                    }
                }
            }
            Fecha = year + "-" + mont + "-" + day;

            return Fecha;
        }
    }
}
