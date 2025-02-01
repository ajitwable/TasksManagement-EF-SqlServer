using TasksManagement.Context;
using Microsoft.EntityFrameworkCore;
using TasksManagement.AutoMapper;
using TasksManagement.Interface;
using TasksManagement.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("connString") 
                            ?? throw new InvalidOperationException("Connection string 'connString' is not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var services = builder.Services;
var env = builder.Environment;

services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ITasks, TaskRepository>();

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


