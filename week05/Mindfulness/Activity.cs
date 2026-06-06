using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;
    
    // ENHANCEMENT: Static counter to track total activities completed
    private static int _totalActivitiesCompleted = 0;

    public Activity(string name, string description)
{
    _name = name;
    _description = description;
}

public void DisplayStartingMessage()
{
    Console.Clear();
    Console.WriteLine($"Welcome to the {_name} Activity.");
    Console.WriteLine();
    Console.WriteLine(_description);
    Console.WriteLine();

    Console.Write("How long, in seconds, would you like for your session? ");
    _duration = int.Parse(Console.ReadLine());

    Console.WriteLine();
    Console.WriteLine("Get ready...");
    ShowSpinner(3);
}

public void DisplayEndingMessage()
{
    Console.WriteLine();
    Console.WriteLine("Well done!");
    ShowSpinner(3);

    Console.WriteLine();
    Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.");
    
    // ENHANCEMENT: Display activity statistics
    _totalActivitiesCompleted++;
    Console.WriteLine();
    Console.WriteLine($"Total Activities Completed: {_totalActivitiesCompleted}");
    
    ShowSpinner(3);
}

public void ShowSpinner(int seconds)
{
    List<char> spinner = new List<char>()
    {
        '|','/','-','\\'
    };

    DateTime endTime = DateTime.Now.AddSeconds(seconds);

    int i = 0;

    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[i]);
        Thread.Sleep(250);
        Console.Write("\b \b");

        i++;
        if (i >= spinner.Count)
        {
            i = 0;
        }
    }
}

public void ShowCountdown(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
}
}
