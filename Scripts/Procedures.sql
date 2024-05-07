GO
CREATE PROCEDURE login_profesor(@correo VARCHAR(50), @password VARCHAR(50))
AS
BEGIN
	SELECT * FROM PROFESOR WHERE @correo = correo AND @password = password
END
GO
GO
CREATE PROCEDURE login_operador(@correo VARCHAR(50), @password VARCHAR(50))
AS
BEGIN
	SELECT * FROM OPERADOR WHERE @correo = correo AND @password = password
END
GO
--Muestra info del profesor
GO
CREATE PROCEDURE credenciales_profesor
AS 
BEGIN
	SELECT correo, num_cedula ,password, nombre, apellido1, apellido2, fecha_nacimiento, correo_administrador FROM PROFESOR
END 
GO

GO
CREATE PROCEDURE solicitudes_pendientes @correo_profesor VARCHAR(50)
AS 
BEGIN
	SELECT SOLICITUD_ACTIVO.nombre_estudiante,  SOLICITUD_ACTIVO.apellido1_estudiante, SOLICITUD_ACTIVO.apellido2_estudiante,
	TIPO_ACTIVO.tipo, SOLICITUD_ACTIVO.id, SOLICITUD_ACTIVO.placa_activo
	FROM SOLICITUD_ACTIVO 
	INNER JOIN ACTIVO ON SOLICITUD_ACTIVO.placa_activo = ACTIVO.placa
	INNER JOIN TIPO_ACTIVO ON TIPO_ACTIVO.id = ACTIVO.id_tipo
	WHERE SOLICITUD_ACTIVO.aprobado = 0 AND SOLICITUD_ACTIVO.finalizado = 0 AND ACTIVO.aprobacion = 1 
	AND @correo_profesor = SOLICITUD_ACTIVO.correo_profesor;
END 
GO
GO
CREATE PROCEDURE mostrar_facilidades @nombre_lab VARCHAR(10)
AS 
BEGIN
	SELECT facilidad
	FROM FACILIDAD
	
	WHERE nombre_lab = @nombre_lab
END 
GO
--Muestra el horario en el que un lab está ocupado
GO
CREATE PROCEDURE horario_ocupado @nombre_lab VARCHAR(10)
AS
BEGIN
	SELECT fecha, hora_inicio, hora_final FROM PRESTAMO_LAB WHERE @nombre_lab=nombre_lab
END
GO
GO
--Muestra capacidad y computadores del lab
CREATE PROCEDURE info_lab @nombre_lab VARCHAR(10)
AS
BEGIN
	SELECT capacidad, computadores FROM LABORATORIO WHERE @nombre_lab=nombre
END
GO
--Aparta el laboratorio para una hora y fecha en específico
GO
CREATE PROCEDURE apartado_laboratorio_profesor (@correo_profesor VARCHAR(50) , @nombre_lab VARCHAR(10), @fecha Date,
@hora_inicio TIME, @hora_final TIME )
AS
BEGIN
	INSERT INTO PRESTAMO_LAB (fecha,hora_inicio, hora_final, correo_profesor, nombre_lab) VALUES ( @fecha, @hora_inicio, @hora_final,
	@correo_profesor, @nombre_lab);
END
GO
GO
CREATE PROCEDURE cambiar_password_profesor (@correo_profesor VARCHAR(50) , @nuevo_password VARCHAR(50))
AS
BEGIN
	UPDATE PROFESOR
	SET password = @nuevo_password
	WHERE correo = @correo_profesor
END
GO
GO
CREATE PROCEDURE aprobacion_activo (@id_solicitud INT, @placa_activo VARCHAR(50))
AS
BEGIN
	UPDATE SOLICITUD_ACTIVO
	SET aprobado = 1
	WHERE id = @id_solicitud;
	UPDATE ACTIVO
	SET disponible = 0
	WHERE placa = @placa_activo;
END
GO
GO
CREATE PROCEDURE login_administrador(@correo VARCHAR(50), @password VARCHAR(50))
AS
BEGIN
	SELECT * FROM ADMINISTRADOR WHERE @correo = correo AND @password = password
