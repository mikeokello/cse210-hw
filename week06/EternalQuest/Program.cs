using System;
using System.Collections.Generic;
using System.IO;

// Eternal Quest - Week 06 (CSE210)
// Creativity / Exceed Requirements:
// I added a simple "Quest Streak" system for gamification.
// - During a single program session, whenever the user records an event
//   we increment a streak counter.
// - If the user records 5 events total in the session, we award an extra
//   "streak bonus" of 250 points.
// - This bonus is only for the current session (not loaded from file) to keep
//   the assignment logic clear and focused on core requirements.

public class Program
{
    private const string SaveFileName = "eternalquest_save.txt";

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null)
            {
                continue;
            }


            if (int.TryParse(input.Trim(), out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid integer.");
        }
    }

    private static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null)

            {
                continue;
            }

            string trimmed = input.Trim();
            if (trimmed.Length > 0)
            {
                return trimmed;
            }

            Console.WriteLine("Please enter a non-empty value.");
        }
    }

    private static string NextId(List<Goal> goals)
    {
        // Simple unique id based on count.
        return (goals.Count + 1).ToString();
    }

    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("==== Eternal Quest ====");
        Console.WriteLine("1) Create a goal");
        Console.WriteLine("2) Record an event (gain points)");
        Console.WriteLine("3) Show goals");
        Console.WriteLine("4) Show score");
        Console.WriteLine("5) Save");
        Console.WriteLine("6) Load");
        Console.WriteLine("0) Exit");
        Console.WriteLine();
    }

    private static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine();
        Console.WriteLine("-- Your Goals --");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}) {goal.GetStatusLine()}");
        }
    }

    private static void SaveGame(List<Goal> goals, int score)
    {
        using (StreamWriter outputFile = new StreamWriter(SaveFileName))
        {
            outputFile.WriteLine($"Score|{score}");
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetSaveLine());
            }
        }

        Console.WriteLine($"Saved to {SaveFileName}.");
    }

    private static (List<Goal> goals, int score) LoadGame()
    {
        if (!File.Exists(SaveFileName))
        {
            Console.WriteLine($"No save file found at '{SaveFileName}'.");
            return (new List<Goal>(), 0);
        }

        string[] lines = File.ReadAllLines(SaveFileName);
        int score = 0;
        List<Goal> goals = new List<Goal>();

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (line.Length == 0)
            {
                continue;
            }

            if (line.StartsWith("Score|"))
            {
                string[] parts = line.Split('|');
                score = int.Parse(parts[1]);
                continue;
            }

            goals.Add(GoalFactory.CreateFromSaveLine(line));
        }

        Console.WriteLine($"Loaded {goals.Count} goals. Current score: {score}.");
        return (goals, score);
    }

    private static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine();
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1) Simple goal (completes once)");
        Console.WriteLine("2) Eternal goal (never completes)");
        Console.WriteLine("3) Checklist goal (complete N times)");

        int typeChoice = ReadInt("Enter choice: ");
        string id = NextId(goals);
        string title = ReadNonEmptyString("Goal title: ");
        while (title.Contains("|"))
        {
            Console.WriteLine("Goal title cannot contain '|' because it is used in the save file.");
            title = ReadNonEmptyString("Goal title: ");
        }

        int points = ReadInt("Points per event: ");

        switch (typeChoice)
        {
            case 1:
                goals.Add(new SimpleGoal(id, title, points));
                Console.WriteLine("Simple goal created.");
                break;
            case 2:
                goals.Add(new EternalGoal(id, title, points));
                Console.WriteLine("Eternal goal created.");
                break;
            case 3:
                int targetCount = ReadInt("How many times to complete? ");
                goals.Add(new ChecklistGoal(id, title, points, targetCount));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Invalid goal type selection.");
                break;
        }
    }

    private static void RecordEvent(List<Goal> goals, ref int score, ref int sessionEvents)
    {
        Console.WriteLine();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet.");
            return;
        }

        ShowGoals(goals);
        int goalIndex = ReadInt("Select goal number to record: ") - 1;
        if (goalIndex < 0 || goalIndex >= goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = goals[goalIndex];
        int pointsEarned = goal.RecordEvent();

        if (pointsEarned == 0)
        {
            Console.WriteLine("No points earned (this goal is already complete). ");
            return;
        }

        score += pointsEarned;
        sessionEvents++;
        Console.WriteLine($"Recorded! +{pointsEarned} points.");

        // Quest streak bonus (creativity)
        if (sessionEvents % 5 == 0)
        {
            int streakBonus = 250;
            score += streakBonus;
            Console.WriteLine($"Quest Streak Bonus! You recorded {sessionEvents} events this session. +{streakBonus} points.");
        }
    }

    public static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;
        int sessionEvents = 0;

        while (true)
        {
            PrintMenu();
            int choice = ReadInt("Choose an option: ");

            switch (choice)
            {
                case 1:
                    CreateGoal(goals);
                    break;
                case 2:
                    RecordEvent(goals, ref score, ref sessionEvents);
                    break;
                case 3:
                    ShowGoals(goals);
                    break;
                case 4:
                    Console.WriteLine($"Current score: {score}");
                    break;
                case 5:
                    SaveGame(goals, score);
                    break;
                case 6:
                    (goals, score) = LoadGame();
                    sessionEvents = 0;
                    break;
                case 0:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

