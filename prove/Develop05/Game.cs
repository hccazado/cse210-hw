using System.Net;
using System.Runtime.CompilerServices;

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
        string goal;
        string description;
        int points;
        int bonusPoints;
        int desiredAccomplishments;


        void GoalCommonData()
        {
            Console.WriteLine("Type the name of your goal:");
            goal = Console.ReadLine();
            
            Console.WriteLine("Type a small decription for your goal:");
            description = Console.ReadLine();
            
            Console.WriteLine("Type how many points for this goal:");
            string strPoints = Console.ReadLine();
            points = int.Parse(strPoints);
        }

        void CheckListSpecificData()
        {
            Console.WriteLine("How many times do you want to accomplish this goal:");
            string input = Console.ReadLine();
            desiredAccomplishments = int.Parse(input);

            Console.WriteLine("How many bonus points for this goal:");
            input = Console.ReadLine();
            bonusPoints = int.Parse(input);
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

                SimpleGoal simpleGoal = new SimpleGoal(goal, description, points, false);

                _goals.Add(simpleGoal);

            break;
            case "2":
                GoalCommonData();

                EternalGoal eternalGoal = new EternalGoal(goal, description, points, false, 0);

                _goals.Add(eternalGoal);
            break;
            case "3":
                GoalCommonData();

                CheckListSpecificData();

                CheckListGoal checklistGoal = new CheckListGoal(goal, description, points, false, bonusPoints, desiredAccomplishments, 0);

                _goals.Add(checklistGoal);
            break;

            case "q":
                
            break;
            default:
                Console.WriteLine("There's no such goal! press any key to continue.");
                Console.ReadLine();
            break;
        }
    }

    public void EventGoal()
    {
        string input;
        
        Console.Clear();
        
        ListGoals();

        Console.WriteLine("Type the goal's number you want to accomplish");

        input = Console.ReadLine();

        int index = int.Parse(input);

        _totalPoints += _goals[index - 1].GoalEvent();

    }

    public void ListGoals()
    {
        for (int i = 0; i< _goals.Count; i++)
        {
            Console.WriteLine($"{i+1} - {_goals[i].DescribeGoal()}");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    public void SaveGame(string fileName)
    {

    }

    public void LoadGame(string filename)
    {

    }

    public void Menu()
    {
        string option = "9";
        while (option != "q")
        {
            Console.Clear();
            Console.WriteLine("\tEternal Quest");
            Console.WriteLine("1 - List goals");
            Console.WriteLine("2 - New goal");
            Console.WriteLine("3 - Goal Accomplished");
            Console.WriteLine("4 - Save goals");
            Console.WriteLine("5 - Load goals");
            Console.WriteLine("q - Exit program\n");
            Console.Write("Choice: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ListGoals();
                break;
                case "2":
                    NewGoal();
                break;
                case "3":
                    EventGoal();
                break;
                case "4":
                    string filename;
                    Console.WriteLine("Type a name to save your current game");
                    filename = Console.ReadLine();
                    SaveGame(filename);
                break;
                case "5":
                    Console.WriteLine("Type your game file's name");
                    filename = Console.ReadLine();
                    LoadGame(filename);
                break;
                case "q":
                    System.Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("Invalid choice! Press any key to continue.");
                    Console.ReadLine();
                break;
            }
        }
    }
}