using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (plus or minus), if applicable
        int lastDigit = grade % 10;

        if (letter != "A" && letter != "F") // A+ and F+/F- do not exist
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && grade < 93) // A- for grades 90-92
        {
            sign = "-";
        }

        // Display the final letter grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine pass/fail
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time! Keep working hard.");
        }
    }
}
