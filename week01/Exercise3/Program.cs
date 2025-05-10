using System;

class Program
{
    static void Main()
    {
        // Welcome message
        Console.WriteLine("Welcome to 'Guess My Number' game!");
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate random magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            // Game loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if user wants to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
            Console.WriteLine(); // Blank line between games
        }

        Console.WriteLine("Thanks for playing! Goodbye, Derick Shanana!");
    }
}