END
GO
GO
CREATE PROCEDURE mostrar_activos_lab @nombre_lab VARCHAR(10)
AS
BEGIN
SELECT  ACTIVO.placa, TIPO_ACTIVO.tipo
FROM ACTIVO 
INNER JOIN TIPO_ACTIVO ON ACTIVO.id_tipo = TIPO_ACTIVO.id 
WHERE @nombre_lab = ACTIVO.nombre_lab
END
GO
GO
CREATE PROCEDURE mostrar_cantidad_activos_lab @nombre_lab VARCHAR(10)
AS
BEGIN
SELECT COUNT(*)
FROM ACTIVO 
WHERE @nombre_lab = ACTIVO.nombre_lab
END
GO
GO
CREATE PROCEDURE modificar_nombre_lab (@nombre_lab_viejo VARCHAR(10), @nombre_lab_nuevo VARCHAR(10))
AS
BEGIN
ALTER TABLE FACILIDAD
NOCHECK CONSTRAINT nombre_lab_facilidad_FK
ALTER TABLE ACTIVO
NOCHECK CONSTRAINT nombre_lab_activo_FK
ALTER TABLE PRESTAMO_LAB
NOCHECK CONSTRAINT nombre_lab_prestamo_lab_FK
ALTER TABLE ADMINISTRACION_LABORATORIOS
NOCHECK CONSTRAINT nombre_lab_administracion_lab_FK
UPDATE LABORATORIO
SET nombre = @nombre_lab_nuevo
WHERE nombre = @nombre_lab_viejo;
UPDATE FACILIDAD
SET nombre_lab = @nombre_lab_nuevo
WHERE nombre_lab = @nombre_lab_viejo;
UPDATE ACTIVO
SET nombre_lab = @nombre_lab_nuevo
WHERE nombre_lab = @nombre_lab_viejo;
UPDATE PRESTAMO_LAB
SET nombre_lab = @nombre_lab_nuevo
WHERE nombre_lab = @nombre_lab_viejo;
UPDATE ADMINISTRACION_LABORATORIOS
SET nombre_lab = @nombre_lab_nuevo
WHERE nombre_lab = @nombre_lab_viejo;
ALTER TABLE FACILIDAD
CHECK CONSTRAINT nombre_lab_facilidad_FK
ALTER TABLE ACTIVO
CHECK CONSTRAINT nombre_lab_activo_FK
ALTER TABLE PRESTAMO_LAB
CHECK CONSTRAINT nombre_lab_prestamo_lab_FK
ALTER TABLE ADMINISTRACION_LABORATORIOS
CHECK CONSTRAINT nombre_lab_administracion_lab_FK
END
GO
GO
CREATE PROCEDURE modificar_capacidad_lab  (@nombre_lab VARCHAR(10), @capacidad INT)
AS
BEGIN
UPDATE LABORATORIO
SET capacidad = @capacidad
WHERE nombre = @nombre_lab
END
GO
GO
CREATE PROCEDURE modificar_computadores_lab  (@nombre_lab VARCHAR(10), @computadores INT)
AS
BEGIN
UPDATE LABORATORIO
SET computadores = @computadores
WHERE nombre = @nombre_lab
END
GO
GO
CREATE PROCEDURE eliminar_facilidad  (@nombre_lab VARCHAR(10), @facilidad VARCHAR(50))
AS
BEGIN

DELETE FROM FACILIDAD
WHERE nombre_lab = @nombre_lab AND facilidad = @facilidad
END
GO
GO
CREATE PROCEDURE agregar_facilidad  (@nombre_lab VARCHAR(10), @facilidad VARCHAR(50))
AS
BEGIN

