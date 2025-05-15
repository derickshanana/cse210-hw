// Entry.cs
using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Location { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string date, string location = "", string mood = "")
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Location = location;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        if (!string.IsNullOrEmpty(Location))
            Console.WriteLine($"Location: {Location}");
        if (!string.IsNullOrEmpty(Mood))
            Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine();
    }

    public string ToCsvString()
    {
        return $"\"{Date}\",\"{Prompt.Replace("\"", "\"\"")}\",\"{Response.Replace("\"", "\"\"")}\",\"{Location.Replace("\"", "\"\"")}\",\"{Mood.Replace("\"", "\"\"")}\"";
    }

    public static Entry FromCsvString(string csvLine)
    {
        string[] parts = ParseCsvLine(csvLine);
        return new Entry(
            parts[1],
            parts[2],
            parts[0],
            parts.Length > 3 ? parts[3] : "",
            parts.Length > 4 ? parts[4] : ""
        );
    }

    private static string[] ParseCsvLine(string csvLine)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        int start = 0;

        for (int i = 0; i < csvLine.Length; i++)
        {
            if (csvLine[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (csvLine[i] == ',' && !inQuotes)
            {
                string part = csvLine.Substring(start, i - start).Trim('"').Replace("\"\"", "\"");
                parts.Add(part);
                start = i + 1;
            }
        }

        // Add the last part
        string lastPart = csvLine.Substring(start).Trim('"').Replace("\"\"", "\"");
        parts.Add(lastPart);

        return parts.ToArray();
    }
}