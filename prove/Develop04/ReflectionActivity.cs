class ReflectionActivity: Activity
{
    private List<string> _prompts;

    private List<string> _questions;

    private List<string> _answers;

    public ReflectionActivity(int duration)
    {
        SetName("Mindful Reflection");

        SetDescription("Focusing on moments you used your strength and resilience helps improve your"+
                        " self-awareness of your power to accomplish great things.");
        
        SetDuration(duration);

        _answers = new List<string>();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this experience successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };   
    }

    private string RandomMessage()
    {
        Random random = new Random();

        int index = random.Next(0, _prompts.Count);

        string prompt = _prompts[index];

        return prompt;
    }

    private string RandomQuestion()
    {
        Random random = new Random();

        int index = random.Next(0, _prompts.Count);

        string question = _questions[index];

        _questions.RemoveAt(index);

        return question;
    }

    protected override string GetStatistics()
    {
        return $"You answered: {_answers.Count} questions in {GetDuration()} seconds.";
    }

    public void MindfulReflection()
    {
        WelcomeMessage();
        
        PreparingTimer();
        
        Console.WriteLine(RandomMessage());

        Spinner(3);
        
        DateTime currentTime = DateTime.Now;
        
        DateTime stopTime = currentTime.AddSeconds(GetDuration());
        
        while(DateTime.Now < stopTime)
        {
            Console.WriteLine(RandomQuestion());

            Console.Write("> ");

            string answer = Console.ReadLine();

            _answers.Add(answer);
        }

        Console.WriteLine($"\n{GetStatistics()}");

        Console.WriteLine($"\n{EndMessage()}");

        Spinner(3);
    }

}