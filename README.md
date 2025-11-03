# Persona API - ASP.NET MVC con API REST

Proyecto monolito MVC + DAO desarrollado en **.NET 8** con **SQL Server 2022** y desplegado mediante **Docker Compose**.

## Integrantes
- [Miguel Posso](https://github.com/MiguelMarquezPosso)
- [Adrian Ruiz](https://github.com/adrianrrruiz)
- [Juan Galvis](https://github.com/felo312)

## 🚀 Requisitos previos
- Docker Desktop instalado y en ejecución
- Puerto **8080** libre para la API
- Puerto **1433** libre para SQL Server

## ⚙️ Configuración del entorno

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tu_usuario/personapi-dotnet.git
   cd personapi-dotnet
   ```

2. Crear y levantar los contenedores:
   ```bash
   docker compose up --build
   ```

3. Esperar a que SQL Server termine de iniciar. Luego acceder a la API en:
   [http://localhost:8080/home](http://localhost:8080/home)

4. Para detener los servicios:
   ```bash
   docker compose down
   ```

## 🧩 Estructura del proyecto
```
personapi-dotnet/
├── Controllers/
│   ├── Web/
│   │   ├── EstudiosController.cs
│   │   ├── HomeController.cs
│   │   ├── PersonaController.cs
│   │   ├── ProfesionController.cs
│   │   └── TelefonoController.cs
│   └── Api/
│       ├── EstudiosController.cs
│       ├── PersonasController.cs
│       ├── ProfesionesController.cs
│       └── TelefonosController.cs
├── Interfaces/
│   ├── IEstudioRepository.cs
│   ├── IPersonaRepository.cs
│   ├── IProfesionRepository.cs
│   └── ITelefonoRepository.cs
├── Repositories/
│   ├── EstudioRepository.cs
│   ├── PersonaRepository.cs
│   ├── ProfesionRepository.cs
│   └── TelefonoRepository.cs
├── Models/
│   └── Entities/
│       ├── PersonaDbContext.cs
│       ├── Estudio.cs
│       ├── Persona.cs
│       ├── Profesion.cs
│       └── Telefono.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Persona/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Estudios/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Profesion/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Telefono/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── Program.cs
├── appsettings.json
├── personapi-dotnet.csproj
└── README.md
```

## 📋 Descripción
Sistema completo de gestión de personas, profesiones, estudios y teléfonos implementado en ASP.NET Core 7 con arquitectura MVC y API REST.

## 🏗️ Arquitectura
- **Frontend**: ASP.NET MVC con Razor Views
- **Backend**: API REST con Swagger Documentation
- **Patrón**: Repository Pattern + Dependency Injection
- **Base de Datos**: SQL Server con Entity Framework Core

## 🚀 Características
- ✅ CRUD completo para 4 entidades
- ✅ API REST autodocumentada con Swagger
- ✅ Interfaces web responsivas con Bootstrap
- ✅ Separación clara entre Web MVC y API
- ✅ Inyección de dependencias
- ✅ Patrón Repository para reutilización

## 📊 Entidades
1. **Persona** - Información personal
2. **Profesion** - Catálogo de profesiones
3. **Estudio** - Relación personas-profesiones
4. **Telefono** - Números telefónicos

## 🔧 Configuración

### Prerrequisitos
- .NET 7 SDK
- SQL Server 2019+
- Visual Studio 2022 o VS Code

### Pasos de Instalación
1. Clonar repositorio
2. Ejecutar scripts SQL (DDL + DML)
3. Configurar connection string en `appsettings.json`
4. Ejecutar migraciones: `dotnet ef database update`
5. Ejecutar: `dotnet run`

### URLs de Acceso
- **Interfaz Web**: https://localhost:7000
- **API Swagger**: https://localhost:7000/swagger
- **API Base**: https://localhost:7000/api

## 📚 Endpoints API

### Personas
- `GET /api/Personas` - Listar todas
- `GET /api/Personas/{cc}` - Obtener por cédula
- `POST /api/Personas` - Crear nueva
- `PUT /api/Personas/{cc}` - Actualizar
- `DELETE /api/Personas/{cc}` - Eliminar
- `GET /api/Personas/count` - Contar registros

### Profesiones
- `GET /api/Profesiones` - Listar todas
- `GET /api/Profesiones/{id}` - Obtener por ID
- `POST /api/Profesiones` - Crear nueva
- `PUT /api/Profesiones/{id}` - Actualizar
- `DELETE /api/Profesiones/{id}` - Eliminar
- `GET /api/Profesiones/count` - Contar registros

### Estudios
- `GET /api/Estudios` - Listar todos
- `GET /api/Estudios/{idProf}/{ccPer}` - Obtener por clave compuesta
- `POST /api/Estudios` - Crear nuevo
- `PUT /api/Estudios/{idProf}/{ccPer}` - Actualizar
- `DELETE /api/Estudios/{idProf}/{ccPer}` - Eliminar
- `GET /api/Estudios/count` - Contar registros

### Teléfonos
- `GET /api/Telefonos` - Listar todos
- `GET /api/Telefonos/{num}` - Obtener por número
- `POST /api/Telefonos` - Crear nuevo
- `PUT /api/Telefonos/{num}` - Actualizar
- `DELETE /api/Telefonos/{num}` - Eliminar
- `GET /api/Telefonos/count` - Contar registros

## 🧾 Notas
- Los datos del SQL Server persisten gracias al volumen `sql_data`.
