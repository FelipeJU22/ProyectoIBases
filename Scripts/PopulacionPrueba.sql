INSERT INTO SOLICITUD_ACTIVO (nombre_estudiante,apellido1_estudiante,apellido2_estudiante,correo_estudiante,aprobado,hora,fecha
,finalizado,placa_activo,correo_profesor,correo_operador)
VALUES ('Vinicius','Falcao','Nazario','vinicius@gmail.com', 0, '14:30:00', '2024-01-17', 0, 'DA79DFR9', 'jleiton@itcr.com','fulano@estudiantec.cr');
INSERT INTO SOLICITUD_ACTIVO (nombre_estudiante,apellido1_estudiante,apellido2_estudiante,correo_estudiante,aprobado,hora,fecha
,finalizado,placa_activo,correo_profesor,correo_operador)
VALUES ('Keylor','Lewandoski','Araujo','keylor@gmail.com', 0, '14:00:00', '2024-03-27', 0, 'JIU6P999', 'jleiton@itcr.com','fulano@estudiantec.cr');
INSERT INTO SOLICITUD_ACTIVO (nombre_estudiante,apellido1_estudiante,apellido2_estudiante,correo_estudiante,aprobado,hora,fecha
,finalizado,placa_activo,correo_profesor,correo_operador)
VALUES ('Lionel','Ruiz','Valencia','lio@gmail.com', 0, '09:00:00', '2023-09-12', 0, '1TY78KK0', 'leoaraya@itcr.com','fulano@estudiantec.cr');
INSERT INTO PRESTAMO_LAB (carnet_estudiante,correo_estudiante,nombre_estudiante,apellido1_estudiante,apellido2_estudiante,fecha,
hora_inicio, hora_final,nombre_lab)
VALUES ('2020896575','pepito@gmail.com','Pepito','Mendez','Quiros','2024-05-02','10:00:00','11:00:00', 'F2-08');
INSERT INTO PRESTAMO_LAB (carnet_estudiante,correo_estudiante,nombre_estudiante,apellido1_estudiante,apellido2_estudiante,fecha,
hora_inicio, hora_final,nombre_lab)
VALUES ('2023856795','julian@gmail.com','Julian','Luna','Amador','2024-05-27','11:00:00','12:00:00', 'F2-09');
INSERT INTO PRESTAMO_LAB (fecha,hora_inicio, hora_final,correo_profesor,nombre_lab)
VALUES ('2024-05-27','11:00:00','12:00:00', 'jleiton@itcr.com' ,'F2-09');
INSERT INTO PRESTAMO_LAB (fecha,hora_inicio, hora_final,correo_profesor,nombre_lab)
VALUES ('2024-05-29','8:00:00','9:00:00', 'leoaraya@itcr.com' ,'F2-08');
INSERT INTO SOLICITUD_ACTIVO (nombre_estudiante, apellido1_estudiante, apellido2_estudiante, correo_estudiante, aprobado, hora, fecha, finalizado,
placa_activo, correo_profesor, correo_operador)
VALUES ('Pepillo', 'Rivera', 'Guzman', 'pepillo@gmail.com', 0, '13:00:00','2024-03-02', 0, '1TY78KK0', 'jleiton@itcr.com', 'mengano@estudiantec.cr');
INSERT INTO SOLICITUD_ACTIVO (nombre_estudiante, apellido1_estudiante, apellido2_estudiante, correo_estudiante, aprobado, hora, fecha, finalizado,
placa_activo, correo_profesor, correo_operador)
VALUES ('Freddie', 'Garbanzo', 'Secaida', 'freddie@gmail.com', 1, '13:00:00','2024-02-10', 1, '1TY78KK0', 'leoaraya@itcr.com', 'mengano@estudiantec.cr');
INSERT INTO SOLICITUD_ACTIVO ( aprobado, hora, fecha, finalizado, placa_activo, correo_profesor, correo_operador)
VALUES ( 1, '15:00:00','2024-04-02', 0, '1TY78KK0', 'jleiton@itcr.com', 'fulano@estudiantec.cr');
INSERT INTO REGISTRO_HORAS (correo_operador, hora_entrada, hora_salida, fecha)
VALUES ('mengano@estudiantec.cr', '08:30:00', '10:00:00', '2024-05-04')