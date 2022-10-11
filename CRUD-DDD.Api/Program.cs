using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using CRUD_DDD.Application.Books.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest)
    .AddFluentValidation(opt =>
    {
        opt.RegisterValidatorsFromAssembly(typeof(CreateBookValidator).GetTypeInfo().Assembly);
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
