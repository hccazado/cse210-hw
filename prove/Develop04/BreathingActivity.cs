class BreathingActivity : Activity 
{
    //Medical Phisiology 12th Guyton & Hall -
    //Defines in its adult physiological model:
    //Inspiration 2sec
    //Expiration 2s - (3s) 
    private int _inspiration = 2;
    private int _expiration = 3;
    public BreathingActivity(int duration)
    {
        SetName("Mindful Breathing");

        SetDescription("Focusing on your breathing permits stress relieving and feeling in control."+
                        "\nYou'll be guided to control your respiration.");

        SetDuration(duration);
    }

    public void MindfulBreathing()
    {
        void Inspire ()
        {
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.WriteLine("Inspire: ");
            Spinner(_inspiration);
        }

        void Exhale()
        {
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.WriteLine("Exhale: ");
            Spinner(_expiration);
        }
        
        WelcomeMessage();
        
        PreparingTimer();

        DateTime startTime = DateTime.Now;

        DateTime stopTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < stopTime)
        {
            Inspire();

            Exhale();
        }
        Console.WriteLine($"\n\n{EndMessage()}");

        Spinner(3);
    }
}