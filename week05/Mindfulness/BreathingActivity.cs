using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            PauseWithCountdown(4);
            Console.Write("\nBreathe out... ");
            PauseWithCountdown(6);
        }
    }
}
