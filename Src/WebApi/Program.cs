using Security.Auth.Infrastructure.DependencyInjection;
using WebApi.Extension.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Configuration.AddJsonFile("appsettings.Development.json",
    optional: true,
    reloadOnChange: true);
// Add services to the container.

builder.Services.AddSecurityAuthApi();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSecurityAuthApplication();
builder.Services.AddSecurityAuthInfrastructure(config);

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