using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Application.Services;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Controladores agregados
builder.Services.AddControllers();


// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// instalacion swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ----------------------- Inyeccion de repositorios y servicios -----------------------
// Inyeccion de repositorios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderdetailRepository, OrderdetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Inyeccion de servicios
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderdetailService, OrderdetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // uso de swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // ← Esto hace que Swagger esté en "/"
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers(); //necesario para swagger

// ------------------------- Correr app -------------------------
app.Run();
