using Microsoft.EntityFrameworkCore;
using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Repositories;
using AstronomiaEjercicio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<CaracteristicasDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICaracteristicasRepository, CaracteristicasRepository>();
builder.Services.AddScoped<ICaracteristicasService, CaracteristicasService>();

builder.Services.AddScoped<IInstitutosRepository, InstitutosRepository>();
builder.Services.AddScoped<IInstitutosServices, InstitutosService>();

builder.Services.AddScoped<IObservacionesRepository, ObservacionesRepository>();
builder.Services.AddScoped<IObservacionesService, ObservacionesService>();

builder.Services.AddScoped<IObservadoresRepository, ObservadoresRepository>();
builder.Services.AddScoped<IObservadoresService, ObservadoresService>();

builder.Services.AddScoped<ITelescopioRepository, TelescopioRepository>();
builder.Services.AddScoped<ITelescopioService, TelescopioService>();

builder.Services.AddScoped<ITipos_ObjetosRepository, Tipos_ObjetosRepository>();
builder.Services.AddScoped<ITipos_ObjetosService, Tipos_ObjetosService>();





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
