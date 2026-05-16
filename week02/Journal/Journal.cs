using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
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
}
