-- Instrucciones

DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS Empleados;

create database Prueba;
create table Usuarios(
    userid INT PRIMARY KEY,
    Login_ varchar(100),
    Nombre varchar(100),
    Paterno varchar(100),
    Materno varchar(100)
);
create table Empleados(
    userid INT PRIMARY KEY IDENTITY(1,1),
    Sueldo decimal,
    FechaIngreso date,
    FOREIGN KEY (userid) REFERENCES usuarios(userid)
);
INSERT INTO usuarios (username, nombre, apellido_paterno, apellido_materno) VALUES
('user01', 'BERE', 'NARANJO', 'GONZALEZ'),
('user02', 'ALEXIS', 'CAMPOS', 'NARANJO'),
('user03', 'SERGIO ALEJANDRO', 'CAMPOS', 'HERNANDEZ'),
('user04', 'DIEGO ISMAEL', 'BERUMEN', 'CEDILLO'),
('user05', 'AURORA', 'ESCALANTE', 'PALAFOX'),
('user06', 'JOYCELENE FABIOLA', 'ESTRADA', 'BARBA'),
('user07', 'FRANCISCO', 'ESTRADA', 'GOMEZ'),
('user08', 'LEONARDO DANIEL', 'FARIAS', 'ROSAS'),
('user09', 'RAMON ANDRES', 'FIERROS', 'ROBLES'),
('user10', 'EDGAR ANDRES', 'FLORES', 'OLIVARES'),
('user11', 'MARIA FERNANDA', 'FRANCO', 'ESQUIVEL'),
('user12', 'ALEJANDRO', 'GALVAN', 'MUÑIZ'),
('user13', 'MARTHA ALICIA', 'GUTIERREZ', 'ORTIZ'),
('user14', 'JOSAFAT GERARDO', 'HERNANDEZ', 'SAUCEDO'),
('user15', 'ROSALIA', 'JIMENEZ', 'GONZALEZ'),
('user16', 'LAURA CELENE', 'JIMENEZ', 'RIOS'),
('user17', 'ANGELICA', 'LOPEZ', 'CORTES'),
('user18', 'CRISTIAN IVAN', 'LOPEZ', 'GOMEZ'),
('user19', 'MARLENE GABRIELA', 'LOPEZ', 'MEZA'),
('user20', 'ALEJANDRA', 'MEDINA', 'IBARRA'),
('user21', 'CONSUELO YURIDIANA THALIA', 'MEJIA', 'ALVAREZ'),
('user22', 'JAVIER ADRIAN', 'MEJIA', 'ALVAREZ'),
('user23', 'JUAN CARLOS EVARISTO', 'PEÑA', 'GUTIERREZ'),
('user24', 'JAZMIN ALEJANDRA', 'PEREZ', 'VELEZ'),
('user25', 'GUSTAVO', 'RAMIREZ', 'RIVERA'),
('user26', 'CARLOS NIVARDO', 'RODRIGUEZ', 'ASCENCIO'),
('user27', 'KARLA JOHANA', 'ROMERO', 'LUEVANOS'),
('user28', 'YESSICA YOSELINNE', 'RUIZ', 'HERNANDEZ'),
('user29', 'CHRISTIAN EDUARDO', 'SALAS', 'SANCHEZ'),
('user30', 'LUIS ROBERTO', 'SALDAÑA', 'ESPINOZA'),
('user31', 'ADRIAN', 'SANCHEZ', 'ORTIZ'),
('user32', 'EDUARDO YAIR', 'SUAREZ', 'HERNANDEZ'),
('user33', 'JUAN FRANCISCO', 'TABAREZ', 'GARCIA'),
('user34', 'ZULEICA ELIZABETH', 'TERAN', 'TORRES'),
('user35', 'ADRIANA YUNUHEN', 'VARGAS', 'AYALA'),
('user36', 'OSCAR URIEL', 'VELAZQUEZ', 'ALVAREZ'),
('user37', 'ERICK DE JESUS', 'CORONA', 'DIAZ'),
('user38', 'MARIA GUADALUPE', 'RAMOS', 'HERNANDEZ'),
('user39', 'JESSICA NOEMI', 'JIMENEZ', 'VENTURA'),
('user40', 'FLOR MARGARITA', 'ROJAS', 'HERNANDEZ'),
('user41', 'LUIS ANTONIO', 'ALVARADO', 'VALENCIA'),
('user42', 'EDGAR IVAN', 'AGUILAR', 'PADILLA'),
('user43', 'LUIS ALFONSO', 'MICHEL', 'SANCHEZ'),
('user44', 'JOSE CARLOS', 'SILVA', 'ROCHA'),
('user45', 'JUDITH', 'RODRIGUEZ', 'REYES'),
('user46', 'BRENDA SORAYA', 'CHAVEZ', 'GARCIA'),
('user47', 'ALMA ROSA', 'MARQUEZ', 'AGUILA');

--Ejercicios

SELECT userid, username, nombre, apellido_paterno, apellido_materno
FROM usuarios
WHERE userid NOT IN (6, 7, 9, 10);

UPDATE empleados
SET sueldo = sueldo * 1.1
WHERE YEAR(fecha_contratacion) BETWEEN 2000 AND 2001;

SELECT username, fecha_ingreso
FROM usuarios
WHERE sueldo > 10000 AND apellido LIKE 'T%'
ORDER BY fecha_ingreso DESC;

SELECT
    CASE
        WHEN sueldo < 1200 THEN 'Menos de 1200'
        ELSE '1200 o más'
    END AS grupo_sueldo,
    COUNT(*) AS cantidad_empleados
FROM empleados
GROUP BY
    CASE
        WHEN sueldo < 1200 THEN 'Menos de 1200'
        ELSE '1200 o más'
    END;