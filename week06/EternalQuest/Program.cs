// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Load();
        manager.ShowDailyReminder();

        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: manager.CreateGoal(); break;
                case 2: manager.ListGoals(); break;
                case 3: manager.RecordEvent(); break;
                case 4: manager.Save(); break;
                case 5: manager.Load(); break;
                case 6: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
