using Carter;
using FluentValidation;
using InvBG.Contacts.Backend.Infrastructure;
using InvBG.Contacts.Backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors()
    .AddRouting()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCarter()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
    .AddValidatorsFromAssemblyContaining<Program>()
    .AddContactsStore(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandlingMiddleware()
     .UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader())
    .UseRouting()
    .UseSwagger()
    .UseSwaggerUI()
    .ConfigureWarehouse();

app.MapCarter();

app.Map("/", () => { return "Hello from Contacts"; });

app.Run();

