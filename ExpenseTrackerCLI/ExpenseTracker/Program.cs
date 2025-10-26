using ExpenseTracker;
using System;

class Program
{
    static void Main(string[] args)
    {

        ExpenseManager manager = new ExpenseManager();

        if (args.Length == 0)
        {
            Console.WriteLine("Expense Tracker CLI");
            Console.WriteLine("Usage:");
            Console.WriteLine("  add --description \"Lunch\" --amount 20");
            Console.WriteLine("  update --id 1 --description \"Dinner\" --amount 10");
            Console.WriteLine("  delete --id 2");
            Console.WriteLine("  list");
            Console.WriteLine("  summary");
            Console.WriteLine("  summary --month 8");
            return;

        }

        switch (args[0])
        {

            case "add":
                {
                    string desc = GetArgValue(args, "--description");
                    string amtStr = GetArgValue(args, "--amount");
                    if (desc != null && decimal.TryParse(amtStr, out decimal amt))
                        manager.AddExpense(desc, amt);
                    else
                        Console.WriteLine("Invalid add command.");
                    break;

                }

            case "update":
                {
                    string idStr = GetArgValue(args, "--id");
                    string desc = GetArgValue(args, "--description");
                    string amtStr = GetArgValue(args, "--amount");
                    if (int.TryParse(idStr, out int id) && desc != null && decimal.TryParse(amtStr, out decimal amt))
                        manager.UpdateExpense(id, desc, amt);
                    else
                        Console.WriteLine("Invalid update command.");
                    break;
                }

            case "delete":
                {
                    string idStr = GetArgValue(args, "--id");
                    if (int.TryParse(idStr, out int id))
                        manager.DeleteExpense(id);
                    else
                        Console.WriteLine("Invalid delete command.");
                    break;
                }

            case "list":
                {
                    manager.ListExpenses();
                    break;
                }

            case "summary":
                {
                    string monthStr = GetArgValue(args, "--month");
                    if (monthStr != null && int.TryParse(monthStr, out int month))
                        manager.MonthlySummary(month);
                    else
                        manager.Sumnary();
                    break;
                }
            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }

    // Helper method to parse arguments
    static string GetArgValue(string[] args, string name)
    {
        int i = Array.IndexOf(args, name);
        return (i >= 0 && i < args.Length - 1) ? args[i + 1] : null;
    }

}