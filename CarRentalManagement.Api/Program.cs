using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Mapping;
using CarRentalManagement.Api.Middleware;
using CarRentalManagement.Api.Repositories;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbcontextClass Injection
builder.Services.AddDbContext<CarRentalDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalConnectionString")));

// Repository Injection
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Global Exception Middleware
app.ConfigureExceptionMiddleware();

app.MapControllers();

app.Run();
