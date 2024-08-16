using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MediatR;
using SMS.Application.Mapping;
using SMS.Application.Services;
using System.Reflection;
using SMS.Application.Commands.Absences;
using SMS.Domain.Interfaces;
using SMS.Infrastructure.Repositories;
using SMS.Infrastructure;
using SMS.Infrastructure.HealthChecks;
using SMS.Domain.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using SMS.Application.Handlers.Absences;
using SMS.Application.Handlers.Seances;
using SMS.Application.Queries.Absences;
using SMS.Application.Queries.Seances;
using SMS.Application.Handlers;
using SMS.Application.Mapping.SMS.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using SMS.Application.Queries.Emplois;
using SMS.Application.Handlers.Emplois;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
.AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
 });

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

// Configure DbContext with SQL Server
builder.Services.AddDbContext<FiliereDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SMS.Infrastructure")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(GetAllAbsencesQuery).Assembly,
    typeof(GetAllAbsencesHandler).Assembly,
    typeof(GetAllSeanceQuery).Assembly,
    typeof(GetAllSeanceHandler).Assembly,
    typeof(CreateAbsenceHandler).Assembly,

    typeof(GetSeanceByIdHandler).Assembly,
    typeof(CreateSeanceHandler).Assembly,
    typeof(UpdateSeanceHandler).Assembly,
    typeof(DeleteSeanceHandler).Assembly,

    typeof(GetAllEmploisQuery).Assembly,
    typeof(GetAllEmploiHandler).Assembly,
    typeof(GetEmploiByIdHandler).Assembly,
    typeof(CreateEmploiHandler).Assembly,
    typeof(UpdateEmploiHandler).Assembly,
    typeof(DeleteEmploiHandler).Assembly
));


// Register Repositories and Unit of Work
builder.Services.AddScoped<IAbsenceRepository, AbsenceRepository>();
builder.Services.AddScoped<ISeanceRepository, SeanceRepository>();
builder.Services.AddScoped<IFormateurRepository, FormateurRepository>();
builder.Services.AddScoped<IEmploiRepository, EmploiRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register services
builder.Services.AddScoped<FormateurService>();
builder.Services.AddScoped<ISecteurRepository, SecteurRepository>();
builder.Services.AddScoped<IUnitOfFormationRepository, UnitOfFormationRepository>();
builder.Services.AddScoped<IFiliereService, FiliereService>();
builder.Services.AddScoped<IUnitOfFormationService, UnitOfFormationService>();
builder.Services.AddScoped<IFiliereRepository, FiliereRepository>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); 

builder.Services.AddScoped<FiliereService>();

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SMS API",
        Description = "API for Gestion des Filières et des Formateurs",
    });
});

// Add Health Checks
builder.Services.AddHealthChecks()
    .AddCheck<FiliereDbContextHealthCheck>("FiliereDbContext_Health_Check");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMS API v1"));
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp"); // Use CORS policy
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();