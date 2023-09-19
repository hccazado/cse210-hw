using System;
using System.Reflection.Metadata;

class Program
{

    static void DisplayWelcome ()
    {
        Console.WriteLine("Welcome to Introduction to C#!");
    }

    static string PromptUserName ()
    {
        Console.WriteLine("Please type your name: ");
        
        string input = Console.ReadLine();

        return input;
    }

    static int PromptUserNumber ()
    {
        string input;
        Console.WriteLine("Please enter favorite number: ");

        input = Console.ReadLine();

        return int.Parse(input);
    }

    static int SquareNumber(int userNumber)
    {
        int result = userNumber * userNumber;

        return result;
    }

    static void DisplayResult(string user, int squareNumber)
    {
        Console.WriteLine($"Hello {user}, the square of your number is {squareNumber}");
    }

    static void Main(string[] args)
    {

        string userName;

        int favoriteNumber;

        int squareNumber;

        DisplayWelcome();

        userName = PromptUserName();

        favoriteNumber = PromptUserNumber();

        squareNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squareNumber);
    }
}