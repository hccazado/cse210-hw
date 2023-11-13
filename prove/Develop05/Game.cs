class Game
{
    private List<Goal> _goals;
    private int _totalPoints;
    public Game()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }

    public void NewGoal()
    {
        string goal= "";
        string description = "";
        int points = 0;

        void GoalCommonData()
        {
            Console.WriteLine("Type the name of your goal:");
            goal = Console.ReadLine();
            
            Console.WriteLine("Type a small decription for your goal:");
            description = Console.ReadLine();
            
            Console.WriteLine("Type the name of your goal:");
            string strPoints = Console.ReadLine();
            points = int.Parse(strPoints);

        }

        Console.WriteLine("Select which type of goal do you want to create:");
        Console.WriteLine("1 - Simple goal");
        Console.WriteLine("2 - Eternal goal");
        Console.WriteLine("3 - Check list goal");
        Console.WriteLine("q - Cancel");

        Console.Write("> ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                GoalCommonData();
            break;
            case "2":
                GoalCommonData();
            break;
            case "3":
                GoalCommonData();
            break;
            default:
                Console.WriteLine("Invalid Option! press any key to continue.");
                Console.ReadLine();
            break;

        }
    }

    public void EventGoal()
    {

    }

    public void ListGoals()
    {

    }

    public void SaveGame(string fileName)
    {

    }

    public void LoadGame(string filename)
    {

    }
}