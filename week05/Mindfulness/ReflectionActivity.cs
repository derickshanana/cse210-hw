using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private HashSet<string> usedQuestions = new HashSet<string>();

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(5);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question;
            do
            {
                question = _questions[rand.Next(_questions.Count)];
            } while (usedQuestions.Contains(question) && usedQuestions.Count < _questions.Count);

            usedQuestions.Add(question);
            Console.WriteLine($"\n> {question}");
            ShowSpinner(5);
            elapsed += 6;
        }
    }
}