INSERT INTO FACILIDAD (nombre_lab, facilidad)
VALUES (@nombre_lab, @facilidad)
END
GO
--Se muestra información del activo que no sean presatmos
GO
CREATE PROCEDURE mostrar_info_activos
AS
BEGIN
SELECT ACTIVO.placa, TIPO_ACTIVO.tipo, ACTIVO.marca, ACTIVO.fecha_compra
FROM ACTIVO INNER JOIN TIPO_ACTIVO ON ACTIVO.id_tipo = TIPO_ACTIVO.id
END
GO
GO
CREATE PROCEDURE modificar_placa_activo (@placa_vieja VARCHAR(50), @placa_nueva VARCHAR(50))
AS
BEGIN
ALTER TABLE ADMINISTRACION_ACTIVOS
NOCHECK CONSTRAINT placa_activo_administracion_FK
ALTER TABLE SOLICITUD_ACTIVO
NOCHECK CONSTRAINT placa_activo_solicitud_FK
UPDATE ACTIVO
SET placa = @placa_nueva
WHERE placa = @placa_vieja
UPDATE ADMINISTRACION_ACTIVOS
SET placa_activo = @placa_nueva
WHERE placa_activo = @placa_vieja;
UPDATE SOLICITUD_ACTIVO
SET placa_activo = @placa_nueva
WHERE placa_activo = @placa_vieja;
ALTER TABLE ADMINISTRACION_ACTIVOS
CHECK CONSTRAINT placa_activo_administracion_FK
ALTER TABLE SOLICITUD_ACTIVO
CHECK CONSTRAINT placa_activo_solicitud_FK
END
GO
--Modifica en la tabla activo el id_tipo, recibe el nuevo tipo en un VARCHAR
GO
CREATE PROCEDURE modificar_tipo_activo (@placa_activo VARCHAR(50),@nuevo_tipo VARCHAR(20) )
AS
BEGIN
 DECLARE @nuevo_tipo_id INT;
 SELECT @nuevo_tipo_id = id
 FROM TIPO_ACTIVO
 WHERE tipo = @nuevo_tipo;

 UPDATE ACTIVO
 SET id_tipo = @nuevo_tipo_id
 WHERE placa = @placa_activo
END
GO
GO
CREATE PROCEDURE modificar_marca_activo (@placa_activo VARCHAR(50),@marca VARCHAR(30) )
AS
BEGIN

 UPDATE ACTIVO
 SET marca = @marca
 WHERE placa = @placa_activo
END
GO
GO
CREATE PROCEDURE modificar_fecha_compra_activo (@placa_activo VARCHAR(50),@fecha DATE )
AS
BEGIN

 UPDATE ACTIVO
 SET fecha_compra = @fecha
 WHERE placa = @placa_activo
END
GO
 GO
CREATE PROCEDURE mostrar_prestamos_activo @placa_activo VARCHAR(50)
AS
BEGIN
 SELECT nombre_estudiante, apellido1_estudiante, apellido2_estudiante,correo_estudiante,hora,fecha,finalizado,correo_profesor,correo_operador
 FROM SOLICITUD_ACTIVO
 WHERE aprobado = 1 AND placa_activo = @placa_activo
END
GO
GO
CREATE PROCEDURE agregar_profesor (@correo VARCHAR(50), @num_cedula VARCHAR(11), @password VARCHAR(50), @nombre VARCHAR(20), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20), 
@fecha_nacimiento DATE, @correo_administrador VARCHAR(50))
AS 
BEGIN
	INSERT INTO PROFESOR (correo, num_cedula, password, nombre, apellido1, apellido2, fecha_nacimiento, correo_administrador)
	VALUES (@correo, @num_cedula, @password, @nombre, @apellido1, @apellido2, @fecha_nacimiento, @correo_administrador)
END 
GO
--Hace falta eliminar profesor
CREATE PROCEDURE agregar_tipo_activo @tipo_activo VARCHAR(10)
AS 
BEGIN
	INSERT INTO TIPO_ACTIVO (tipo) VALUES (@tipo_activo)
END 
GO
CREATE PROCEDURE cambiar_nombre_tipo_activo (@tipo_activo_nuevo VARCHAR(10), @tipo_activo_viejo VARCHAR(10))
AS 
BEGIN
	UPDATE TIPO_ACTIVO
	SET tipo = @tipo_activo_nuevo
	WHERE tipo = @tipo_activo_viejo
END 
GO
CREATE PROCEDURE cambiar_nombre_profesor (@correor_profesor VARCHAR(50), @nuevo_nombre VARCHAR(20))
AS 
BEGIN
	UPDATE PROFESOR
	SET nombre = @nuevo_nombre
	WHERE correo = @correor_profesor
END 
GO
CREATE PROCEDURE cambiar_apellido1_profesor (@correor_profesor VARCHAR(50), @nuevo_apellido1 VARCHAR(20))
AS 
BEGIN
	UPDATE PROFESOR
	SET apellido1= @nuevo_apellido1
	WHERE correo = @correor_profesor
