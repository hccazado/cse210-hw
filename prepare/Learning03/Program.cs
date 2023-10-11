using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Learning Activity - Encapsulation - Fractions");
        
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(2);
        Fraction f3 = new Fraction(3,9);
        
        Console.WriteLine($"\nf1 fraction string: {f1.GetFractionString()}");
        Console.WriteLine($"\nf1 decimal value: {f1.GetDecimalValue()}");
        Console.WriteLine($"\nf2 fraction string: {f2.GetFractionString()}");
        Console.WriteLine($"\nf2 decimal value: {f2.GetDecimalValue()}");
        Console.WriteLine($"\nf3 fraction string: {f3.GetFractionString()}");
        Console.WriteLine($"\nf3 decimal value: {f3.GetDecimalValue()}");

        f1.SetTop(2);

        f2.SetTop(4);

        f2.SetBottom(2);

        Console.WriteLine($"\nf1 fraction string: {f1.GetFractionString()}");
        Console.WriteLine($"\nf1 decimal value: {f1.GetDecimalValue()}");
        Console.WriteLine($"\nf2 fraction string: {f2.GetFractionString()}");
        Console.WriteLine($"\nf2 decimal value: {f2.GetDecimalValue()}");
        Console.WriteLine($"\nf3 fraction string: {f3.GetFractionString()}");
        Console.WriteLine($"\nf3 decimal string:{f3.GetDecimalValue()}");
        
    }
}