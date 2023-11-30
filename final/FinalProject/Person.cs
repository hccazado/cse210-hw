abstract class Person
{
    protected string _name;
    protected string _document;
    protected string _documentType;
    protected DateOnly _dob;
    protected Address _address;

    public Person(string name, string document, string docType, DateOnly dob)
    {
        _name = name;
        _document = document;
        _documentType = docType;
        _dob = dob;
    }

    protected string GetPerson()
    {
        return $"{_name} - Birthday: {_dob} - {_documentType}: {_document}";
    }

    public abstract string GetPersonSpecificData();

    public void SetAddress(string address, string number, string city, string state, string zip, string country=null)
    {
        _address = new Address(address, number, city, state, zip, country);
    }

    public void updateAddress(string address, string number, string city, string state, string zip, string country=null)
    {
        _address.SetAddress(address);
        _address.SetNumber(number);
        _address.SetCity(city);
        _address.SetState(state);
        _address.SetZip(zip);
        _address.SetCountry(country);
    }

    public string GetAddress()
    {
        return _address.GetAddress();
    }

    public bool ComparePerson(string document)
    {
        if(document == _document)
        {
            return true;
        }
        return false;
    }

}