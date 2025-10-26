using System;

class Program
{

    static void Main(string[] args)
    {

        TaskManager manager = new TaskManager();

        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, introduce un comando (add/list/update/delete/mark-in-progress/mark-done).");
            return;
        }
        string command = args[0];


        switch (command)
        {

            case "add":
                if (args.Length < 2)
                    Console.WriteLine("Debes indicar la descripción de la tarea.");
                else
                    manager.AddTask(args[1]);
                break;

            case "list":
                if (args.Length == 2)
                    manager.ListTasks(args[1]);
                else
                    manager.ListTasks();
                break;

            case "update":
                if (args.Length < 3)
                    Console.WriteLine("Debes indicar ID y nueva descripción.");
                else if (int.TryParse(args[1], out int idU))
                    manager.UpdateTask(idU, args[2]);
                else
                    Console.WriteLine("ID inválido.");
                break;

            case "delete":
                if (args.Length < 2)
                    Console.WriteLine("Debes indicar el ID de la tarea.");
                else if (int.TryParse(args[1], out int idD))
                    manager.DeleteTask(idD);
                else
                    Console.WriteLine("ID inválido.");
                break;

            case "mark-in-progress":
                if (args.Length < 2)
                    Console.WriteLine("Debes indicar el ID de la tarea.");
                else if (int.TryParse(args[1], out int idP))
                    manager.MarkInProgress(idP);
                else
                    Console.WriteLine("ID inválido.");
                break;

            case "mark-done":
                if (args.Length < 2)
                    Console.WriteLine("Debes indicar el ID de la tarea.");
                else if (int.TryParse(args[1], out int idM))
                    manager.markDone(idM);
                else
                    Console.WriteLine("ID inválido.");
                break;

            default:
                Console.WriteLine("Comando desconocido.");
                break;



        }

    }


}
