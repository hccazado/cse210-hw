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
        return $"() {_goal} - {_description} : worths {_points} points. Accomplished: {_accomplishments} times.";
    }

    public override int GoalEvent()
    {
        _accomplishments ++;
        return _points;
    }

    public int Penaltie()
    {
        return -_points;
    }
}