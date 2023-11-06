using System;

class Program
{
    static void Main(string[] args)
    {
        Square sq = new Square("red",2);

        Rectangle rt = new Rectangle("blue", 2.3, 3.3);

        Circle cr = new Circle("green", 6.2);

        Console.WriteLine(sq.GetColor());
        Console.WriteLine(rt.GetColor());
        Console.WriteLine(cr.GetColor());
        Console.WriteLine(sq.GetArea());
        Console.WriteLine(rt.GetArea());
        Console.WriteLine(cr.GetArea());

    }
}