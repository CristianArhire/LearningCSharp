# Task Tracker CLI

A simple Command-Line Interface (CLI) application for managing your daily tasks. This project allows you to add, update, delete, and list your tasks from the terminal. Tasks are saved locally in a `tasks.json` file, making it easy to keep track of your to-do list.

---

## Features

- **Add Tasks**: Create new tasks with a description.
- **Update Tasks**: Change the description of an existing task.
- **Delete Tasks**: Remove tasks by their unique ID.
- **Task Status Management**: Mark tasks as `todo`, `in-progress`, or `done`.
- **List Tasks**: View all tasks or filter by their status.
- **Data Persistence**: All tasks are stored in a local JSON file (`tasks.json`).
- **No external dependencies**: Only .NET Standard Libraries are used.

> **Project inspired by the [Task Tracker CLI project at roadmap.sh](https://roadmap.sh/projects/task-tracker).**

---

## Usage

First, make sure you have [.NET 6 or higher](https://dotnet.microsoft.com/en-us/download) installed.

Open a terminal in the project directory and use the following commands:

```bash
# Add a new task
dotnet run add "Buy groceries"

# List all tasks
dotnet run list

# List all completed tasks
dotnet run list done

# List all tasks in progress
dotnet run list in-progress

# Update the description of a task (example: task ID 1)
dotnet run update 1 "Buy groceries and cook dinner"

# Delete a task by ID (example: task ID 1)
dotnet run delete 1

# Mark a task as in progress
dotnet run mark-in-progress 1

# Mark a task as done
dotnet run mark-done 1
