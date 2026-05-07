using System;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        int number = -1;

        Console.WriteLine("Enter numbers to add. Type 0 to finish.");

        // Loop until the user enters 0
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");
    }
}