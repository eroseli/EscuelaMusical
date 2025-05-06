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