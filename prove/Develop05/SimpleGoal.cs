using System.Drawing;

class SimpleGoal : Goal
{
    public SimpleGoal(string goal, string description, int points, bool isComplete) : base(goal, description, points, isComplete)
    {
    }

    public override string DescribeGoal()
    //overriding and defining an adequate function scope for describing the goal
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
    //overriding and defining an adequate function scope for returning goal's saving data
    {
        return $"SimpleGoal;{_goal};{_description};{_points};{_isComplete}";
    }

    public override int GoalEvent()
    //overriding and defining an adequate function scope for accomplishing the goal
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