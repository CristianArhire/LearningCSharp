using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class TaskManager
{

    private const string FileName = "tasks.json";
    private List<TaskItem> tasks = new List<TaskItem>();


    public TaskManager()
    {
        tasks = LoadTask();
    }

    private List<TaskItem> LoadTask()
    {

        if (!File.Exists(FileName))

            return new List<TaskItem>();
        string json = File.ReadAllText(FileName);
        List<TaskItem> loadedTask = JsonSerializer.Deserialize<List<TaskItem>>(json);
        if (loadedTask == null) loadedTask = new List<TaskItem>();
        return loadedTask;
    }

    private void SaveTasks()
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);

    }

    public void AddTask(string descritpion)
    {

        int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1;
        TaskItem newTask = new TaskItem(newId, descritpion);
        tasks.Add(newTask);
        SaveTasks();
        Console.WriteLine($"Tarea agregada (ID: {newId})");

    }


    public void ListTasks(string status = null)
    {
        List<TaskItem> filteredTasks = status == null ? tasks : tasks.FindAll(t => t.Status == status);

        if (filteredTasks.Count == 0)
        {
            Console.WriteLine("No hay tareas");
            return;
        }
        foreach (TaskItem task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.Id} | {task.Description} | Estado: {task.Status} | Creada: {task.CreatedAt} | Última actualización: {task.UpdatedAt}");
        }
    }

    public void UpdateTask(int id, string newDescription)
    {
        TaskItem task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("No existe esa tarea.");
            return;

        }
        task.Description = newDescription;
        task.UpdatedAt = DateTime.Now;
        SaveTasks();
        Console.WriteLine("Tarea actualizada.");
    }

    public void DeleteTask(int id)
    {

        TaskItem task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("No existe esa tarea.");
            return;


        }
        tasks.Remove(task);
        SaveTasks();
        Console.WriteLine("Tarea eliminada.");
    }

    public void MarkInProgress(int id)
    {
        TaskItem task = tasks.Find(task => task.Id == id);
        if (task == null)
        {
            Console.WriteLine("No existe esa tarea.");
            return;
        }
        task.Status = "in-progress";
        task.UpdatedAt = DateTime.Now;
        SaveTasks();
        Console.WriteLine("Tarea marcada como en progreso.");
    }

    public void markDone(int id)
    {

        TaskItem task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("No exixste esa tarea.");
            return;
        }
        task.Status = "done";
        task.UpdatedAt = DateTime.Now;
        SaveTasks();
        Console.WriteLine("Tarea marcada como completada.");

    }



}
