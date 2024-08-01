using ApiNotes.Context;
using ApiNotes.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ApiNotes.Middlewares;
using ApiNotes.Logging;
using ApiNotes.Logging;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
        mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)
    ));

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information,
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //To avisando pro program.cs que estou fazendo o uso do Middle para tratamento de exceções
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
