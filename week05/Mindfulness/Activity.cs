using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void Run()
    {
        StartMessage();
        PerformActivity();
        EndMessage();
    }

    protected void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    protected void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.\n");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected abstract void PerformActivity();
}
