using DPA.GreenCity.DOMAIN.Core.Services;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Infrastructure.Data;
using DPA.GreenCity.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DPA.GreenCity.DOMAIN.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<GreenCityDbContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IReportesRepository, ReportesRepository>();
builder.Services.AddTransient<IEstadosReportesRepository, EstadosReportesRepository>();
builder.Services.AddTransient<IReportesService, ReportesService>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<IUsuariosServices, UsuariosServices>();

builder.Services.AddSharedInfrastructure(_config);

builder.Services.AddControllers();

//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder//.WithOrigins("http://www.midominiofrontend.com")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
