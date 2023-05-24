
using Microsoft.EntityFrameworkCore;
using ProyectoEF;
using Microsoft.AspNetCore.Mvc;

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

app.Run();