END 
GO
CREATE PROCEDURE cambiar_apellido2_profesor (@correor_profesor VARCHAR(50), @nuevo_apellido2 VARCHAR(20))
AS 
BEGIN
	UPDATE PROFESOR
	SET apellido2= @nuevo_apellido2
	WHERE correo = @correor_profesor
END 
GO
CREATE PROCEDURE cambiar_correo_profesor (@correor_profesor_viejo VARCHAR(50), @correor_profesor_nuevo VARCHAR(50))
AS 
BEGIN
	ALTER TABLE PRESTAMO_LAB
	NOCHECK CONSTRAINT correo_profesor_prestamo_lab_FK
	ALTER TABLE SOLICITUD_ACTIVO
	NOCHECK CONSTRAINT correo_profesor_solicitud_FK
	UPDATE PROFESOR
	SET correo= @correor_profesor_nuevo
	WHERE correo = @correor_profesor_viejo
	UPDATE PRESTAMO_LAB
	SET correo_profesor = @correor_profesor_nuevo
	WHERE correo_profesor = @correor_profesor_viejo
	UPDATE SOLICITUD_ACTIVO
	SET correo_profesor = @correor_profesor_nuevo
	WHERE correo_profesor = @correor_profesor_viejo
	ALTER TABLE PRESTAMO_LAB
	CHECK CONSTRAINT correo_profesor_prestamo_lab_FK
	ALTER TABLE SOLICITUD_ACTIVO
	CHECK CONSTRAINT correo_profesor_solicitud_FK
END 
GO
GO
CREATE PROCEDURE cambiar_num_cedula_profesor (@correor_profesor VARCHAR(50), @nuevo_num_cedula VARCHAR(11))
AS 
BEGIN
	UPDATE PROFESOR
	SET num_cedula= @nuevo_num_cedula
	WHERE correo = @correor_profesor
END 
GO
GO
CREATE PROCEDURE cambiar_fecha_nacimiento_profesor (@correor_profesor VARCHAR(50), @nueva_fecha_nacimiento DATE)
AS 
BEGIN
	UPDATE PROFESOR
	SET fecha_nacimiento= @nueva_fecha_nacimiento
	WHERE correo = @correor_profesor
END 
GO
GO
CREATE PROCEDURE mostrar_labs_disponibles 
AS 
BEGIN
	SELECT nombre FROM LABORATORIO
END 
GO
GO
CREATE PROCEDURE eliminar_solicitud_activo @id INT
AS 
BEGIN
	DELETE FROM SOLICITUD_ACTIVO
	WHERE id = @id;
END 
GO
GO
CREATE PROCEDURE mostrar_horario_lab @nombre_lab VARCHAR(10)
AS 
BEGIN
	SELECT dia, hora_apertura, hora_cierre FROM HORARIO
	WHERE nombre_lab = @nombre_lab;
END 
GO
GO
CREATE PROCEDURE mostrar_reservas_lab @nombre_lab VARCHAR(10)
AS 
BEGIN
	SELECT fecha, hora_inicio, hora_final FROM PRESTAMO_LAB
	WHERE nombre_lab = @nombre_lab AND fecha>=GETDATE();
END 
GO
GO
CREATE PROCEDURE reserva_lab_estudiante (@carnet_estud INT , @correo_estud VARCHAR(50) , @nombre_estud VARCHAR(20) , @apellido1_estud VARCHAR(20) , 
@apellido2_estud VARCHAR(20) , @fecha DATE, @hora_inicio TIME, @hora_final TIME, @nombre_lab VARCHAR(10))
AS 
BEGIN
	IF @carnet_estud IS NULL OR @correo_estud IS NULL OR @nombre_estud IS NULL OR @apellido1_estud IS NULL OR @apellido2_estud IS NULL
	BEGIN
		 RAISERROR('Alguno de los parámetros es nulo', 16, 1)
		RETURN
	END
	INSERT INTO PRESTAMO_LAB (carnet_estudiante, correo_estudiante, nombre_estudiante, apellido1_estudiante, apellido2_estudiante, fecha, hora_inicio, hora_final, nombre_lab)
	VALUES(@carnet_estud, @correo_estud, @nombre_estud, @apellido1_estud, @apellido2_estud, @fecha, @hora_inicio, @hora_final, @nombre_lab)
