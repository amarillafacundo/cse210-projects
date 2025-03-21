using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God os loved the world that he gave his only begotten Son");

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords();

        }

        Console.WriteLine("\nAll words are hidden. Goodbye!");
    }
}