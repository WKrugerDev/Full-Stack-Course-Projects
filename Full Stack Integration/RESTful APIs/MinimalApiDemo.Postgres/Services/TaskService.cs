using MinimalApiDemo.Postgres.Models;
using MinimalApiDemo.Postgres.Data;

namespace MinimalApiDemo.Postgres.Services;
public class TaskService
{
    private readonly TaskDbContext _context;

    public TaskService(TaskDbContext context)
    {
        _context = context;
    }

    public List<TaskItem> GetAllTasks() => _context.Tasks.ToList();

    public TaskItem? GetTaskById(int id) => _context.Tasks.Find(id);

    public void CreateTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public TaskItem? UpdateTask(int id, TaskItem task)
    {
        var existing = _context.Tasks.Find(id);
        if (existing == null) return null;

        existing.Name = task.Name;
        existing.IsCompleted = task.IsCompleted;
        _context.SaveChanges();
        return existing;
    }

    public bool DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return true;
    }
}
