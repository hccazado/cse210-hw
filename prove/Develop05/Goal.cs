abstract class Goal
{
    protected string _goal;
    protected string _description;

    protected int _points;

    protected bool _isComplete;
    
    public Goal(string goal, string description, int points, bool isComplete)
    {
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public abstract string DescribeGoal();

    public abstract int GoalEvent();

    public abstract string GoalSavingData();
}