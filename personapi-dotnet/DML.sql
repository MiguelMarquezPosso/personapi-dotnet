-- ============================================
-- Datos de ejemplo para persona_db (SQL Server)
-- ============================================

USE persona_db;
GO

-- Tabla: persona
INSERT INTO persona (cc, nombre, apellido, genero, edad) VALUES
(1010, 'Juan', 'Pérez', 'M', 28),
(1020, 'Laura', 'Gómez', 'F', 32),
(1030, 'Andrés', 'Torres', 'M', 24),
(1040, 'María', 'Rodríguez', 'F', 45);
GO

-- Tabla: profesion
INSERT INTO profesion (id, nom, des) VALUES
(1, 'Ingeniero de Sistemas', 'Diseña y mantiene sistemas informáticos.'),
(2, 'Médico', 'Atiende y diagnostica pacientes.'),
(3, 'Arquitecto', 'Diseña planos y estructuras de edificaciones.'),
(4, 'Docente', 'Imparte clases en instituciones educativas.');
GO

-- Tabla: estudios
INSERT INTO estudios (id_prof, cc_per, fecha, univer) VALUES
(1, 1010, '2020-06-15', 'Pontificia Universidad Javeriana'),
(2, 1020, '2018-12-20', 'Universidad del Rosario'),
(3, 1030, '2022-11-05', 'Universidad Nacional de Colombia'),
(4, 1040, '2010-09-10', 'Universidad de Antioquia');
GO

-- Tabla: telefono
INSERT INTO telefono (num, oper, duenio) VALUES
('3001112233', 'Claro', 1010),
('3102223344', 'Tigo', 1020),
('3203334455', 'Movistar', 1030),
('3014445566', 'Wom', 1040);
GO

-- Verificación de inserciones
SELECT * FROM persona;
SELECT * FROM profesion;
SELECT * FROM estudios;
SELECT * FROM telefono;
GO
