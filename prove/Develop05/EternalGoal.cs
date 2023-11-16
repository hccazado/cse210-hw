using System.Runtime.InteropServices;

class EternalGoal : Goal 
{
    int _accomplishments;

    public EternalGoal (string goal, string description, int points, bool isComplete, int accomplishments) : base(goal, description, points, isComplete)
    {
        _accomplishments = accomplishments;
    }

    public override string DescribeGoal()
    {
        return $"( ) {_goal} - {_description} : worths {_points} points. Accomplished: {_accomplishments} times.";
    }

    public override string GoalSavingData()
    {
        return $"EternalGoal;{_goal};{_description};{_points};{_isComplete};{_accomplishments}";
    }

    public override int GoalEvent()
    {
        string answer;
        Console.WriteLine($"Have you '{_goal}' today?\n1 - yes\n2 - no");
        answer = Console.ReadLine();
        if(answer == "1" || answer == "yes")
        {
            _accomplishments ++;
            return _points;
        }
        else
        {
            return Penaltie();
        }
        
    }

    public int Penaltie()
    {
        return -_points;
    }
}