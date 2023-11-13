abstract class Goal
{
    protected string _goal;
    protected string _description;

    protected int _points;

    protected bool _isComplete;

    Goal()
    {
        _goal = "unknow";
        _description = "unknow";
        _points = -99;
        _isComplete = true;
    }

    public Goal(string goal, string description, int points, bool isComplete)
    {
        _goal = goal;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public abstract string DescribeGoal();

    public abstract int GoalEvent();

    public bool IsComplete()
    {
        return _isComplete;
    }
}