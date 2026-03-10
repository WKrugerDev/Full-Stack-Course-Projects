using MinimalApiDemo.Postgres.Services;
using MinimalApiDemo.Postgres.Models;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiDemo.Postgres.Endpoints
{
    public static class TaskEndpoints
    {

        public static void MapTaskEndpoints(this WebApplication app)
        {
            // Get all tasks
            app.MapGet("/tasks", ([FromServices] TaskService service) => service.GetAllTasks());

            // Get task by Id
            app.MapGet("/tasks/{id}", ([FromServices] TaskService service, int id) =>
            {
                var task = service.GetTaskById(id);
                return task is not null ? Results.Ok(task) : Results.NotFound();
            });

            // Create task
            app.MapPost("/tasks", ([FromServices] TaskService service, TaskItem task) =>
            {
                service.CreateTask(task);
                return Results.Created($"/tasks/{task.Id}", task);
            });

            // Update task
            app.MapPut("/tasks/{id}", ([FromServices] TaskService service, int id, TaskItem task) =>
            {
                var updated = service.UpdateTask(id, task);
                return updated is not null ? Results.Ok(updated) : Results.NotFound();
            });

            // Delete task
            app.MapDelete("/tasks/{id}", ([FromServices] TaskService service, int id) =>
            {
                var deleted = service.DeleteTask(id);
                return deleted ? Results.Ok() : Results.NotFound();
            });
        }
    }
}
