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

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public string WelcomeMessage()
    {
        return $"Welcome to {_name} Activity\n{_description}";
    }

    public string EndMessage()
    {
        return $"Congratualitions! you did a great job on your {_name} Activity!";
    }

    protected void PreparingTimer()
    {
        for(int i = 3; i > 0; i--)
        {
            Console.Write($"Get Ready: {i}");
            Console.SetCursorPosition(0, Console.CursorTop);
            Thread.Sleep(1000);
        }
    }

    protected virtual string GetStatistics(){
        return "Statistics method not yer implemented.";
    }

    protected void Spinner(int duration)
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