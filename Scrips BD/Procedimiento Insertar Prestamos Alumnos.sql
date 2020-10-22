CREATE DEFINER=`root`@`localhost` PROCEDURE `p_prestamosAlumnos`(
IN p_ISBN VARCHAR(20),
IN p_NoControl INT,
IN p_FechaPrestamo DATE,
IN p_FechaDevolucion DATE,
IN p_Estado VARCHAR(50)
)
BEGIN
Insert into prestamosalumnos values(NULL, p_ISBN, p_NoControl, p_FechaPrestamo, p_FechaDevolucion, p_Estado);
END