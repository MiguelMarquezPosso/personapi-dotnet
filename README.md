# PersonAPI .NET

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
├── personapi-dotnet/       # Código fuente del proyecto ASP.NET MVC
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   ├── appsettings.json
│   ├── Dockerfile
│   └── personapi-dotnet.csproj
├── docker-compose.yml
└── README.md
```

## 🧾 Notas
- Los datos del SQL Server persisten gracias al volumen `sql_data`.
