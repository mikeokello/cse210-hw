using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        Console.WriteLine("Enter numbers (enter 0 to finish):");

        // Collect numbers from the user
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Calculate sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Calculate average
        double average = (double)sum / numbers.Count;

        // Find largest number
        int largest = numbers[0];
        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}