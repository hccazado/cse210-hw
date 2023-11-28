using System.ComponentModel.Design;

class HealthCenter
{
    private List<PatientPerson> _patients;
    private List<ProfessionalPerson> _doctors;
    private PatientPerson _currentPatient;
    private ProfessionalPerson _currentDoctor;

    public HealthCenter()
    {
        _patients = new List<PatientPerson>();
        _doctors = new List<ProfessionalPerson>();
    }

    public void Menu()
    {

    }

    private void NewPatient(string name, string document, string docType, DateOnly dob, string healthProvider = null, int healthProviderId = -1, string art=null)
    {
        PatientPerson newPatient = new PatientPerson(name, document, docType, dob, healthProvider, healthProviderId, art);
        _patients.Add(newPatient);
    }

    private void NewDoctor(string name, string document, string docType, DateOnly dob, string register, string professionalActivity)
    {
        ProfessionalPerson newDoctor = new ProfessionalPerson(name, document, docType, dob, register, professionalActivity);
        _doctors.Add(newDoctor);
    }
    
    private void LoadPatients(string filename)
    {

    }    
    
    private void LoadDoctors(string filename)
    {

    } 

    private void DisplayPatientData()
    {

    }

    private void DisplayDoctor()
    {

    }

    private void DisplayPatientAllergies()
    {

    }

    private void DisplayPatientImmunizations()
    {

    }

    private void DisplayPatientMedications()
    {

    }

    private void DisplayPatientClinicalHistory(int id = -1)
    {

    }

    private void AddPatientAllergy()
    {

    }

    private void AddPatientMedication()
    {

    }

    private void AddPatientIllness()
    {

    }

    private void AddPatientClinicalHistory()
    {

    }

    private void UpdateProfessionalActivityStatus()
    {
        
    }
}