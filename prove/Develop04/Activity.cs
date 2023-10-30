class Activity
{
    string _name;
    string _description;
    int _duration;

    Activity()
    {
        _name = "Undefined";
        _description = "Description not defined";
        _duration = 0;
    }

    Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public string GetDuration()
    {
        return _name;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public string WelcomeMessage()
    {
        return $"Welcome to {_name} Activity\n{_description}";
    }

}