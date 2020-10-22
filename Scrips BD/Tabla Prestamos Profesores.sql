CREATE TABLE PrestamosProfesores(Id_Prestamo INT PRIMARY KEY AUTO_INCREMENT, 
ISBN VARCHAR(20), NoControl INT, FechaPrestamo DATE, FechaDevolucion DATE, Estado VARCHAR(50),
FOREIGN KEY(ISBN) REFERENCES libros(ISBN), FOREIGN KEY(NoControl) REFERENCES profesores(NoControl));