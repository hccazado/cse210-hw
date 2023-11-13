using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square sq = new Square("red",2);
        shapes.Add(sq);

        Rectangle rt = new Rectangle("blue", 2.3, 3.3);
        shapes.Add(rt);

        Circle cr = new Circle("green", 6.2);
        shapes.Add(cr);

        foreach(var item in shapes)
        {
            Console.WriteLine($"Color: {item.GetColor()} - Area: {item.GetArea()}");
        }
    }
}