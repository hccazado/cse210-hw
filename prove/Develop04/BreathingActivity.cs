class BreathingActivity : Activity 
//Inherits from Activity Class
{
    //Medical Phisiology 12th Guyton & Hall -
    //Defines in its adult physiological model:
    //Inspiring 2sec
    //Exhaling 2s - (3s) 
    
    private int _inspiring = 2;
    private int _exhaling = 3;
    public BreathingActivity(int duration)
    {
        SetName("Mindful Breathing");

        SetDescription("Focusing on your breathing permits stress relieving and feeling in control."+
                        "You'll be guided to control your respiration.");

        SetDuration(duration);
    }

    protected override string GetStatistics()
    //overrides method from Activity class
    {
        int respiratoryCicles = (GetDuration() / (_inspiring + _exhaling));

        return $"You completed: {respiratoryCicles} respiratory cycles in {GetDuration()} seconds.";
    }

    public void MindfulBreathing()
    //Display wellcome message, get ready message, and guides user through breathing steps. Display end message
    {
        void Inspire()
        //clean previous console line and prints instruction for user inspiring
        {
            Console.SetCursorPosition(0, Console.CursorTop-1);

            Console.Write(new string(' ', Console.WindowWidth)); 

            Console.WriteLine("Inspire: ");

            Spinner(_inspiring);
        }

        void Exhale()
        //clean previous console line and prints instruction for user exhaling
        {
            Console.SetCursorPosition(0, Console.CursorTop-2);

            Console.Write(new string(' ', Console.WindowWidth)); 

            Console.WriteLine("Exhale: ");

            Spinner(_exhaling);
        }
        
        Console.Clear();

        Console.WriteLine(WelcomeMessage());
        
        PreparingTimer();
        
        DateTime startTime = DateTime.Now;

        DateTime stopTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < stopTime)
        {
            Inspire();

            Console.SetCursorPosition(0, Console.CursorTop-1);

            Console.Write(new string(' ', Console.WindowWidth));

            Exhale();
        }

        Console.WriteLine($"\n{GetStatistics()}");

        Console.WriteLine($"\n{EndMessage()}");

        Spinner(5);
    }
}