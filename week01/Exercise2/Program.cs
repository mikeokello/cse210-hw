using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for a number
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        // Convert input to integer
        int number = int.Parse(input);

        // Check if the number is positive, negative, or zero
        if (number > 0)
        {
            Console.WriteLine("The number is positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine("The number is negative.");
        }
        else
        {
            Console.WriteLine("The number is zero.");
        }
    }
}