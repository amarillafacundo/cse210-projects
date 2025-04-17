using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3)
        };


        foreach (var shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }


    }
}