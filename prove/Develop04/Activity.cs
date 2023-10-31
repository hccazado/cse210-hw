using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Activity
{
    string _name;
    string _description;
    int _duration;

    public Activity()
    {
        _name = "Undefined";
        _description = "Description not defined";
        _duration = 0;
    }

    public Activity(string name, string description, int duration)
    {
        _name = name;

        _description = description;

        _duration = duration;

    }
    public void SetName(string name)
    //set a new value for _name attribute
    {
        _name = name;
    }
    public void SetDescription(string description)
    //set a new value for _description attribute
    {
        _description = description;
    }
    public int GetDuration()
    //returns defined duration for the instance
    {
        return _duration;
    }
    public void SetDuration(int duration)
    //set a new value for _name attribute
    {
        _duration = duration;
    }

    public string WelcomeMessage()
    //returns a string Activity welcoming message
    {
        return $"Welcome to {_name} Activity\n{_description}";
    }

    public string EndMessage()
    //returns a string Activity ending message
    {
        return $"Congratualitions! you did a great job on your {_name} Activity!";
    }

    protected virtual string GetStatistics()
    // A virtual statistic method to be overwritten on inherited class
    {
        return "Statistics method not implemented for this Activity yet.";
    }

    protected void PreparingTimer()
    //prints on console instructions for the user getting ready for his activity (lasts for 8 seconds)
    {
        for(int i = 8; i > 0; i--)
        {
            Console.Write($"Get Ready: {i}");

            Console.SetCursorPosition(0, Console.CursorTop);

            Thread.Sleep(1000);
        }
    }

    protected void Spinner(int duration)
    //prints a Spinner animation. Lentgh for its duration must be provided in seconds
    {
        string[] chars = new [] {"|","/","-","\\"};

        int i = 0;

        DateTime startTime = DateTime.Now;
        
        DateTime futureTime = startTime.AddSeconds(duration);

        while (DateTime.Now < futureTime)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            Console.Write(chars[i]);

            i++;

            i = i == chars.Length ? 0 : i; 

            Thread.Sleep(200);
        }
    }
}