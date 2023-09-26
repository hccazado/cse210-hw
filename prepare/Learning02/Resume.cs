public class Resume 
{
    public string _name;

    public List<Job> _jobs = new List<Job> ();

    public void Display() 
    //Display Resume's details
    {
        Console.WriteLine($"Name: {_name}");

        Console.WriteLine("Jobs:");

        //Displaying all jobs from current resume instance
        foreach(var job in _jobs)
        {
            job.DisplayJobInfo();
        }
    }
}