using System.Dynamic;
using System.Text.Json.Serialization;

class Medication
{
    private string _snomedCtId;
    private DateOnly _date;
    private string _administration;
    private string _dosis;
    private string _description;

    public Medication (DateOnly date, string description, string administration, string dosis, string snomed = null)
    {
        _snomedCtId = snomed;
        _date = date;
        _administration = administration;
        _dosis = dosis;
        _description = description;
    }

    public void SetSnomedCtId(string snomed)
    {
        _snomedCtId = snomed;
    }

    public void SetAdministration(string administration)
    {
        _administration = administration;
    }

    public void SetDosis(string dosis)
    {
        _dosis = dosis;
    }

    public void SetDescription(string desc)
    {
        _description = desc;
    }

    public string GetSnomedCtID()
    {
        return _snomedCtId;
    }

    public string GetAdministration()
    {
        return _administration;
    }

    public string GetDosis()
    {
        return _dosis;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetMedication()
    {
        if (_snomedCtId != null)
        {
            return $"{_description} - Dosis: {_dosis} - Administration: {_administration} - {_date}. SnomedCT: {_snomedCtId}";
        }
        else
        {
            return $"{_description} - Dosis: {_dosis} - Administration: {_administration} - {_date}";
        }
    }
}