using System.Globalization;
using System.Text.Json.Serialization;
class PatientPerson : Person
{
    private string _healthProvider;
    private int _healthProviderId;
    private string _art;
    private List<Immunization> _immunizations;
    private List<Allergy> _allergies;
    private List<IllnessDiagnostic> _illnesses;
    private List<Medication> _medications;
    private List<ClinicalHistory> _clinicalHistories;

    public PatientPerson(string name, string document, string docType, DateOnly dob, string healthProvider, int healthProviderId = -1, string art = null) :base (name, document, docType, dob)
    {
        _healthProvider = healthProvider;
        _healthProviderId = healthProviderId;
        _art = art;

        _immunizations = new List<Immunization>();
        _allergies = new List<Allergy>();
        _illnesses = new List<IllnessDiagnostic>();
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

    public void DisplayImmunizations()
    {
        for (int i = 0; i< _immunizations.Count;i++)
        {
            Console.WriteLine($"{i+1} - {_immunizations[i].GetImmunization()}");
        }
    }

    public void DisplayMedications()
    {
        foreach(var medication in _medications)
        {
            Console.WriteLine(medication.GetMedication());
        }
    }

    public void DisplayAllergies()
    {
        foreach(var allergy in _allergies)
        {
            Console.WriteLine(allergy.GetAllergy());
        }
    }

    public void DisplayIllnesses()
    {
        foreach(var illness in _illnesses)
        {
            Console.WriteLine(illness.GetDiagnostic());
        }
    }

    public void AddImmunization(string description, string place, int targetDosis, int currentDosis, bool isComplete)
    {
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        
        Immunization immunization = new Immunization(description, place, date, currentDosis, isComplete, targetDosis);

        _immunizations.Add(immunization);
    }

    public void AddImmunizationDosis(int id)
    {
        _immunizations[id].AddDosis();
    }

    public void AddAllergy(string description, string snomed=null, string icd=null)
    {
        Allergy allergy = new Allergy(description,snomed,icd);
        _allergies.Add(allergy);
    }

    public void AddMedication(DateOnly date, string description, string administration, string dosis, string snomed = null)
    {
        Medication medication = new Medication(date, description, administration, dosis, snomed);
        _medications.Add(medication);
    }

    public void AddIllness(string description, DateOnly date, bool isActive, string snomed=null, string icd=null, DateOnly finishDate = default)
    {
        IllnessDiagnostic illness = new IllnessDiagnostic(description, date, isActive, snomed=null, icd=null, finishDate = default);
        _illnesses.Add(illness);
    }

    
    public void AddClinicalHistory(DateOnly date, ProfessionalPerson doctor, string reasonVisit, double temperature, string bp, string pe, MedicalProblemDiagnostic medicalProblem, List<Medication> medications, int id=default)
    {
        if(id.Equals(default)){
            id = _clinicalHistories.Count + 1;
        }
        ClinicalHistory history = new ClinicalHistory(id, date, doctor, reasonVisit, temperature, bp, pe, medicalProblem, medications);
        _clinicalHistories.Add(history);
    }

    public string DisplayClinicalHistory()
    {

        ClinicalHistory history;
        if (_clinicalHistories.Count > 0)
        {
            history = _clinicalHistories.Last();
            return history.GetSummary();
        }
        else
        {
            return "Patient doesn't have any clinical history!";
        }
    }

    override public string GetPersonSpecificData()
    {
        if(_art != null)
        {
            return $"Coverage: {_healthProvider} - ID:{_healthProviderId} - ART: {_art}";
        }

        return $"Coverage: {_healthProvider} - ID:{_healthProviderId}";
    }

    public string GetPersonalData()
    {
        return GetPerson();
    }

}