
using Microsoft.EntityFrameworkCore;
using ProyectoEF;
using Microsoft.AspNetCore.Mvc;
using ProyectoEF.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//Server=TIU-2011\\SQLEXPRESS;database=TareasDb;Trusted_Connection=true;Trust Server Certificate=true;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=12345

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//Un nuevo end point
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext)=>{
    //Entity asegura la bd, la crea o la llama
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria true:Creada, false:error; rta:  "+dbContext.Database.IsInMemory());
});
//Consultar tareas
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => {

    //return Results.Ok(dbContext.Tareas);
    //return Results.Ok(dbContext.Tareas.Where(p=>p.PrioridadTarea==ProyectoEF.Models.Prioridad.Baja));
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p=>p.PrioridadTarea==ProyectoEF.Models.Prioridad.Baja));
});
//Guardar tarea
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea) => {

    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    //los dos metodos siguientes hacen lo mismo
    //await dbContext.AddAsync(tarea);
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok(); //si hay un problema con esto retornamos un error o mensaje
});

//para actualizar podemos tomar el id por url
app.MapPut("/api/tareas/{Id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid Id) => {

    var tareaActual = dbContext.Tareas.Find(Id);
    if (tareaActual != null)
    {
        tareaActual.Categoria = tarea.Categoria;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
     
     
    return Results.NotFound();//mensaje para el usuario referente a el registro no encontrado
});


app.Run();
