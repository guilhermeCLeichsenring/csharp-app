using CSharp_App.Interfaces;
using CSharp_App.Models;
using CSharp_App.Repository;
using CSharp_App.Repository.Context;
using CSharp_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Conexão com o Banco de Dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<RepositoryPatternContext>(options =>
{
    options.UseOracle(connectionString).EnableSensitiveDataLogging(true);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

// Injeção de dependência
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMvc(); //add for swagger

builder.Services.AddEndpointsApiExplorer();//add for swagger
builder.Services.AddSwaggerGen();//add for swagger


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //add for swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
    });
}




// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();



// minimal API

app.MapGet("/Product/{id}", ([FromRoute] int id, [FromServices] IRepository<ProductModel> product) =>
{
    ProductService service = new ProductService(product);

    return Results.Ok(service.GetProductById(id));
});

app.MapGet("/Product", ( [FromServices] IRepository<ProductModel> product) =>
{
    ProductService service = new ProductService(product);

    return Results.Ok(service.GetAllProducts());
});

app.MapPost("/Product", ([FromBody] ProductModel model, [FromServices] IRepository<ProductModel> product) =>
{
    ProductService service = new ProductService(product);

    service.AddProduct(model);

    return Results.Created($"/products/{model.Id}", model.Id);
});





app.Run();

