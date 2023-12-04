class Immunization
{
    private DateOnly _date;
    private string _description;
    private string _place;
    private int _targetDosis;
    private int _currentDosis;
    private bool _isComplete;

    public Immunization (string description, string place, DateOnly date, int currentDosis, bool isComplete, int targetDosis=1)
    {
        _description = description;
        _place = place;
        _date = date;
        _targetDosis = targetDosis;
        _currentDosis = currentDosis;
        _isComplete = isComplete;
    }

    public void AddDosis()
    {
        _date = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyy"));
        
        _currentDosis +=1;

        if (_currentDosis >= _targetDosis && !_isComplete)
        {
            _isComplete = true;
        }
    }

    public void SetComplete()
    {
        _isComplete = true;
    }

    public void SetDate(DateOnly date)
    {
        _date = date;
    }

    public string GetDescription()
    {
        return _description;
    }

    public DateOnly GetDate()
    {
        return _date;
    }

    public int GetDosis()
    {
        return _currentDosis;
    }

    public string GetImmunization()
    {
        if (_targetDosis > 1)
        {
            if(_isComplete)
            {
                return $"(X) - {_description} - {_place} - {_date} - Dosis:{_currentDosis}/{_targetDosis}";
            }
            else
            {
                return $"( ) - {_description} - {_place} - {_date} - Dosis:{_currentDosis}/{_targetDosis}";
            }
        }
        else
        {
            return $"(X) - {_description} - {_place} - {_date}";
        }
    }
}