using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class TaskItem
{
    public int Id;
    public string Title;
    public string Priority;
    public string Category;
    public string DueDate;
    public bool Completed;

    public TaskItem(int id, string title, string priority, string category, string dueDate)
    {
        Id = id;
        Title = title;
        Priority = priority;
        Category = category;
        DueDate = dueDate;
        Completed = false;
    }
}

class TaskManager
{
    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasksFromFile();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== TASK MANAGER =====");
            Console.ResetColor();

            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task Complete");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Search Task");
            Console.WriteLine("6. Edit Task");
            Console.WriteLine("7. Show Statistics");
            Console.WriteLine("8. Sort Tasks by Priority");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a number.");
                Console.ResetColor();
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;

                case 2:
                    ViewTasks();
                    break;

                case 3:
                    MarkTaskComplete();
                    break;

                case 4:
                    DeleteTask();
                    break;

                case 5:
                    SearchTask();
                    break;

                case 6:
                    EditTask();
                    break;

                case 7:
                    ShowStatistics();
                    break;

                case 8:
                    SortTasksByPriority();
                    break;

                case 9:
                    SaveTasksToFile();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tasks saved successfully. Exiting...");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice!");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter Task ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        foreach (TaskItem t in tasks)
        {
            if (t.Id == id)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task ID already exists!");
                Console.ResetColor();
                return;
            }
        }

        Console.Write("Enter Task Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Priority (High/Medium/Low): ");
        string priority = Console.ReadLine();

        Console.Write("Enter Category: ");
        string category = Console.ReadLine();

        Console.Write("Enter Due Date: ");
        string dueDate = Console.ReadLine();

        TaskItem newTask = new TaskItem(id, title, priority, category, dueDate);
        tasks.Add(newTask);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task Added Successfully!");
        Console.ResetColor();
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No Tasks Available!");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n===== TASK LIST =====");
        Console.ResetColor();

        foreach (TaskItem t in tasks)
        {
            if (t.Priority.ToLower() == "high")
                Console.ForegroundColor = ConsoleColor.Red;
            else if (t.Priority.ToLower() == "medium")
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"ID: {t.Id}");
            Console.WriteLine($"Title: {t.Title}");
            Console.WriteLine($"Priority: {t.Priority}");
            Console.WriteLine($"Category: {t.Category}");
            Console.WriteLine($"Due Date: {t.DueDate}");
            Console.WriteLine($"Status: {(t.Completed ? "Completed" : "Pending")}");
            Console.WriteLine("--------------------------");

            Console.ResetColor();
        }
    }

    static void MarkTaskComplete()
    {
        Console.Write("Enter Task ID to mark complete: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        foreach (TaskItem t in tasks)
        {
            if (t.Id == id)
            {
                t.Completed = true;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task Marked as Completed!");
                Console.ResetColor();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task Not Found!");
        Console.ResetColor();
    }

    static void DeleteTask()
    {
        Console.Write("Enter Task ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                tasks.RemoveAt(i);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task Deleted Successfully!");
                Console.ResetColor();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task Not Found!");
        Console.ResetColor();
    }

    static void SearchTask()
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine().ToLower();

        bool found = false;

        foreach (TaskItem t in tasks)
        {
            if (t.Title.ToLower().Contains(keyword) ||
                t.Category.ToLower().Contains(keyword))
            {
                Console.WriteLine($"Found Task -> ID: {t.Id}, Title: {t.Title}");
                found = true;
            }
        }

        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No matching tasks found!");
            Console.ResetColor();
        }
    }

    static void EditTask()
    {
        Console.Write("Enter Task ID to edit: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        foreach (TaskItem t in tasks)
        {
            if (t.Id == id)
            {
                Console.Write("Enter New Title: ");
                t.Title = Console.ReadLine();

                Console.Write("Enter New Priority: ");
                t.Priority = Console.ReadLine();

                Console.Write("Enter New Category: ");
                t.Category = Console.ReadLine();

                Console.Write("Enter New Due Date: ");
                t.DueDate = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task Updated Successfully!");
                Console.ResetColor();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task Not Found!");
        Console.ResetColor();
    }

    static void ShowStatistics()
    {
        int completedCount = 0;
        int pendingCount = 0;
        int highPriorityCount = 0;

        foreach (TaskItem t in tasks)
        {
            if (t.Completed)
                completedCount++;
            else
                pendingCount++;

            if (t.Priority.ToLower() == "high")
                highPriorityCount++;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n===== TASK STATISTICS =====");
        Console.ResetColor();

        Console.WriteLine($"Total Tasks: {tasks.Count}");
        Console.WriteLine($"Completed Tasks: {completedCount}");
        Console.WriteLine($"Pending Tasks: {pendingCount}");
        Console.WriteLine($"High Priority Tasks: {highPriorityCount}");
    }

    static void SortTasksByPriority()
    {
        tasks = tasks.OrderBy(t =>
        {
            if (t.Priority.ToLower() == "high")
                return 1;

            if (t.Priority.ToLower() == "medium")
                return 2;

            return 3;
        }).ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tasks Sorted by Priority!");
        Console.ResetColor();
    }

    static void SaveTasksToFile()
    {
        StreamWriter writer = new StreamWriter(filePath);

        foreach (TaskItem t in tasks)
        {
            writer.WriteLine($"{t.Id}|{t.Title}|{t.Priority}|{t.Category}|{t.DueDate}|{t.Completed}");
        }

        writer.Close();
    }

    static void LoadTasksFromFile()
    {
        if (!File.Exists(filePath))
            return;

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split('|');

            if (data.Length == 6)
            {
                TaskItem task = new TaskItem(
                    int.Parse(data[0]),
                    data[1],
                    data[2],
                    data[3],
                    data[4]
                );

                task.Completed = bool.Parse(data[5]);

                tasks.Add(task);
            }
        }
    }
}
