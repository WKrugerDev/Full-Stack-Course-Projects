using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//In-memory list to store tasks
List<TaskItem> tasks = new List<TaskItem>();

//Get all tasks
app.MapGet("/tasks", () => Results.Ok(tasks));

//Get specific task by ID
app.MapGet("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if(task == null) return Results.NotFound();

    return Results.Ok(task);
});

//Adding task
app.MapPost("/tasks", (TaskItem task) =>
{
    tasks.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

//PUT - Update task
app.MapPut("/tasks/{id}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if(task == null) return Results.NotFound();

    task.Name = updatedTask.Name;
    task.isCompleted = updatedTask.isCompleted;
    return Results.Ok(task);
});

app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if(task == null) return Results.NotFound();

    tasks.Remove(task);
    return Results.Ok(task);
});

app.Run();


public class TaskItem
{
    public int Id {get ; set; }
    public string Name {get ; set; } = string.Empty;
    public bool isCompleted {get ; set ;}
}