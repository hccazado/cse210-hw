class CheckListGoal : Goal
{
    private int _bonusPoints;
    private int _desiredAccomplishments; 
    private int _currentAccomplishments;
    public CheckListGoal(string goal, string description, int points, bool isComplete, int bPoints, int desiredAccomplishments, int currentAccomplishments) : base(goal, description, points, isComplete)
    {
        _bonusPoints = bPoints;
        _desiredAccomplishments = desiredAccomplishments;
        _currentAccomplishments = currentAccomplishments;
    }

    public override string DescribeGoal()
    //overriding and defining an adequate function scope for describing the goal
    {
        if (_isComplete)
        {
            return $"(X) {_goal} - {_description} : worths {_points} points {_currentAccomplishments}/{_desiredAccomplishments} times (bonus points: {_bonusPoints})";
        }
        else{
            return $"( ) {_goal} - {_description} : worths {_points} points {_currentAccomplishments}/{_desiredAccomplishments} times (bonus points: {_bonusPoints})";
        }
    }

    public override string GoalSavingData()
    //overriding and defining an adequate function scope for returning goal's saving data
    {
        return $"CheckListGoal;{_goal};{_description};{_points};{_isComplete};{_currentAccomplishments};{_desiredAccomplishments};{_bonusPoints}";
    }

    public override int GoalEvent()
    //overriding and defining an adequate function scope for accomplishing the goal
    {
        int returnPoints = 0;
        if (_isComplete)
        {
            returnPoints = 0;
        }
        else
        {
            _currentAccomplishments++;
                
            returnPoints = _bonusPoints;
                
            if(_currentAccomplishments == _desiredAccomplishments)
            {
                _isComplete = true;
                returnPoints += _points;
            }
        }
        return returnPoints;
    }
}