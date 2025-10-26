using System;

class Program
{

    static int easyHighScore = int.MaxValue;
    static int mediumHighScore = int.MaxValue;
    static int hardHighScore = int.MaxValue;


    static void Main(string[] args)
    {

        bool playAgain = true;

        while (playAgain)
        {

            Console.Clear();
            Console.WriteLine("==== Number Guessing Game  ====");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Wiew High Score");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose an option: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    PlayGame();
                    break;
                case "2":
                    ShowHighScores();
                    break;
                case "3":
                    playAgain = false;
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Entere to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void PlayGame()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        Console.WriteLine("Choose difficulty:");
        Console.WriteLine("1. Easy (10 chances)");
        Console.WriteLine("2. Medium (5 chances)");
        Console.WriteLine("3. Hard (3 chances)");
        Console.WriteLine("Enter your choice: ");

        int maxAttempts = 5;
        int difficulty = 2;

        if (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
        {
            Console.WriteLine("Invalid difficulty. Defaulting to Medium");
            difficulty = 2;
        }

        switch (difficulty)
        {
            case 1: maxAttempts = 10; break;
            case 2: maxAttempts = 5; break;
            case 3: maxAttempts = 3; break;


        }

        Random rand = new Random();
        int secretNumber = rand.Next(1, 101);
        int attempts = 0;
        bool guessedCorrectly = false;

        Console.WriteLine($"Great! You have {maxAttempts} attempts");

        while (attempts < maxAttempts)
        {
            Console.WriteLine($"\nEnter your guess ({attempts + 1}/{maxAttempts}): ");
            string input = Console.ReadLine();
            int guess;

            if (!int.TryParse(input, out guess) || guess < 1 || guess > 100)
            {
                Console.WriteLine("Please enter a invalid number between 1 and 100.");
                continue;
            }

            attempts++;

            if (guess == secretNumber)
            {
                Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} attempts.");

                UpdateHighScore(difficulty, attempts);

                guessedCorrectly = true;
                break;
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Incorrect! The number is greater than your guess.");
            }
            else
            {
                Console.WriteLine("Incorrect! The number is less than your guess.");
            }
        }

        if (!guessedCorrectly)
        {
            Console.WriteLine($"\nSorry, you've run out of attempts. The correct number was {secretNumber}.");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    static void ShowHighScores()
    {
        Console.Clear();
        Console.WriteLine("==== High Scores ====");
        Console.WriteLine("Easy:   {0}", easyHighScore == int.MaxValue ? "-" : easyHighScore.ToString());
        Console.WriteLine("Medium: {0}", mediumHighScore == int.MaxValue ? "-" : mediumHighScore.ToString());
        Console.WriteLine("Hard:   {0}", hardHighScore == int.MaxValue ? "-" : hardHighScore.ToString());
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    static void UpdateHighScore(int difficulty, int attempts)
    {
        switch (difficulty)
        {
            case 1:
                if (attempts < easyHighScore)
                {
                    easyHighScore = attempts;
                    Console.WriteLine("New Easy mode high score!");
                }
                break;
            case 2:
                if (attempts < mediumHighScore)
                {
                    mediumHighScore = attempts;
                    Console.WriteLine("New Medium mode high score!");
                }
                break;
            case 3:
                if (attempts < hardHighScore)
                {
                    hardHighScore = attempts;
                    Console.WriteLine("New Hard mode high score!");
                }
                break;
        }
    }

}