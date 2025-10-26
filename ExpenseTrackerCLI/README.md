# Expense Tracker CLI

A simple Command-Line Interface (CLI) application for tracking your daily expenses. With this project, you can add, update, delete, and view your expenses directly from the terminal. Expenses are stored locally in an `expenses.json` file, making it easy to manage your personal finances.

> **Project inspired by the [Expense Tracker CLI project at roadmap.sh](https://roadmap.sh/projects/expense-tracker).**

---

## Features

- **Add Expenses:** Create new expenses with a description and amount.
- **Update Expenses:** Edit the description and amount of existing expenses.
- **Delete Expenses:** Remove expenses by their unique ID.
- **List Expenses:** View all recorded expenses.
- **Summary:** See the total amount of all expenses.
- **Monthly Summary:** See the total amount spent in a specific month of the current year.
- **Data Persistence:** All expenses are stored in a local JSON file (`expenses.json`).
- **No external dependencies:** Only .NET Standard Libraries are used.

---

## Usage

First, make sure you have [.NET 6 or higher](https://dotnet.microsoft.com/en-us/download) installed.

Open a terminal in the project directory and use the following commands:

```bash
# Add a new expense
dotnet run add --description "Lunch" --amount 20

# Update an expense
dotnet run update --id 1 --description "Dinner" --amount 10

# Delete an expense by ID
dotnet run delete --id 1

# List all expenses
dotnet run list

# View total summary of expenses
dotnet run summary

# View summary of expenses for a specific month (e.g., August)
dotnet run summary --month 8
