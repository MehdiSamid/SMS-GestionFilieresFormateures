using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MediatR;
using SMS.Application.Mapping;
using SMS.Application.Services;
using System.Reflection;
using System;
using System.IO;
using SMS.Application.Mapping.SMS.Application.Mapping;
using SMS.Infrastructure.HealthChecks;
using SMS.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext
// Configure DbContext with SQL Server
builder.Services.AddDbContext<FiliereDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SMS.Infrastructure")));
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Register Application Services
builder.Services.AddScoped<FormateurService>();

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

    // Uncomment this section if you have XML documentation file
    // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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

// Add Health Check endpoint
app.MapHealthChecks("/health");

ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _Db = scope.ServiceProvider.GetRequiredService<FiliereDbContext>();
        if (_Db != null)
        {
            if (_Db.Database.GetPendingMigrations().Any())
            {
                _Db.Database.Migrate();
            }
        }
    }
}
