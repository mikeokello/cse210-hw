using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    // CREATIVITY REPORT:
    // 1. Added 6 custom prompts to give users more variety.
    // 2. Used " ~|~ " as a file separator to avoid issues with commas and quotes in entries.
    // 3. Implemented error handling for file loading if file doesn't exist.
    // 4. Used private fields and public methods to enforce abstraction.

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal Menu");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.AddEntry();
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
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }

    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();
        private List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?"
        };
        private Random _random = new Random();

        public void AddEntry()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToShortDateString();

            Entry newEntry = new Entry(date, prompt, response);
            _entries.Add(newEntry);
            Console.WriteLine("Entry saved!");
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nNo entries to display.");
                return;
            }

            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry.ToDisplayString());
                Console.WriteLine("--------------------------");
            }
        }

        public void SaveToFile()
        {
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }

        public void LoadFromFile()
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }

        private string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }

    public class Entry
    {
        private string _date;
        private string _prompt;
        private string _response;

        public Entry(string date, string prompt, string response)
        {
            _date = date;
            _prompt = prompt;
            _response = response;
        }

        public string ToDisplayString()
        {
            return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}";
        }

        public string ToFileString()
        {
            return $"{_date}~|~{_prompt}~|~{_response}";
        }
    }
}