USE LabCE_DB
CREATE TABLE ADMINISTRADOR(
	correo VARCHAR(50) PRIMARY KEY,
	password VARCHAR(50) NOT NULL,
);
CREATE TABLE PROFESOR(
	correo VARCHAR(50) PRIMARY KEY,
	num_cedula VARCHAR(11) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL,
	nombre VARCHAR(20) NOT NULL,
	apellido1 VARCHAR(20) NOT NULL,
	apellido2 VARCHAR(20) NOT NULL,
	fecha_nacimiento DATE,
	correo_administrador VARCHAR(50) NOT NULL
);
ALTER TABLE PROFESOR
ADD CONSTRAINT correo_administrador_profesor_FK FOREIGN KEY (correo_administrador)
REFERENCES ADMINISTRADOR(correo);
CREATE TABLE OPERADOR(
	correo VARCHAR(50) PRIMARY KEY,
	nombre VARCHAR(20) NOT NULL,
	apellido1 VARCHAR(20) NOT NULL,
	apellido2 VARCHAR(20) NOT NULL,
	num_cedula VARCHAR(11) NOT NULL UNIQUE,
	password VARCHAR(50) NOT NULL,
	aprobado BIT NOT NULL,
	fecha_nacimiento DATE NOT NULL,
	carnet INT NOT NULL UNIQUE,
	correo_administrador VARCHAR(50) NOT NULL
);
ALTER TABLE OPERADOR
ADD CONSTRAINT correo_administrador_operador_FK FOREIGN KEY (correo_administrador)
REFERENCES ADMINISTRADOR(correo);
CREATE TABLE REGISTRO_HORAS(
	correo_operador VARCHAR(50) NOT NULL,
	hora_entrada TIME NOT NULL,
	hora_salida TIME NOT NULL,
	fecha DATE NOT NULL
);
ALTER TABLE REGISTRO_HORAS
ADD CONSTRAINT correo_operador_registro_FK FOREIGN KEY (correo_operador)
REFERENCES OPERADOR(correo);
CREATE TABLE LABORATORIO(
	nombre VARCHAR(10) PRIMARY KEY,
	capacidad INT NOT NULL,
	computadores INT NOT NULL
);
CREATE TABLE FACILIDAD(
	nombre_lab VARCHAR(10) NOT NULL,
	facilidad VARCHAR(50) NOT NULL
);
ALTER TABLE FACILIDAD
ADD CONSTRAINT nombre_lab_facilidad_FK FOREIGN KEY (nombre_lab)
REFERENCES LABORATORIO(nombre);
CREATE TABLE TIPO_ACTIVO(
	id INT IDENTITY(1,1) PRIMARY KEY,
	tipo VARCHAR(20) UNIQUE NOT NULL
);
CREATE TABLE ACTIVO(
	placa VARCHAR(50) PRIMARY KEY,
	disponible BIT NOT NULL,
	aprobacion BIT NOT NULL,
	fecha_compra DATE,
	id_tipo INT NOT NULL,
	nombre_lab VARCHAR(10),
	marca VARCHAR(30) NOT NULL
);
ALTER TABLE ACTIVO
ADD CONSTRAINT id_tipo_activo_FK FOREIGN KEY (id_tipo)
REFERENCES TIPO_ACTIVO(id);
ALTER TABLE ACTIVO
ADD CONSTRAINT nombre_lab_activo_FK FOREIGN KEY (nombre_lab)
REFERENCES LABORATORIO(nombre);
CREATE TABLE ADMINISTRACION_ACTIVOS(
	correo_administrador VARCHAR(50) NOT NULL,
	placa_activo VARCHAR(50) NOT NULL,
);
ALTER TABLE ADMINISTRACION_ACTIVOS
ADD CONSTRAINT correo_administrador_administracion_FK FOREIGN KEY (correo_administrador)
REFERENCES ADMINISTRADOR(correo);
ALTER TABLE  ADMINISTRACION_ACTIVOS
ADD CONSTRAINT placa_activo_administracion_FK FOREIGN KEY (placa_activo)
REFERENCES ACTIVO(placa);
CREATE TABLE PRESTAMO_LAB(
	id INT IDENTITY (1,1) PRIMARY KEY,
	carnet_estudiante INT,
	correo_estudiante VARCHAR(50),
	nombre_estudiante VARCHAR(20),
	apellido1_estudiante VARCHAR(20),
	apellido2_estudiante VARCHAR(20),
	fecha DATE NOT NULL,
	hora_inicio TIME NOT NULL,
	hora_final TIME NOT NULL,
	correo_profesor VARCHAR(50),
	nombre_lab VARCHAR(10) NOT NULL
);
ALTER TABLE PRESTAMO_LAB
ADD CONSTRAINT correo_profesor_prestamo_lab_FK FOREIGN KEY (correo_profesor)
REFERENCES PROFESOR(correo);
ALTER TABLE PRESTAMO_LAB
ADD CONSTRAINT nombre_lab_prestamo_lab_FK FOREIGN KEY (nombre_lab)
REFERENCES LABORATORIO(nombre);
CREATE TABLE SOLICITUD_ACTIVO(
    id INT IDENTITY (1,1) PRIMARY KEY,
	nombre_estudiante VARCHAR(20),
	apellido1_estudiante VARCHAR(20),
	apellido2_estudiante VARCHAR(20),
	correo_estudiante VARCHAR(50),
	aprobado BIT NOT NULL,
	hora TIME DEFAULT CAST(GETDATE() AS TIME),
	fecha DATE DEFAULT GETDATE(),
	finalizado BIT NOT NULL,
	placa_activo VARCHAR(50) NOT NULL,
	correo_profesor VARCHAR(50) NOT NULL,
	correo_operador VARCHAR(50) NOT NULL
	
);
ALTER TABLE SOLICITUD_ACTIVO
ADD CONSTRAINT placa_activo_solicitud_FK FOREIGN KEY (placa_activo)
REFERENCES ACTIVO(placa);
ALTER TABLE SOLICITUD_ACTIVO
ADD CONSTRAINT correo_profesor_solicitud_FK FOREIGN KEY (correo_profesor)
REFERENCES PROFESOR(correo);
ALTER TABLE SOLICITUD_ACTIVO
ADD CONSTRAINT correo_operador_solicitud_FK FOREIGN KEY (correo_operador)
REFERENCES OPERADOR(correo);
USE LabCE_DB
ALTER TABLE SOLICITUD_ACTIVO
ADD CONSTRAINT comprobacion_aprobado_finalizado 
CHECK (
    (aprobado = 1 AND finalizado = 1) OR 
    (aprobado = 0 AND finalizado = 0) OR 
    (aprobado = 1 AND finalizado = 0)
);
CREATE TABLE REGISTRO_AVERIAS(
    id_solicitud INT UNIQUE,
	detalle VARCHAR(200) NOT NULL,
	
);
ALTER TABLE REGISTRO_AVERIAS
ADD CONSTRAINT id_solicitud_averia_FK FOREIGN KEY (id_solicitud)
REFERENCES SOLICITUD_ACTIVO(id);
CREATE TABLE ADMINISTRACION_LABORATORIOS(
	correo_administrador VARCHAR(50) NOT NULL,
	nombre_lab VARCHAR(10) NOT NULL
);
ALTER TABLE ADMINISTRACION_LABORATORIOS
ADD CONSTRAINT correo_admin_administracion_lab_FK FOREIGN KEY (correo_administrador)
REFERENCES ADMINISTRADOR(correo);
ALTER TABLE ADMINISTRACION_LABORATORIOS
ADD CONSTRAINT nombre_lab_administracion_lab_FK FOREIGN KEY (nombre_lab)
REFERENCES LABORATORIO(nombre);
CREATE TABLE HORARIO (
	nombre_lab VARCHAR(10) NOT NULL,
	dia VARCHAR(1) CHECK(dia IN ('L', 'K', 'M', 'J', 'V','S', 'D' )) NOT NULL,
	hora_apertura TIME NOT NULL,
	hora_cierre TIME NOT NULL
);
ALTER TABLE HORARIO
ADD CONSTRAINT nombre_lab_horario_FK FOREIGN KEY (nombre_lab) 
REFERENCES LABORATORIO(nombre)
ALTER TABLE HORARIO
ADD CONSTRAINT horario_PK UNIQUE (nombre_lab, dia)