using System;

class Program
{
    static void Main(string[] args)
    {

        Resume person1 = new Resume();

        Job job1 = new Job();

        Job job2 = new Job();

        job1._company = "Microsoft";

        job1._jobTitle = "Software Engineer";

        job1._startYear = 2010;

        job1._endYear = 2016;

        job2._company = "Apple";

        job2._jobTitle = "UX";

        job2._startYear = 2017;

        job2._endYear = 2020;

        person1._name = "Person one";
        
        person1._jobs.Add(job1);
        
        person1._jobs.Add(job2);

        person1.Display();
    }
}
