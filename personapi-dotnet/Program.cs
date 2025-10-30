using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PersonAPI .NET 8",
        Version = "v1",
        Description = "API REST para gestión de personas, profesiones, estudios y teléfonos"
    });
});

var app = builder.Build();

// Habilitar Swagger SIEMPRE
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonAPI .NET 8 v1");
    c.RoutePrefix = string.Empty; // Para abrir Swagger directamente en /
});

app.UseAuthorization();
app.MapControllers();
app.Run();
