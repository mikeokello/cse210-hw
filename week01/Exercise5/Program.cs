using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = GenerateMagicNumber();
        int guess = -1;

        Console.WriteLine("Welcome to the Guessing Game!");

        // Loop until the user guesses correctly
        while (guess != magicNumber)
        {
            guess = GetUserGuess();

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }

    // Function to generate a random number
    static int GenerateMagicNumber()
    {
        Random random = new Random();
        return random.Next(1, 101); // number between 1 and 100
    }

    // Function to get user input
    static int GetUserGuess()
    {
        Console.Write("What is your guess? ");
        string input = Console.ReadLine();
        return int.Parse(input);
    }
}