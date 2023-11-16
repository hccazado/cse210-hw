using System.Net;
using System.Reflection.Metadata;
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

    private void SimpleGoal(string goal, string description, int points, bool isComplete)
    {
        SimpleGoal simpleGoal = new SimpleGoal(goal, description, points, isComplete);
        
        _goals.Add(simpleGoal);
    }

    private void EternalGoal(string goal, string description, int points, bool isComplete, int accomplishments)
    {            
        EternalGoal eternalGoal = new EternalGoal(goal, description, points, isComplete, accomplishments);
        
        _goals.Add(eternalGoal);
    }
    
    private void CheckListGoal(string goal, string description, int points, bool isComplete, int bonusPoints, int desiredAccomplishments, int currentAccomplishments)
    {
        
        CheckListGoal checkListGoal = new CheckListGoal(goal,description,points,isComplete,bonusPoints, desiredAccomplishments,currentAccomplishments);
        
        _goals.Add(checkListGoal);
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

                SimpleGoal(goal, description, points, false);
            break;
            case "2":
                GoalCommonData();

                EternalGoal(goal, description, points, false, 0);
            break;
            case "3":
                GoalCommonData();

                CheckListSpecificData();

                CheckListGoal(goal, description, points, false, bonusPoints, desiredAccomplishments, 0);
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

        Console.WriteLine("Type the goal's number you want to record and accomplishment");

        input = Console.ReadLine();

        int index = int.Parse(input);

        _totalPoints += _goals[index - 1].GoalEvent();
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals!");
        }
        else
        {
            for (int i = 0; i< _goals.Count; i++)
            {
                Console.WriteLine($"{i+1} - {_goals[i].DescribeGoal()}");
            }
        }
    }

    public void SaveGame(string fileName)
    {
        using(StreamWriter output = new StreamWriter(fileName+".txt"))
        {
            output.WriteLine(_totalPoints);
            foreach (var goal in _goals)
            {
                output.WriteLine(goal.GoalSavingData());
            }
        }
    }

    public void LoadGame(string filename)
    {
        string goal;
        string description;
        int points;
        bool isComplete;
        int bonusPoints;
        int desiredAccomplishments;
        int currentAccomplishments;
        
        string[] lines = System.IO.File.ReadAllLines(filename+".txt");

        _totalPoints = int.Parse(lines[0]);
        
        for(int i = 1; i< lines.Length; i++)
        {
            string[] splitLine = lines[i].Split(";");
            goal = splitLine[1].ToString();
            description = splitLine[2].ToString();
            points = int.Parse(splitLine[3]);
            isComplete = bool.Parse(splitLine[4].ToString());

            if (splitLine[0].Equals("SimpleGoal"))
            {
                SimpleGoal(goal, description, points, isComplete);
            }
            else if(splitLine[0].Equals("EternalGoal"))
            {
                currentAccomplishments = int.Parse(splitLine[5].ToString());
                
                EternalGoal(goal, description, points, isComplete, currentAccomplishments);
            }
            else if(splitLine[0].Equals("CheckListGoal"))
            {
                currentAccomplishments = int.Parse(splitLine[5].ToString());

                desiredAccomplishments = int.Parse(splitLine[6].ToString());
                
                bonusPoints = int.Parse(splitLine[7].ToString());

                CheckListGoal(goal, description, points, isComplete, bonusPoints, desiredAccomplishments, currentAccomplishments);
            }
        }
    }

    public void Menu()
    {
        string option = "9";
        while (option != "q")
        {
            Console.Clear();
            Console.WriteLine("\tEternal Quest");
            Console.WriteLine($"\t\t\tCurrent points: {_totalPoints}");
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
                Console.Clear();
                    ListGoals();
                    Console.ReadLine();
                break;
                case "2":
                    NewGoal();
                break;
                case "3":
                    EventGoal();
                break;
                case "4":
                    string filename;
                    Console.WriteLine("Type a name to save your current goals");
                    filename = Console.ReadLine();
                    SaveGame(filename);
                break;
                case "5":
                    Console.WriteLine("Type your goals file's name");
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