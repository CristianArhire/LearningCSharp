# Number Guessing Game CLI

A simple Command-Line Interface (CLI) game where the computer randomly selects a number and you have to guess it!  
You can select the difficulty level, and the game tracks your high scores locally.  
Numbers are randomly generated, and you get hints after each guess.  
You can play as many rounds as you want!

> **Project inspired by the [Number Guessing Game project at roadmap.sh](https://roadmap.sh/projects/number-guessing-game).**

---

## Features

- **Difficulty Levels:** Choose between Easy (10 tries), Medium (5 tries), or Hard (3 tries).
- **Random Number Generation:** The computer selects a number between 1 and 100.
- **Hints:** Get hints whether the target number is higher or lower after every guess.
- **Play Again:** Play multiple rounds until you decide to quit.
- **High Score Tracking:** Your fewest attempts per difficulty level are saved locally.
- **No external dependencies:** Only .NET Standard Libraries are used.

---

## Usage

First, make sure you have [.NET 6 or higher](https://dotnet.microsoft.com/en-us/download) installed.

Open a terminal in the project directory and use the following command to start the game:

```bash
dotnet run
