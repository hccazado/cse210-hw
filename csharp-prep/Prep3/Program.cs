using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        //variables
        int magicNumber = 7;
        
        string guess = "";

        bool isPlaying = true;

        do {

            Console.WriteLine("Type your guess: ");
            
            guess = Console.ReadLine();

            Console.WriteLine(" you guessed: " + guess);

            if (int.Parse(guess) > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (int.Parse(guess) < magicNumber) {
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine("Congrats! You guessed ir right");
            }
        
        } while(isPlaying);

        Console.WriteLine("Bye!!");
    }
}