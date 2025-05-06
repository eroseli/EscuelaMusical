using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Infrastructure.Data;
using EscuelaMusica_BackEnd.Repositories;
using EscuelaMusica_BackEnd.Services;
using EscuelaMusica_BackEnd.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
 
var mySQLConection = new MySQLConnection(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConection); // Registra MySQLConnection

builder.Services.AddScoped<IEscuelaService, EscuelaService>(); // Ejemplo de servicio con lógica de negocio
builder.Services.AddScoped<IEscuelaRepository, EscuelaRepository>(); // Ejemplo de repositorio
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IAumnoRepository, AlumnoRepository>();

var app = builder.Build();

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

