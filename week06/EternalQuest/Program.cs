// Eternal Quest Project - CSE 210
// Extra Feature: Leveling System
// -------------------------------
// I added a feature that tracks the player's level based on their score.
// Every 500 points = +1 level. The program shows the current level on each screen
// and gives a "Level Up!" message whenever the player crosses into a new level.
// This adds a fun gamification element to help motivate goal progress.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager manager = new GoalManager();
        manager.Start();
    
    }
}