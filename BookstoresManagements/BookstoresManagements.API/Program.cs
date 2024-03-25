using BookstoresManagements.DataAccess;
using Microsoft.EntityFrameworkCore;
using BookstoresManagements.Reponsitory;
using BookstoresManagements.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add ConnectionStrings

builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BookstoresManagements.API")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Service DependencyInjection
builder.Services.AddInfrastructure(configuration);
builder.Services.AddServiceConfigure(configuration);
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
