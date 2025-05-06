CREATE DATABASE EscuelaMusica;
use EscuelaMusica;
create table escuelas(
	Id_Escuela INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(200) not null,
    Direccion varchar(200),
    Telefono varchar(10)
);

CREATE TABLE alumnos(
Id_Alumno INT PRIMARY KEY AUTO_INCREMENT,
Nombre VARCHAR(50) NOT NULL,
A_Paterno VARCHAR(50),
A_Materno VARCHAR(50),
Fecha_Nacimiento DATE
);

CREATE TABLE profesores(
	Id_Profesor INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    A_PAterno VARCHAR(50),
    A_MAterno VARCHAR(50)
);

CREATE DEFINER=`root`@`localhost` PROCEDURE `SPCRUDESCUELA`(
	IN Param_Config VARCHAR(10),
	IN Param_Id INT,
    IN Param_Nombre VARCHAR(200),
    IN Param_Direccion VARCHAR(200),
	IN Param_Telefono VARCHAR(10)
)
BEGIN
	
    IF Param_Config = 1 THEN
		INSERT INTO escuelas (Nombre, Direccion, Telefono)
		VALUES (Param_Nombre, Param_Direccion, Param_Telefono);
	
    ELSEIF Param_Config = 2 THEN
    IF Param_Id IS NULL THEN
		SELECT * FROM escuelas;
	ELSE
		SELECT * FROM escuelas WHERE Id_Escuela = Param_Id;
	END IF;

    ELSEIF Param_Config = 3 THEN
		UPDATE escuelas
        SET Nombre = Param_Nombre,
        Direccion = Param_Direccion,
        Telefono = Param_Telefono
	WHERE Id_Escuela = Param_Id;

    ELSEIF Param_Config = 4 THEN
		DELETE FROM escuelas
		WHERE Id_Escuela = Param_Id;
     
	ELSE
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Configuración no valida';
	END IF;

END

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
