using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Runtime.InteropServices.JavaScript;

namespace ExpenseTracker
{
    public class ExpenseManager
    {
        private const string FileName = "expenses.json";
        private List<ExpenseItem> expenses;

        public ExpenseManager()
        {
            expenses = LoadExpenses();

            if (!File.Exists(FileName))
                SaveExpenses();
        }

        // Load all expenses from JSON file
        private List<ExpenseItem> LoadExpenses()
        {
            if (!File.Exists(FileName))
                return new List<ExpenseItem>();

            string json = File.ReadAllText(FileName);
            var loaded = JsonSerializer.Deserialize<List<ExpenseItem>>(json);
            return loaded ?? new List<ExpenseItem>();
        }

        // Save all expenses to JSON file
        private void SaveExpenses()
        {
            string json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        // Add a new expense
        public void AddExpense(string description, decimal amount)
        {
            int newId = expenses.Count > 0 ? expenses.Last().Id + 1 : 1;
            ExpenseItem expense = new ExpenseItem(newId, DateTime.Now, description, amount);
            expenses.Add(expense);
            SaveExpenses();
            Console.WriteLine($"Expense added successfully (Id: {newId}");
        }

        // Update an existing expense
        public void UpdateExpense(int id, string newDescription, decimal newAmount)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                Console.WriteLine("Expense not found.");
                return;
            }
            expense.Description = newDescription;
            expense.Amount = newAmount;
            SaveExpenses();
            Console.WriteLine("Expense updated successfully.");
        }

        // Delete an expense
        public void DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                Console.WriteLine("Expense not founb");
                return;
            }
            expenses.Remove(expense);
            SaveExpenses();
            Console.WriteLine("Expense deleted successfully.");
        }

        // List all expenses
        public void ListExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses found.");
                return;
            }
            Console.WriteLine("ID  Date        Description           Amount");
            foreach (var e in expenses)
            {
                Console.WriteLine($"{e.Id,-3} {e.Date:yyyy-MM-dd}  {e.Description,-20} {e.Amount,8:C}");
            }
        }

        // Show summary (total) of all expenses
        public void Sumnary()
        {
            decimal total = expenses.Sum(e => e.Amount);
            Console.WriteLine($"Total expenses: {total:C}");
        }

        // Show summary for a specific month (of current year)
        public void MonthlySummary(int month)
        {
            int year = DateTime.Now.Year;
            decimal monthlyTotal = expenses.Where(e=> e.Date.Month == month && e.Date.Year ==year).Sum(e=> e.Amount);

            string monthName = new DateTime(year, month, 1).ToString("MMMM");
            Console.WriteLine($"Total expenses for {monthlyTotal:C}");            
        }
    }
}
