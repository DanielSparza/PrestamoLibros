CREATE TABLE alumnos(NoControl INT PRIMARY KEY, Nombre VARCHAR(50), ApPaterno VARCHAR(50),
ApMaterno VARCHAR(50), Carrera VARCHAR(5), Semestre INT, FOREIGN KEY(Carrera) REFERENCES carrera(Id_Carrera));