using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;

class Program
{
    static void Main(string[] args)
    {
        int input = -1, sum = 0, largestNumber = -99, smallestNumber = 9999;

        float avg = 0;

        List<int> numbers = new List<int>();

        while (input != 0){

            Console.WriteLine("Type a number (0 to stop):");

            input = int.Parse(Console.ReadLine());

            if (input != 0){

                numbers.Add(input);

            }

        }

        foreach(int number in numbers){
            
            sum += number;

            //finding the largest number
            if (number > largestNumber){
                
                largestNumber = number;

            }
            //finding the smallest number
            if (number < smallestNumber){

                smallestNumber = number;

            }
        }

        //calculating average. sum is firstly converted into float, so this it's possible to have
        //a result with decimal ;oint
        avg = (float)sum / numbers.Count;

        Console.WriteLine($"The average is: {avg}");

        Console.WriteLine($"Sum: {sum}");

        Console.WriteLine($"The largest number is: {largestNumber}");

        Console.WriteLine($"The smallest number is: {smallestNumber}");

        Console.WriteLine("Sorted list");

        numbers.Sort();

        foreach (int number in numbers){
            Console.WriteLine(number);
        }
        
        Console.WriteLine("Bye!");
    }

}
