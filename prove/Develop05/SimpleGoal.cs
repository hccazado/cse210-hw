class SimpleGoal : Goal
{
    public SimpleGoal(string goal, string description, int points, bool isComplete) : base(goal, description, points, isComplete)
    {
    }

    public override string DescribeGoal()
    {
        if (_isComplete)
        {
            return $"() {_goal}"
        }
    }
}