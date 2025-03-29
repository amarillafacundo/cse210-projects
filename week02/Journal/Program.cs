using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

    }
}

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string filePath = "journal.txt";

    private List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "Describe something that made you smile.",
        "What did you learn today?",
        "How did you overcome a challenge today?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.Date);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
                writer.WriteLine("---");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved journal found.");
            return;
        }
        entries.Clear();
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i += 4)
        {
            if (i + 2 < lines.Length)
            {
                entries.Add(new Entry(lines[i + 1], lines[i + 2]) { Date = lines[i] });
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}