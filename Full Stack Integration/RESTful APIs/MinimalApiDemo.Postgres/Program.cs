using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Postgres.Data;
using MinimalApiDemo.Postgres.Endpoints;
using MinimalApiDemo.Postgres.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TaskService>();


var app = builder.Build();

Console.WriteLine("Environment: " + builder.Environment.EnvironmentName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapTaskEndpoints();  //TaskService is injected automatically here, separation of concerns into separate files


app.Run();