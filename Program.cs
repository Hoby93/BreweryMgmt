using BreweryManagementAPI.Infrastructure.Persistence;
using BreweryManagementAPI.Application.Services;
using BreweryManagementAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure PostgreSQL database context
builder.Services.AddDbContext<BreweryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Ajoutez les services nécessaires au conteneur d'injection de dépendances
builder.Services.AddScoped<IBreweryRepository, BreweryRepository>(); 
builder.Services.AddScoped<IBeerRepository, BeerRepository>(); 
builder.Services.AddScoped<IWholesalerRepository, WholesalerRepository>();  
builder.Services.AddScoped<IOrderRepository, OrderRepository>();  
builder.Services.AddScoped<BeerService>();  // Enregistrement du service BeerService
builder.Services.AddScoped<BreweryService>();  // Enregistrement du service BreweryService
builder.Services.AddScoped<WholesalerService>();  // Enregistrement du service WholesalerService


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
