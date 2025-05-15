// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;
    private Random random;

    public Journal()
    {
        entries = new List<Entry>();
        random = new Random();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What lesson did I learn today?",
            "What am I grateful for today?",
            "How did I take care of myself today?",
            "What challenge did I face today and how did I handle it?"
        };
    }

    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Location (optional): ");
        string location = Console.ReadLine();

        Console.Write("Mood/Emotion (optional): ");
        string mood = Console.ReadLine();

        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        entries.Add(new Entry(prompt, response, date, location, mood));
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===");
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (e.g., journal.csv): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToCsvString());
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    loadedEntries.Add(Entry.FromCsvString(line));
                }
            }

            entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public void SearchEntries(string keyword)
    {
        List<Entry> matches = entries.FindAll(entry =>
            entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Mood.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (matches.Count == 0)
        {
            Console.WriteLine("No entries found matching your search.");
            return;
        }

        Console.WriteLine($"\n=== Found {matches.Count} entries matching '{keyword}' ===");
        foreach (var entry in matches)
        {
            entry.Display();
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine("\n=== Journal Statistics ===");
        Console.WriteLine($"Total entries: {entries.Count}");

        if (entries.Count > 0)
        {
            Dictionary<string, int> promptCounts = new Dictionary<string, int>();
            Dictionary<string, int> moodCounts = new Dictionary<string, int>();

            foreach (var entry in entries)
            {
                // Count prompt usage
                if (promptCounts.ContainsKey(entry.Prompt))
                {
                    promptCounts[entry.Prompt]++;
                }
                else
                {
                    promptCounts[entry.Prompt] = 1;
                }

                // Count moods if available
                if (!string.IsNullOrEmpty(entry.Mood))
                {
                    if (moodCounts.ContainsKey(entry.Mood))
                    {
                        moodCounts[entry.Mood]++;
                    }
                    else
                    {
                        moodCounts[entry.Mood] = 1;
                    }
                }
            }

            Console.WriteLine("\nMost used prompts:");
            foreach (var pair in promptCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} times");
            }

            if (moodCounts.Count > 0)
            {
                Console.WriteLine("\nMood frequency:");
                foreach (var pair in moodCounts)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value} times");
                }
            }

            // Find the earliest and latest entry
            try
            {
                DateTime earliest = DateTime.MaxValue;
                DateTime latest = DateTime.MinValue;

                foreach (var entry in entries)
                {
                    DateTime entryDate = DateTime.Parse(entry.Date);
                    if (entryDate < earliest) earliest = entryDate;
                    if (entryDate > latest) latest = entryDate;
                }

                Console.WriteLine($"\nTime span of entries: {earliest.ToShortDateString()} to {latest.ToShortDateString()}");
                Console.WriteLine($"That's {(latest - earliest).TotalDays} days of journaling!");
            }
            catch
            {
                // If date parsing fails, skip this part
            }
        }
    }
}