END 
GO
GO
CREATE PROCEDURE solicitud_activos (@correo_estud VARCHAR(50) , @nombre_estud VARCHAR(20) , @apellido1_estud VARCHAR(20) , 
@apellido2_estud VARCHAR(20), @placa_activo VARCHAR(50), @correo_profesor VARCHAR(50), @correo_operador VARCHAR(50))
AS 
BEGIN
	IF  @correo_estud IS NULL OR @nombre_estud IS NULL OR @apellido1_estud IS NULL OR @apellido2_estud IS NULL
	BEGIN
		 RAISERROR('Alguno de los parámetros es nulo', 16, 1)
		RETURN
	END
	INSERT INTO SOLICITUD_ACTIVO
	(correo_estudiante, nombre_estudiante, apellido1_estudiante, apellido2_estudiante, aprobado, finalizado, placa_activo,
	correo_profesor, correo_operador)
	VALUES(@correo_estud, @nombre_estud, @apellido1_estud, @apellido2_estud, 0, 0, @placa_activo, @correo_profesor, @correo_operador)
END 
GO
GO
CREATE PROCEDURE finalizar_prestamo_activo (@id_prestamo INT,@placa_activo VARCHAR )
AS 
BEGIN
	UPDATE SOLICITUD_ACTIVO
	SET finalizado = 1
	WHERE id= @id_prestamo
	UPDATE ACTIVO
	SET disponible = 1
	WHERE placa = @placa_activo
END 
GO
GO
CREATE PROCEDURE agregar_averia (@id_solicitud INT, @detalle VARCHAR(200))
AS 
BEGIN
	IF EXISTS(SELECT 1 FROM SOLICITUD_ACTIVO WHERE aprobado = 1 AND id = @id_solicitud)
	BEGIN 
		INSERT INTO REGISTRO_AVERIAS (id_solicitud, detalle)
		VALUES (@id_solicitud, @detalle)
	END

END 
GO
GO
CREATE PROCEDURE mostrar_reporte_horas_laboradas(@correo_operador VARCHAR(50))
AS
BEGIN
	SELECT 
	hora_entrada, hora_salida, DATEDIFF(HOUR, hora_entrada, hora_salida) AS horas_transcurridas
	FROM REGISTRO_HORAS 
	WHERE correo_operador = @correo_operador
END
GO
GO
CREATE PROCEDURE agregar_laboratorio(@nombre VARCHAR(10), @capacidad INT, @computadores INT )
AS
BEGIN
	INSERT INTO LABORATORIO (nombre, capacidad, computadores) 
	VALUES (@nombre, @capacidad, @computadores)
END
GO
GO
CREATE PROCEDURE cambiar_horario_lab
    @nombre_lab VARCHAR(10),
    @hora_apertura TIME,
    @hora_cierre TIME,
    @dia CHAR(1)
AS
BEGIN
	IF @dia NOT IN('L', 'K', 'M', 'J', 'V', 'S', 'D')
	BEGIN
		RAISERROR('El valor de @dia debe ser uno de los siguientes: L, K, M, J, V, S, D', 16, 1);
		RETURN;
	END
	ELSE
	BEGIN
		UPDATE HORARIO
		SET hora_apertura = @hora_apertura, hora_cierre = @hora_cierre
		WHERE nombre_lab = @nombre_lab AND dia = @dia;
	END
END
GO
GO
CREATE PROCEDURE mostrar_activos_disponibles 
AS
BEGIN
SELECT TIPO_ACTIVO.tipo, ACTIVO.placa, ACTIVO.marca
FROM ACTIVO INNER JOIN TIPO_ACTIVO 
ON ACTIVO.id_tipo = TIPO_ACTIVO.id 
WHERE ACTIVO.disponible = 1
END
GO
GO
CREATE PROCEDURE mostrar_activos_en_prestamo
AS
BEGIN
SELECT id,placa_activo
FROM SOLICITUD_ACTIVO
WHERE aprobado = 1 AND finalizado = 0
END
GO
GO
CREATE PROCEDURE insertar_jornada (@hora_entrada TIME, @hora_salida TIME, @correo_operador VARCHAR(50))
AS
BEGIN
INSERT INTO REGISTRO_HORAS (hora_entrada, hora_salida, correo_operador)
VALUES (@hora_entrada, @hora_salida, @correo_operador)
END
GO

