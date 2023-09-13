using System;

class Program
{
    static void Main(string[] args)
    {
        //Variables
        string firstName, lastName;

        Console.WriteLine("What is your first name?");
        
        firstName = Console.ReadLine();

        Console.WriteLine("What is your last name?");

        lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

    }
}