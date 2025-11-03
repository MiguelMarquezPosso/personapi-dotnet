# Persona API - ASP.NET MVC con API REST

| Pruebe la aplicación _(Disponible hasta 01/12/2025)_ : [Abrir Persona API](https://smolderingly-unlarge-mariann.ngrok-free.dev/)

Sistema completo de gestión de personas, profesiones, estudios y teléfonos implementado en **ASP.NET Core 8** con arquitectura **MVC + DAO** y **API REST**.

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

3. _(Solo la primera vez)_ Asegurese de crear la base de datos `persona_db` y llenarla usando el `DDL.sql` y `DML.sql`. La cadena de conexión está en `appsettings.json`:
 
4. Esperar a que SQL Server termine de iniciar. Luego acceder a la API en:
   [http://localhost:8080/Home](http://localhost:8080/Home)

5. Para detener los servicios:
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

## 📊 Entidades
1. **Persona** - Información personal
2. **Profesion** - Catálogo de profesiones
3. **Estudio** - Relación personas-profesiones
4. **Telefono** - Números telefónicos

### URLs de Acceso
- **Interfaz Web**: https://localhost:8080/Home
- **API Swagger**: https://localhost:8080/swagger/index.html

## 🧾 Notas
- Los datos del SQL Server persisten gracias al volumen `sql_data`.
