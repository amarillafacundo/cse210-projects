using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Default Constructor (1/1)
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter (n/1)
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters (n/d)
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getters and Setters
    public int GetNumerator() => _numerator;
    public void SetNumerator(int numerator) => _numerator = numerator;

    public int GetDenominator() => _denominator;
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }

    // Method to return fraction as a string "a/b"
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to return decimal value
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
