using System.Drawing;

class SimpleGoal : Goal
{
    public SimpleGoal(string goal, string description, int points, bool isComplete) : base(goal, description, points, isComplete)
    {
    }

    public override string DescribeGoal()
    {
        if (_isComplete)
        {
            return $"(X) {_goal} - {_description} : worths {_points} points";
        }
        else{
            return $"( ) {_goal} - {_description} : worths {_points} points";
        }
    }

    public override string GoalSavingData()
    {
        return $"SimpleGoal;{_goal};{_description};{_points};{_isComplete}";
    }

    public override int GoalEvent()
    {
        if (_isComplete)
        {
            return 0;
        }
        else{
            _isComplete = true;
            return _points;
        }
    }
}