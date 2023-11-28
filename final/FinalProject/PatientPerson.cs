class PatientPerson : Person
{
    private string _healthProvider;
    private int _healthProviderId;
    private string _art;
    private List<Immunization> _immunizations;
    private List<Allergy> _allergies;
    private List<Diagnostic> _problems;
    private List<Medication> _medications;
    private List<ClinicalHistory> _clinicalHistories;

    public PatientPerson(string name, string document, string docType, DateOnly dob, string healthProvider, int healthProviderId = -1, string art = null) :base (name, document, docType, dob)
    {
        _healthProvider = healthProvider;
        _healthProviderId = healthProviderId;
        _art = art;

        _immunizations = new List<Immunization>();
        _allergies = new List<Allergy>();
        _problems = new List<Diagnostic>();
        _medications = new List<Medication>();
        _clinicalHistories = new List<ClinicalHistory>();
    }

    public string GetHealthProvider()
    {
        return _healthProvider;
    }

    public ClinicalHistory GetLastClinicalHistory()
    {
        return _clinicalHistories.Last();
    }

    public List<ClinicalHistory> GetClinicalHistories()
    {
        return _clinicalHistories;
    } 

    public List<Immunization> GetImmunizations()
    {
        return _immunizations;
    }

    public List<Allergy> GetAllergies()
    {
        return _allergies;
    }

    public void AddImmunization(string description, string place, int targetDosis, int currentDosis, bool isComplete)
    {
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        
        Immunization immunization = new Immunization(description, place, date, currentDosis, isComplete, targetDosis);
    }

    override public string GetPersonSpecificData()
    {
        if(_art != null)
        {
            return $"{_healthProvider}: {_healthProviderId} - ART: {_art}";
        }

        return $"{_healthProvider}: {_healthProviderId}";
    }
}