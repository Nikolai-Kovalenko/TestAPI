using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Migrations;
using WebAPICore.Api;
using WebAPICore.Data.Context;
using WebAPICore.Data.Models;
using WebAPICore.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebAPICoreContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

//IoCContainer.Register<IHistoryRepository<Customer>, CustomerRepository>();
//IoCContainer.Register<IHistoryRepository<CurrentWeather>, WeatherRepository>();

builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<CurrentWeather>, WeatherRepository>();

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
