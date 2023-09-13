using System;

class Program
{
    static void Main(string[] args)
    {

        float gradePercentage;

        string letter = "", sign = "";

        Console.WriteLine("Please inform your grade percentage:");

        string input = Console.ReadLine();

        gradePercentage = float.Parse(input);

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //determing sign of letter grade
        if(gradePercentage%10 >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if(gradePercentage%10 < 3 && letter != "F")
        {
            sign = "-";
        }

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine($"Congratulations! You approved with an: {letter}{sign}.");
        }
        else{
            Console.WriteLine($"Sorry, you haven't approved this time. You got an {letter}{sign}.");
        }
    }
}