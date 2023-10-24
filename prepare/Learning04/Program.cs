using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math1 = new MathAssignment("Robberto Rodriguez","Fractions","7.3","8-19");
        WritingAssigment wrt1 = new WritingAssigment("Mary Waters","European History","The Causes of World War II");

        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());

        Console.WriteLine(wrt1.GetWritingInformation());
    }
}