using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // CREATIVITY: Load multiple scriptures and select one at random to exceed core requirements.
        // This demonstrates flexibility in the Scripture Memorizer program by allowing variety in practice.
        Reference reference1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(reference1, "For God so loved the world that he gave his only begotten Son");

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(reference2, "Trust in the Lord with all thine heart and lean not unto thine own understanding");

        List<Scripture> scriptures = new List<Scripture> { scripture1, scripture2 };
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.ToString());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.ToString());
        Console.WriteLine("\nAll words are hidden. Program ending.");
    }
}