-- Script de inicialización mejorado para SQL Server
PRINT '=== INICIANDO SCRIPT DE INICIALIZACIÓN ===';

-- Esperar un poco para que SQL Server esté completamente listo
WAITFOR DELAY '00:00:05';
PRINT 'SQL Server está listo, procediendo con la creación de BD...';

-- Crear base de datos si no existe
IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'persona_db')
BEGIN
    CREATE DATABASE persona_db;
    PRINT '✅ Base de datos "persona_db" creada exitosamente';
END
ELSE
BEGIN
    PRINT 'ℹ️  La base de datos "persona_db" ya existe';
END
GO

-- Cambiar a la base de datos
USE persona_db;
GO

PRINT '✅ Usando base de datos persona_db';

-- Eliminar y recrear tablas en orden correcto (debido a FK)
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'telefono')
DROP TABLE telefono;
PRINT '✅ Tabla telefono eliminada (si existía)';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'estudios')
DROP TABLE estudios;
PRINT '✅ Tabla estudios eliminada (si existía)';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'profesion')
DROP TABLE profesion;
PRINT '✅ Tabla profesion eliminada (si existía)';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'persona')
DROP TABLE persona;
PRINT '✅ Tabla persona eliminada (si existía)';
GO

-- Crear tabla persona
CREATE TABLE persona (
                         cc INT NOT NULL PRIMARY KEY,
                         nombre VARCHAR(45) NOT NULL,
                         apellido VARCHAR(45) NOT NULL,
                         genero CHAR(1) CHECK (genero IN ('M', 'F')) NOT NULL,
                         edad INT NULL
);
PRINT '✅ Tabla "persona" creada exitosamente';
GO

-- Crear tabla profesion
CREATE TABLE profesion (
                           id INT NOT NULL PRIMARY KEY,
                           nom VARCHAR(90) NOT NULL,
                           des NVARCHAR(MAX) NULL
);
PRINT '✅ Tabla "profesion" creada exitosamente';
GO

-- Crear tabla estudios
CREATE TABLE estudios (
                          id_prof INT NOT NULL,
                          cc_per INT NOT NULL,
                          fecha DATE NULL,
                          univer VARCHAR(50) NULL,
                          CONSTRAINT PK_estudios PRIMARY KEY (id_prof, cc_per),
                          CONSTRAINT FK_estudio_persona FOREIGN KEY (cc_per) REFERENCES persona(cc),
                          CONSTRAINT FK_estudio_profesion FOREIGN KEY (id_prof) REFERENCES profesion(id)
);
PRINT '✅ Tabla "estudios" creada exitosamente';
GO

-- Crear tabla telefono
CREATE TABLE telefono (
                          num VARCHAR(15) NOT NULL PRIMARY KEY,
                          oper VARCHAR(45) NOT NULL,
                          duenio INT NOT NULL,
                          CONSTRAINT FK_telefono_persona FOREIGN KEY (duenio) REFERENCES persona(cc)
);
PRINT '✅ Tabla "telefono" creada exitosamente';
GO

-- Insertar datos de ejemplo
PRINT '📝 Insertando datos de ejemplo...';

-- Personas
INSERT INTO persona (cc, nombre, apellido, genero, edad) VALUES
                                                             (1010, 'Juan', 'Pérez', 'M', 28),
                                                             (1020, 'Laura', 'Gómez', 'F', 32),
                                                             (1030, 'Andrés', 'Torres', 'M', 24),
                                                             (1040, 'María', 'Rodríguez', 'F', 45);
PRINT '✅ 4 personas insertadas';

-- Profesiones
INSERT INTO profesion (id, nom, des) VALUES
                                         (1, 'Ingeniero de Sistemas', 'Diseña y mantiene sistemas informáticos.'),
                                         (2, 'Médico', 'Atiende y diagnostica pacientes.'),
                                         (3, 'Arquitecto', 'Diseña planos y estructuras de edificaciones.'),
                                         (4, 'Docente', 'Imparte clases en instituciones educativas.');
PRINT '✅ 4 profesiones insertadas';

-- Estudios
INSERT INTO estudios (id_prof, cc_per, fecha, univer) VALUES
                                                          (1, 1010, '2020-06-15', 'Pontificia Universidad Javeriana'),
                                                          (2, 1020, '2018-12-20', 'Universidad del Rosario'),
                                                          (3, 1030, '2022-11-05', 'Universidad Nacional de Colombia'),
                                                          (4, 1040, '2010-09-10', 'Universidad de Antioquia');
PRINT '✅ 4 estudios insertados';

-- Teléfonos
INSERT INTO telefono (num, oper, duenio) VALUES
                                             ('3001112233', 'Claro', 1010),
                                             ('3102223344', 'Tigo', 1020),
                                             ('3203334455', 'Movistar', 1030),
                                             ('3014445566', 'Wom', 1040);
PRINT '✅ 4 teléfonos insertados';

PRINT '🎉 ==========================================';
PRINT '🎉 SCRIPT COMPLETADO EXITOSAMENTE!';
PRINT '🎉 Base de datos "persona_db" lista para usar';
PRINT '🎉 ==========================================';
GO