using tarea02_b.Infraestructure.Data;
using tarea02_b.Models;
using Microsoft.AspNetCore.Mvc;
using tarea02_b.DTO;

var builder = WebApplication.CreateBuilder(args);

// Registrar el repositorio en el contenedor de servicios
builder.Services.AddSingleton<ITareaRepository, TareaRepository>();

var app = builder.Build();

//curl https://localhost:7032/tareas
app.MapGet("/tareas", (ITareaRepository tarRepo) =>
{
    // Usar la instancia inyectada por el contenedor
    return Results.Ok(tarRepo.GetClientes());
});

app.MapGet("/tareas/{id}", (int id, ITareaRepository tarRepo) =>
{
    // Ejemplo con parseo de parámetros en URL
    return Results.Ok(tarRepo.Get(id));
});

// curl  -Method DELETE https://localhost:7032/tareas/1
app.MapDelete("/tareas/{id}", (int id, ITareaRepository tarRepo) =>
{
    tarRepo.Delete(id);
    return Results.Ok();
});

// Obtener parámetros desde el body
// curl -X POST -H 'Content-Type: application/json' -d '{"id":25, "nombre":"tarea34", "descripcion":"tarea nueva", "duracionH":5, "responsable":"Juan"}' https://localhost:7032/tareas
app.MapPost("/tareas", ([FromBody] TareaDTO tarDTO, ITareaRepository tarRepo) =>
{
    Tarea newTar = new(tarDTO.Id, tarDTO.Nombre, tarDTO.Descripcion, tarDTO.DuracionH, tarDTO.Responsable, tarDTO.Date);
    tarRepo.Add(newTar);
    return Results.Ok();
});

app.Run();
