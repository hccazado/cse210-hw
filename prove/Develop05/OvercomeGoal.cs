using System.Drawing;

class OvercomeGoal : Goal
{
    public OvercomeGoal(string goal, string description, int points, bool isComplete) : base(goal, description, points, isComplete)
    {
    }

    public override string DescribeGoal()
    //overriding and defining an adequate function scope for describing the goal
    {
        if (_isComplete)
        {
            return $"(X) {_goal} - {_description} : worths -{_points} points";
        }
        else{
            return $"( ) {_goal} - {_description} : worths -{_points} points";
        }
    }

    public override string GoalSavingData()
    //overriding and defining an adequate function scope for returning goal's saving data
    {
        return $"OvercomeGoal;{_goal};{_description};{_points};{_isComplete}";
    }

    public override int GoalEvent()
    //overriding and defining an adequate function scope for accomplishing the goal
    {
        string answer;
        Console.WriteLine($"Have you overcome '{_goal}'?\n1 - yes\n2 - no");
        answer = Console.ReadLine();
        if(answer == "1" || answer == "yes")
        //set goal as complete and return twice points amount as prize
        {
            _isComplete = true;
            return 2 * _points;
        }
        else
        {
            return Penaltie();
        }
    }

    public int Penaltie()
    //returning goal's points as negative value for penaltie
    {
        return -_points;
    }
}