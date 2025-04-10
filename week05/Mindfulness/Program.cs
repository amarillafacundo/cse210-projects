// ==========================================================
// Exceeded Requirements:
// - Added a usage counter to track how many times each activity has been run.
// ==========================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Dictionary<string, int> usageCounter = new Dictionary<string, int>
        {
            {"Breathing", 0},
            {"Reflection", 0},
            {"Listing", 0}
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. View Usage Stats");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (choice == "5")
                break;

            if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Usage Statistics:");
                Console.WriteLine($"Breathing Activity: {usageCounter["Breathing"]} times");
                Console.WriteLine($"Reflection Activity: {usageCounter["Reflection"]} times");
                Console.WriteLine($"Listing Activity: {usageCounter["Listing"]} times");
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
                continue;
            }

            if (activity != null)
            {
                if (activity is BreathingActivity) usageCounter["Breathing"]++;
                if (activity is ReflectionActivity) usageCounter["Reflection"]++;
                if (activity is ListingActivity) usageCounter["Listing"]++;

                activity.Run();
            }
        }

    }
}