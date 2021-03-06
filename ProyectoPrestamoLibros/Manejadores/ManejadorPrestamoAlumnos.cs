using System.Data;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorPrestamoAlumnos
    {
        ConexionPrestamoLibros cl = new ConexionPrestamoLibros();
        string Fecha;

        int anio;
        int mes;
        int dia;

        //Guardar Prestamo de Alumno
        public string Guardar(EntidadPrestamoAlumnos prestamoAlumnos)
        {
            return aumentarFechaInsertar(prestamoAlumnos.ISBN, prestamoAlumnos.NoControl, prestamoAlumnos.FechaPrestamo, prestamoAlumnos.Estado);
        }

        //Borrar Prestamo de Alumno
        public string Borrar(EntidadPrestamoAlumnos prestamoAlumnos)
        {
            return cl.Comando(string.Format("delete from prestamosalumnos where Id_Prestamo={0}", prestamoAlumnos.IdPrestamo));
        }

        //Modificar Prestamo de Alumno
        public string Modificar(EntidadPrestamoAlumnos prestamoAlumnos)
        {
            return aumentarFechaModificar(prestamoAlumnos.ISBN, prestamoAlumnos.NoControl, prestamoAlumnos.FechaPrestamo, prestamoAlumnos.Estado, prestamoAlumnos.IdPrestamo);
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return cl.Mostrar(q, tabla);
        }

        //Metodo para aumentar la fecha automaticamente
        public string aumentarFechaInsertar(string isbn, int nocontrol, string fechaprestamo, string estado)
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

        //Metodo para aumentar la fecha automaticamente
        public string aumentarFechaModificar(string isbn, int nocontrol, string fechaprestamo, string estado, int id)
        {
            string[] nuevafecha = fechaprestamo.Split('-'); //Separa la fecha ingresada por año, mes y dia

            anio = int.Parse(nuevafecha[0]); //se asigna el año a la variable
            mes = int.Parse(nuevafecha[1]); //Se asigna el mes a la variable
            dia = int.Parse(nuevafecha[2]); //Se asigna el dia a la variable

            bisiesto(anio); //Calcula si el año es bisiesto
            dias_mes(mes, anio); //Calcula los dias del mes
            evaluar(dia, mes, anio); //Devuelve la fecha aumentada

            return cl.Comando(string.Format("update prestamosalumnos set ISBN='{0}', NoControl={1}, FechaPrestamo='{2}', FechaDevolucion='{3}', Estado='{4}' where Id_Prestamo={5}", isbn, nocontrol, fechaprestamo, Fecha, estado, id));
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
