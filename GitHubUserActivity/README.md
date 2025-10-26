# GitHub User Activity 

A simple Command-Line Interface (CLI) application that fetches and displays the recent public activity of any GitHub user. Enter a GitHub username and instantly view events like commits, issues, pull requests, and more—directly from your terminal.

---

## Features

- **User Activity Lookup:** Fetch the recent public activity of any GitHub user.
- **Events Supported:** See commits (pushes), issues, pull requests, forks, and stars.
- **Easy to Use:** Just run, enter a username, and see results!
- **Error Handling:** Gracefully handles invalid users or users with no public events.
- **No external dependencies:** Only .NET Standard Libraries are used.
- **Clear Output:** Events are shown with dates and event type.

> **Project inspired by the [GitHub User Activity  project at roadmap.sh](https://roadmap.sh/projects/github-user-activity).**

---

## Usage

First, make sure you have [.NET 6 or higher](https://dotnet.microsoft.com/en-us/download) installed.

Open a terminal in the project directory and use the following commands:

```bash
# Run the app (interactive mode)
dotnet run

# When prompted, enter a GitHub username:
# Example:
# > CristianArhire

# (Optional) If the app accepts a username as an argument:
dotnet run CristianArhire
