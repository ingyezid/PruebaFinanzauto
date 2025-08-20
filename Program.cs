using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DataContext;
using PruebaFinanzauto.DataSeeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// base de datos en memoria
// builder.Services.AddDbContext<ProjectContext>(p => p.UseInMemoryDatabase("DbFinanzauto"));

// base de datos relacional y en sql server
builder.Services.AddSqlServer<ProjectContext>(builder.Configuration.GetConnectionString("conexionProject"));


var app = builder.Build();

// Para que se actualice la base de datos tan pronto se lanza o dice run sin abrir el navegador
using (var context = new ProjectContext(app.Configuration))
{
    context.Database.Migrate();
    DataSeeder.Seed(context);
}

app.MapGet("/dbconexion", async ([FromServices] ProjectContext dbContext) =>
{
    bool dbCreated = dbContext.Database.EnsureCreated();

    string result0 = "Base de datos recien creada: " + dbCreated;
    string result1 = "Base de datos en memoria: " + dbContext.Database.IsInMemory();
    string result2 = "Base de datos relacional: " + dbContext.Database.IsRelational();
    string result3 = "Base de datos sql server: " + dbContext.Database.IsSqlServer();
    string sumaResultado = " <p> " + result0 + " <br/> " + result1 + " <br/> " + result2 + " <br/> " + result3 + "</p>";

    return Results.Ok(sumaResultado);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
