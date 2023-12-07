using System.Reflection.Metadata;

class IllnessDiagnostic : Diagnostic
{
    private bool _isActive;
    private DateOnly _finishDate;

    public IllnessDiagnostic(string description, DateOnly date, bool isActive, string snomed=null, string icd=null, DateOnly finishDate = default): base(description, date, snomed, icd)
    {
        _isActive = isActive;
        _finishDate = finishDate;
    }

    public void SetActive()
    {
        _isActive = true;
    }

    public void UnsetActive()
    {
        _isActive = false;
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public override string GetDiagnostic()
    {
        if(_isActive)
        {
            if (_snomedCtId != null && _icd10 != null)
            {
                return $"SnomedCT: {_snomedCtId} | ICD10: {_icd10} | {_date} | Desc: {_description}";
            }

            else if(_snomedCtId == null)
            {
                return $"ICD10: {_icd10} | {_date} | Desc: {_description}";
            }

            else if(_icd10 == null)
            {
                return $"SnomedCT: {_snomedCtId} | {_date} | Desc: {_description}";
            }
            else
            {
                return $"{_date} | Desc: {_description}";
            }
        }
        else
        {
            if (_snomedCtId != null && _icd10 != null)
            {
                return $"SnomedCT: {_snomedCtId} | ICD10: {_icd10} | {_date} - {_finishDate} | Desc: {_description}";
            }

            else if(_snomedCtId == null)
            {
                return $"ICD10: {_icd10} | {_date} - {_finishDate} | Desc: {_description}";
            }

            else if(_icd10 == null)
            {
                return $"SnomedCT: {_snomedCtId} | {_date} - {_finishDate} | Desc: {_description}";
            }
            else
            {
                return $"{_date} - {_finishDate} | Desc: {_description}";
            }
        }
    }
}