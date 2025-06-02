using System;
using System.IO;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private static int sessionCount = 0;

    public void Start()
    {
        Console.Clear();
        DisplayStartMessage();
        Thread.Sleep(2000);
        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
        RunActivity();
        DisplayEndMessage();
        LogActivity();
    }

    private void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void LogActivity()
    {
        sessionCount++;
        File.AppendAllText("activity_log.txt", $"{DateTime.Now}: {_name} for {_duration} seconds. Session #{sessionCount}\n");
    }

    protected abstract void RunActivity();
}
