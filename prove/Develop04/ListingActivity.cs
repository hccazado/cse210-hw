using System.Runtime.CompilerServices;

class ListingActivity : Activity
{
    private List<string> _messages;
    private List<string> _answers;
    public ListingActivity(int duration)
    {
        SetName("Mindful Listing");
        SetDescription("Reflecting and listing as many good things in certain areas of your life helps to develop a feeling of gratitude.");
        SetDuration(duration);

        _answers = new List<string>();

        _messages = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string RandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(0, _messages.Count);

        string prompt = _messages[index];

        return prompt;
    }

    protected override string GetStatistics()
    {
        return $"You provided: {_answers.Count} answers in {GetDuration()} seconds.";
    }

    public void MindfulListing()
    {
        WelcomeMessage();

        PreparingTimer();

        Console.WriteLine($"Ponder about:\n{RandomPrompt()}");

        Spinner(3);

        DateTime currentTime = DateTime.Now;

        DateTime stopTime = currentTime.AddSeconds(GetDuration());

        while(DateTime.Now < stopTime)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            Console.Write("> ");

            string answer = Console.ReadLine();

            _answers.Add(answer);
        }
        Console.WriteLine($"\n{GetStatistics()}");

        Console.WriteLine($"\n{EndMessage()}");

        Spinner(3);
    }
}