using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PruebaFinanzauto.DataContext;
using PruebaFinanzauto.DataSeeder;
using System.Security.Claims;
using System.Text;

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


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
        
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingresa el token JWT en este formato: Bearer {tu_token}"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            ),

            NameClaimType = ClaimTypes.Name 
        };
    });

builder.Services.AddAuthorization();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
