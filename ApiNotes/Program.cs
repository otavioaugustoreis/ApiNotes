using ApiNotes.Context;
using ApiNotes.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ApiNotes.Middlewares;
using ApiNotes.Logging;
using ApiNotes.Logging;
using ApiNotes.Interfaces;
//using ApiNotes.Config;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurando injeção de dependência
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped(typeof(ICrud<>), typeof(Repository<>));
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<INote, NoteService>();
builder.Services.AddScoped<IPaths, PathsService>();
//Serviço da UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Configurando conexão com banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
        mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)
    ));



//Configurando para ver se está em ambiente de teste
/* var environment = builder.Environment;

builder.Configuration
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (environment.IsEnvironment("Test"))
{
    builder.Services.AddHostedService<TestDataSeeder>();
}
*/
//Configurando o log
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

//Redireciona os request HTTP para HTTPS
app.UseHttpsRedirection();
//Configura autorização da nossa aplicação
app.UseAuthorization();
//Mapeia os Controllers, mostra como mapeia  que no caso é os endpointas
app.MapControllers();
//Inicia a aplicação
app.Run();
