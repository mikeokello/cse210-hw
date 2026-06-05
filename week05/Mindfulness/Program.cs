using System;

// Creativity:
// Added an activity menu that allows users to perform multiple activities
// during one program session without restarting the application.

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    running = false;
                    break;
            }
        }
    }
}
