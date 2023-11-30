using System.Runtime.CompilerServices;

class ClinicalHistory
{
    private int _id;
    private DateOnly _date;
    private ProfessionalPerson _doctor;
    private string _reasonVisit;
    private double _temperature;
    private string _bloodPressure;
    private string _physicalExam;
    private MedicalProblemDiagnostic _medicalProblem;
    private List<Medication> _medications;
    
    public ClinicalHistory(int id, DateOnly date, ProfessionalPerson doctor, string reasonVisit, double temperature, string bp, string pe, MedicalProblemDiagnostic medicalProblem, List<Medication> medications)
    {
        _id = id;
        _date = date;
        _doctor = doctor;
        _reasonVisit = reasonVisit;
        _temperature = temperature;
        _bloodPressure = bp;
        _physicalExam = pe;
        _medicalProblem = medicalProblem;
        _medications = medications;
    }

    public string GetReasonVisit()
    {
        return _reasonVisit;
    }

    public List<Medication> GetMedications()
    {
        return _medications;
    }

    public MedicalProblemDiagnostic GetDiagnostic()
    {
        return _medicalProblem;
    }

    public double GetTemperature()
    {
        return _temperature;
    }

    public string GetBloodPressure()
    {
        return _bloodPressure;
    }

    private void DisplayMedications()
    {
        foreach(var medication in _medications)
        {
            Console.WriteLine(medication.GetMedication());
        }
    }

    public bool CompareId(int id)
    {
        if (id == _id)
        {
            return true;
        }
        return false;
    }

    public string GetSummary()
    {
        return $"ID:{_id} - Date: {_date}.\nReason of Visit: {_reasonVisit}\nDiagnostic: {_medicalProblem.GetDiagnostic}\nMedication: {DisplayMedications}";
    }
}