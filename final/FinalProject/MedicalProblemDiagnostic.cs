class MedicalProblemDiagnostic : Diagnostic
{
    public MedicalProblemDiagnostic(string description, DateOnly date, string snomed=null, string icd=null): base(description,date,snomed,icd)
    {
    }    
    public override string GetDiagnostic()
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
}