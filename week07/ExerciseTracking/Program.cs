using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime date;
    protected int duration; // Change this from private to protected

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    // Abstract methods
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({duration} min): Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / base.duration) * 60; // Speed in kph

    public override double GetPace() => base.duration / distance; // Pace in min per km
}

public class Cycling : Activity
{
    private double speed; // Speed in kph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => speed * base.duration / 60;

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed; // Pace in min per km
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0; // Convert to kilometers

    public override double GetSpeed() => (GetDistance() / base.duration) * 60;

    public override double GetPace() => base.duration / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        // Print initial message
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        // Create a list to hold the activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 5.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 40)
        };

        // Iterate through the list and print summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
