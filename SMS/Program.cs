//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using AutoMapper;
//using MediatR;
//using SMS.Application.Mapping;
//using SMS.Application.Services;
//using System.Reflection;
//using SMS.Application.Commands.Absences;
//using SMS.Domain.Interfaces;
//using SMS.Infrastructure.Repositories;
//using SMS.Infrastructure;
//using SMS.Application.Handlers.Absences;
//using SMS.Infrastructure.HealthChecks;
//using SMS.Application.Handlers;
//using SMS.Application.Mapping.SMS.Application.Mapping;
//using SMS.Application.Queries.Absence;
//using SMS.Application.Queries.Absences;
//using SMS.Application.Queries.Seances;
//using SMS.Application.Handlers.Seances;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// Configure DbContext with SQL Server
//builder.Services.AddDbContext<FiliereDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        b => b.MigrationsAssembly("SMS.Infrastructure")));

//// Register AutoMapper
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//// Register MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
//    Assembly.GetExecutingAssembly(),
//    typeof(GetAllAbsencesQuery).Assembly,
//    typeof(GetAllAbsencesHandler).Assembly
//));

//// Register Repositories and Unit of Work
//builder.Services.AddScoped<IAbsenceRepository, AbsenceRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

////---------------

//// Register MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
//    Assembly.GetExecutingAssembly(),
//    typeof(GetAllSeanceQuery).Assembly,
//    typeof(GetAllSeanceHandler).Assembly
//));

//// Register Repositories and Unit of Work
//builder.Services.AddScoped<ISeanceRepository, SeanceRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



//// Register Application Services
//builder.Services.AddScoped<FormateurService>();

//// Enable Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "SMS API",
//        Description = "API for Gestion des Filières et des Formateurs",
//    });
//});

//// Add Health Checks
//builder.Services.AddHealthChecks()
//    .AddCheck<FiliereDbContextHealthCheck>("FiliereDbContext_Health_Check");

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMS API v1"));
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.MapHealthChecks("/health");
//app.Run();


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
using SMS.Application.Handlers.Absences;
using SMS.Application.Handlers.Seances;
using SMS.Application.Queries.Absences;
using SMS.Application.Queries.Seances;
using SMS.Application.Handlers;
using SMS.Application.Mapping.SMS.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<FiliereDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SMS.Infrastructure")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(GetAllAbsencesQuery).Assembly,
    typeof(GetAllAbsencesHandler).Assembly,
    typeof(GetAllSeanceQuery).Assembly,
    typeof(GetAllSeanceHandler).Assembly
));

// Register Repositories and Unit of Work
builder.Services.AddScoped<IAbsenceRepository, AbsenceRepository>();
builder.Services.AddScoped<ISeanceRepository, SeanceRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Application Services
builder.Services.AddScoped<FormateurService>();
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
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();

