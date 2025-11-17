using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaWebAPI.Infrastructure.Context;
using PruebaWebAPI.Infrastructure.Dapper;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Connection");

// Register EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// MediatR
builder.Services.AddMediatR(typeof(Program));

// Register Dapper repository
builder.Services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
