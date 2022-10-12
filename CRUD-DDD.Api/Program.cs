using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using CRUD_DDD.Application.Books.Validators;
using System.Reflection;
using CRUD_DDD.Persistence.Extensions;
using Microsoft.OpenApi.Models;
using CRUD_DDD.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDatabaseServices(configuration);
builder.Services.AddRepository();

builder.Services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest)
    .AddFluentValidation(opt =>
    {
        opt.RegisterValidatorsFromAssembly(typeof(CreateBookValidator).GetTypeInfo().Assembly);
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD-DDD.Api", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
    options.SuppressInferBindingSourcesForParameters = false;
    options.SuppressConsumesConstraintForFormFileParameters = false;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD-DDD.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
