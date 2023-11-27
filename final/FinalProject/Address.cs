class Address
{
    private string _address;
    private string _number;
    private string _zip;
    private string _city;
    private string _state;

    public Address (string address, string number, string zip, string city, string state)
    {
        _address = address;
        _number = number;
        _zip = zip;
        _city = city;
        _state = state;
    }

    public void SetAddress(string address)
    {
        _address = address;
    }

    public void SetNumber(string number)
    {
        _number = number;
    }

    public void SetZip(string zip)
    {
        _zip = zip;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetAddress()
    {
        return $"{_number},{_address} - {_city}, {_state} - {_zip}";
    }
}