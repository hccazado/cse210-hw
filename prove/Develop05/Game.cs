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

    private void NewSimpleGoal(string goal, string description, int points, bool isComplete)
    //Instantiates a new instance of SimpleGoal and add to _goals list. Used by NewGoal and LoadGame methods
    {
        SimpleGoal simpleGoal = new SimpleGoal(goal, description, points, isComplete);
        
        _goals.Add(simpleGoal);
    }

    private void NewEternalGoal(string goal, string description, int points, bool isComplete, int accomplishments)
    //Instantiates a new instance of EternalGoal and add to _goals list. Used by NewGoal and LoadGame methods
    {            
        EternalGoal eternalGoal = new EternalGoal(goal, description, points, isComplete, accomplishments);
        
        _goals.Add(eternalGoal);
    }
    
    private void NewCheckListGoal(string goal, string description, int points, bool isComplete, int bonusPoints, int desiredAccomplishments, int currentAccomplishments)
    //Instantiates a new instance of CheckListGoal and add to _goals list. Used by NewGoal and LoadGame methods
    {    
        CheckListGoal checkListGoal = new CheckListGoal(goal,description,points,isComplete,bonusPoints, desiredAccomplishments,currentAccomplishments);
        
        _goals.Add(checkListGoal);
    }

    private void NewOvercomeGoal(string goal, string description, int points, bool isComplete)
    //Instantiates a new instance of SimpleGoal and add to _goals list. Used by NewGoal and LoadGame methods
    {
        OvercomeGoal overcomeGoal = new OvercomeGoal(goal, description, points, isComplete);
        
        _goals.Add(overcomeGoal);
    }

    public void NewGoal()
    //Asks user desired its desired goal and its related data for passing as parameters to the adequate new goal method
    {
        string goal;
        string description;
        int points;
        int bonusPoints;
        int desiredAccomplishments;


        void GoalCommonData()
        //collects from user basic data for every goal
        {
            Console.WriteLine("Type the name of your goal:");
            goal = Console.ReadLine();
            
            Console.WriteLine("Type a small decription for your goal:");
            description = Console.ReadLine();
            
            Console.WriteLine("Type how many points for this goal (overcoming bad habits will assume a negative meaning):");
            string strPoints = Console.ReadLine();
            points = int.Parse(strPoints);
        }

        void CheckListSpecificData()
        //Asks user specific data for a checklist goal
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
        Console.WriteLine("4 - Overcome bad habits goal");
        Console.WriteLine("q - Cancel");

        Console.Write("> ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                GoalCommonData();

                NewSimpleGoal(goal, description, points, false);
            break;
            case "2":
                GoalCommonData();

                NewEternalGoal(goal, description, points, false, 0);
            break;
            case "3":
                GoalCommonData();

                CheckListSpecificData();

                NewCheckListGoal(goal, description, points, false, bonusPoints, desiredAccomplishments, 0);
            break;
            case "4":
                GoalCommonData();

                NewOvercomeGoal(goal, description, points, false);
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
    //displays all user's goals and asks for a goal to register its accomplishment.
    {
        if (_goals.Count >= 1)
        {
            string input;
            
            Console.Clear();
            
            ListGoals();

            Console.WriteLine("\nType the goal's number you want to record an accomplishment");

            input = Console.ReadLine();

            int index = int.Parse(input);

            _totalPoints += _goals[index - 1].GoalEvent();
        }
        else
        {
            Console.WriteLine("Sorry, you still not have any goals!\nPress any key to continue.");
            Console.ReadLine();
        }
    }

    public void ListGoals()
    //Displays all user's goals by calling DescribeGoal method from every goal
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
    //Writes game totalpoints into 1st line and all goals from _goals into a .txt file
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
    //loads game totalpoints and adds call the appropriate New[goal] method.
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
        
        //clearing list before adding items
        _goals.Clear();
        
        for(int i = 1; i< lines.Length; i++)
        {
            //splitting line content and attribuiting variables values
            string[] splitLine = lines[i].Split(";");
            goal = splitLine[1].ToString();
            description = splitLine[2].ToString();
            points = int.Parse(splitLine[3]);
            isComplete = bool.Parse(splitLine[4].ToString());

            if (splitLine[0].Equals("SimpleGoal"))
            {
                NewSimpleGoal(goal, description, points, isComplete);
            }
            else if (splitLine[0].Equals("OvercomeGoal"))
            {
                NewOvercomeGoal(goal, description, points, isComplete);
            }
            else if(splitLine[0].Equals("EternalGoal"))
            {
                currentAccomplishments = int.Parse(splitLine[5].ToString());
                
                NewEternalGoal(goal, description, points, isComplete, currentAccomplishments);
            }
            else if(splitLine[0].Equals("CheckListGoal"))
            {
                currentAccomplishments = int.Parse(splitLine[5].ToString());

                desiredAccomplishments = int.Parse(splitLine[6].ToString());
                
                bonusPoints = int.Parse(splitLine[7].ToString());

                NewCheckListGoal(goal, description, points, isComplete, bonusPoints, desiredAccomplishments, currentAccomplishments);
            }
        }
    }

    public void Menu()
    //Game main menu. Displays options and user totalpoints.
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