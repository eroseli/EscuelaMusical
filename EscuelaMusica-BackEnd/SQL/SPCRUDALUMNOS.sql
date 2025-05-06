CREATE DEFINER=`root`@`localhost` PROCEDURE `SPCRUDALUMNOS`(
    IN Param_IdAlumno INT,
    IN Param_Nombre VARCHAR(50),
    IN Param_APaterno VARCHAR(50),
    IN Param_AMaterno VARCHAR(50),
    IN Param_FechaNacimiento DATE,
    IN Param_Config VARCHAR(10)
)
BEGIN
    IF Param_Config = 1 THEN
        INSERT INTO alumnos (Nombre, A_Paterno, A_Materno, Fecha_Nacimiento)
        VALUES (Param_Nombre, Param_APaterno, Param_AMaterno, Param_FechaNacimiento);

    ELSEIF Param_Config = 2 THEN
        IF Param_IdAlumno IS NULL THEN
            SELECT * FROM alumnos;
        ELSE
            SELECT * FROM alumnos WHERE Id_Alumno = Param_IdAlumno;
        END IF;

    ELSEIF Param_Config = 3 THEN
        UPDATE alumnos
        SET Nombre = Param_Nombre,
            A_Paterno = Param_APaterno,
            A_Materno = Param_AMaterno,
            Fecha_Nacimiento = Param_FechaNacimiento
        WHERE Id_Alumno = Param_IdAlumno;

    ELSEIF Param_Config = 4 THEN
        DELETE FROM alumnos
        WHERE Id_Alumno = Param_IdAlumno;

    ELSE
        SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Configuración no valida';
    END IF;
END