using System;
using System.Collections.Generic;  // Needed for List<T>

class Program
{
    class TaskItem
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        
        public override string ToString()
        {
            string status = IsComplete ? "[✓]" : "[ ]";
            return $"{status} {Description}";
        }
    }

    static void Main(string[] args)
    {
        List<TaskItem> tasks = new List<TaskItem>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Task Manager ---");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Mark Task Complete");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Display tasks
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Your Tasks ---");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case 2:
                        Console.Write("Enter the task description: ");
                        string task = Console.ReadLine()?.Trim();
                        
                        if (string.IsNullOrEmpty(task))
                        {
                            Console.WriteLine("Error: Task cannot be empty.");
                        }
                        else
                        {
                            tasks.Add(new TaskItem { Description = task, IsComplete = false });
                            Console.WriteLine("✓ Task added successfully.");
                        }
                        break;

                    case 3:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available to complete.");
                            break;
                        }

                        Console.Write("Enter the task number to mark complete: ");
                        int taskNumber;
                        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                        {
                            if (tasks[taskNumber - 1].IsComplete)
                            {
                                Console.WriteLine("Task is already marked complete.");
                            }
                            else
                            {
                                tasks[taskNumber - 1].IsComplete = true;
                                Console.WriteLine("✓ Task marked as complete.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid task number.");
                        }
                        break;

                    case 4:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available to delete.");
                            break;
                        }

                        Console.Write("Enter the task number to delete: ");
                        int deleteNumber;
                        if (int.TryParse(Console.ReadLine(), out deleteNumber) && deleteNumber > 0 && deleteNumber <= tasks.Count)
                        {
                            string deletedTask = tasks[deleteNumber - 1].Description;
                            tasks.RemoveAt(deleteNumber - 1);
                            Console.WriteLine($"✓ Task '{deletedTask}' deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid task number.");
                        }
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option. Please enter 1-5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
    }
}
