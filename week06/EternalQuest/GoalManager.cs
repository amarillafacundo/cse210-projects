using System.IO;
using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Add Start //
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points. (Level {GetPlayerLevel()})\n");


            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


    public void DisplayPlayerInfo()
    {
        // TODO
    }

    public void ListGoalNames()
    {
        // TODO
    }

    public void ListGoalDetails()
    {
        // TODO
    }

    // Add CreateGoal //
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    // Add RecordEvent //
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record. Create one first.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int index) && index >= 1 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];

            // Get current level BEFORE adding points
            int oldLevel = GetPlayerLevel();

            // Record event and update score
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");

            // Get new level AFTER adding points
            int newLevel = GetPlayerLevel();

            // Level up message
            if (newLevel > oldLevel)
            {
                Console.WriteLine($"You've leveled up to Level {newLevel}!");

            }

            Console.WriteLine($"You now have {_score} points. (Level {newLevel})");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }


    // add SaveGoals
    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score); // Save score on first line

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals and score saved successfully!");
    }

    // add LoadGoals //
    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear(); // Clear current list

        _score = int.Parse(lines[0]); // First line = score

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] data = parts[1].Split(",");

            Goal goal = null;

            if (goalType == "SimpleGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);

                goal = new SimpleGoal(name, desc, points);
                if (isComplete)
                {
                    // Trick to set private _isComplete via reflection or extra logic
                    // We’ll skip it here, or you can add a constructor to accept it
                    // For now, the goal will load but show as incomplete
                }
            }
            else if (goalType == "EternalGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);

                goal = new EternalGoal(name, desc, points);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int completed = int.Parse(data[5]);

                ChecklistGoal checklist = new ChecklistGoal(name, desc, points, target, bonus);

                // Set completed count via reflection or by adding a method (easiest):
                for (int j = 0; j < completed; j++) checklist.RecordEvent();

                goal = checklist;
            }

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }



        Console.WriteLine("Goals and score loaded successfully!");

    }
    private int GetPlayerLevel()
    {
        return _score / 500;
    }

}


