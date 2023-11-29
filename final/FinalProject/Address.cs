class Address
{
    private string _address;
    private string _number;
    private string _zip;
    private string _city;
    private string _state;
    private string _country;

    public Address (string address, string number, string city, string state, string zip, string country=null)
    {
        _address = address;
        _number = number;
        _zip = zip;
        _city = city;
        _state = state;
        _country = country;
    }

    public Address()
    {
        _address = "NA";
        _number = "-99";
        _zip = "S2000";
        _city = "NA";
        _state = "NA";
        _country = "AR";
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

    public void SetCountry(string country)
    {
        _country = country;
    }

    public string GetAddress()
    {
        if (_country != null)
        {
            return $"{_number},{_address} - {_city}, {_state} - {_zip} - {_country}";
        }

        return $"{_number},{_address} - {_city}, {_state} - {_zip}";
    }
}