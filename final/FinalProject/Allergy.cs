class Allergy
{
    private string _snomedCtId;
    private string _icd10;
    private string _description;

    public Allergy(string description, string snomed = null, string icd=null)
    {
        _snomedCtId = snomed;
        _icd10 = icd;
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

    public string GetDescription()
    {
        return _description;
    }

    public string GetIcd()
    {
        return _icd10;
    }

    public string GetAllergy()
    {
        if (_snomedCtId != null && _icd10 != null)
        {
            return $"SnomedCT: {_snomedCtId} - ICD10: {_icd10} - Desc: {_description}";
        }

        else if(_snomedCtId == null)
        {
            return $"ICD10: {_icd10} - Desc: {_description}";
        }

        else
        {
            return $"SnomedCT: {_snomedCtId} - Desc: {_description}";
        }
    }
}