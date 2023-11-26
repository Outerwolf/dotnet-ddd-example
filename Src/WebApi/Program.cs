using Security.Auth.Infrastructure.DependencyInjection;
using WebApi.Extension.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Configuration.AddJsonFile("appsettings.Development.json",
    optional: true,
    reloadOnChange: true);

builder.Services.AddSecurityAuthApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSecurityAuthApplication();
builder.Services.AddSecurityAuthInfrastructure(config);
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