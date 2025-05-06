CREATE DEFINER=`root`@`localhost` PROCEDURE `SPCRUDPROFESORES`(
	IN Param_IdProfesor INT,
    IN Param_Nombre VARCHAR(50),
    IN Param_APaterno VARCHAR(50),
    IN Param_AMaterno VARCHAR(50),
    IN Param_Config INT
)
BEGIN
	
    IF Param_Config = 1 THEN 
        INSERT INTO profesores (Nombre, A_Paterno, A_Materno)
        VALUES (Param_Nombre, Param_APaterno, Param_AMaterno);

    ELSEIF Param_Config = 2 THEN
        IF Param_IdProfesor IS NULL THEN
            SELECT * FROM profesores;
        ELSE
            SELECT * FROM profesores WHERE Id_Profesor = Param_IdProfesor;
        END IF;

    ELSEIF Param_Config = 3 THEN
        UPDATE profesores
        SET Nombre = Param_Nombre,
            A_Paterno = Param_APaterno,
            A_Materno = Param_AMaterno
        WHERE Id_Profesor = Param_IdProfesor;

    ELSEIF Param_Config = 4 THEN
        DELETE FROM profesores
        WHERE Id_Profesor = Param_IdProfesor;

    ELSE
        SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Configuración no valida';
    END IF;
	
END