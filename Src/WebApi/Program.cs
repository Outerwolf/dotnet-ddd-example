using System.Reflection;
using MediatR;
using Security.Auth.API.Extension;
using Security.Auth.Application;
using Security.Auth.Application.RegisterUser;
using Security.Auth.Infrastructure.DependencyInjection;
using WebApi;
using WebApi.Extension.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSecurityAuthApi();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSecurityAuthApplication();
builder.Services.AddSecurityAuthInfrastructure();

// builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

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