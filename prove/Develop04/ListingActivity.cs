using System.Runtime.CompilerServices;

class ListingActivity : Activity
//Inherits from Activity Class
{
    private List<string> _prompts;
    
    private int _answers;
    
    public ListingActivity(int duration)
    { 
        SetName("Mindful Listing");
        
        SetDescription("Reflecting and listing as many good things in certain areas of your life helps to develop a feeling of gratitude.");
        
        SetDuration(duration);
       
       SetPrompts();

        _answers = 0;
    }

    private string RandomPrompt()
    //returns a random string from _messages list
    {
        Random random = new Random();

        int index = random.Next(0, _prompts.Count);

        string prompt = _prompts[index];

        return prompt;
    }

    private void SetPrompts()
    //set _prompts list value
    {
         _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override string GetStatistics()
    //overrides method from Activity class
    {
        return $"You provided: {_answers} answers in {GetDuration()} seconds.";
    }

    public void MindfulListing()
    //Displays welcome message and a random prompt. Adds user entries to _answers list. and Prints getstatistics method return
    {
        Console.Clear();
        
        Console.WriteLine(WelcomeMessage());

        PreparingTimer();

        Console.WriteLine($"Ponder about:\n{RandomPrompt()}");

        Spinner(6);

        DateTime currentTime = DateTime.Now;

        DateTime stopTime = currentTime.AddSeconds(GetDuration());

        while(DateTime.Now < stopTime)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            Console.Write("> ");

            string answer = Console.ReadLine();

            _answers++;
        }
        Console.WriteLine($"\n{GetStatistics()}");

        Console.WriteLine($"\n{EndMessage()}");

        Spinner(5);
    }
}