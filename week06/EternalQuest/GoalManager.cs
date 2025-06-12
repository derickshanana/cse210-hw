// GoalManager.cs
class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;
    private DateTime lastReminderDate = DateTime.MinValue;

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1. Simple 2. Eternal 3. Checklist 4. Negative");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points (or penalty for negative): ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;
        switch (type)
        {
            case 1: goal = new SimpleGoal(name, desc, points); break;
            case 2: goal = new EternalGoal(name, desc, points); break;
            case 3:
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, desc, points, target, bonus);
                break;
            case 4: goal = new NegativeGoal(name, desc, points); break;
        }

        if (goal != null) goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
        Console.WriteLine($"Score: {score} | Level: {score / 1000}");
        Console.WriteLine(GetBadge());
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int pointsEarned = goals[index].RecordEvent();
            if (new Random().Next(1, 6) == 3) // 20% chance
            {
                Console.WriteLine("🎉 Bonus! You earned 50 extra points!");
                pointsEarned += 50;
            }
            score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
    }

    public void Save()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(score);
            foreach (var goal in goals)
            {
                sw.WriteLine(goal.GetSaveString());
            }
        }
        File.WriteAllText("last_reminder.txt", DateTime.Now.ToString());
    }

    public void Load()
    {
        if (!File.Exists("goals.txt")) return;

        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            Goal goal = type switch
            {
                "SimpleGoal" => new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])),
                "EternalGoal" => new EternalGoal(data[0], data[1], int.Parse(data[2])),
                "ChecklistGoal" => new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])),
                "NegativeGoal" => new NegativeGoal(data[0], data[1], int.Parse(data[2])),
                _ => null
            };
            if (goal != null) goals.Add(goal);
        }

        if (File.Exists("last_reminder.txt"))
            DateTime.TryParse(File.ReadAllText("last_reminder.txt"), out lastReminderDate);
    }

    public void ShowDailyReminder()
    {
        if (lastReminderDate.Date != DateTime.Now.Date)
        {
            Console.WriteLine("🌟 Remember to work on your Eternal Quest goals today!");
        }
    }

    private string GetBadge()
    {
        if (score >= 10000) return "🏆 Master Badge";
        if (score >= 5000) return "🥇 Gold Badge";
        if (score >= 2500) return "🥈 Silver Badge";
        if (score >= 1000) return "🥉 Bronze Badge";
        return "🔰 Beginner Badge";
    }
}