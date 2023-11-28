abstract class Diagnostic
{
    protected string _snomedCtId;
    protected string _icd10;
    protected string _description;
    protected DateOnly _date;

    public Diagnostic(string description, DateOnly date, string snomed=null, string icd=null)
    {
        _snomedCtId = snomed;
        _icd10 = icd;
        _date = date;
        _description = description;
    }

    public void SetSnomedCtId(string id)
    {
        _snomedCtId = id;
    }

    public void SetDescription(string desc)
    {
        _description = desc;
    }

    public void SetIcd(string icd)
    {
        _icd10 = icd;
    }

    public string GetSnomedCtID()
    {
        return _snomedCtId;
    }

    public string GetIcd()
    {
        return _icd10;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract string GetDiagnostic();    
}