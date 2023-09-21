using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        //variables
        Random random = new Random();

        int magicNumber = random.Next(1, 99);
        
        int guess = -1;

        while (guess != magicNumber) {

            Console.WriteLine("Type your guess: ");
            
            guess = int.Parse(Console.ReadLine());

            Console.WriteLine(" you guessed: " + guess);

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber) {
                Console.WriteLine("Higher");
            }
            else{
                Console.WriteLine("Congrats! You guessed ir right");
            }
        
        }

        Console.WriteLine("Bye!!");
    }
}