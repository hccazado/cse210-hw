using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;

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
        _currentDoctor = null;
        _currentPatient = null;
    }

    public void Menu()
    {
        string choice = "0";

        void PatientMenu(){
            if(_currentPatient != null)
            {
                Console.WriteLine("\tPatient Options");
                DisplayPatientData();

                Console.WriteLine("1  - New Medication");
                Console.WriteLine("2  - New Allergy");
                Console.WriteLine("3  - New Illness");
                Console.WriteLine("4  - New Immunization");
                Console.WriteLine("5  - Add Immunization Dosis");
                Console.WriteLine("6  - New Clinical History");
                Console.WriteLine("7  - Display Patient's Allergies");
                Console.WriteLine("8  - Display Patient's Medical Problems");
                Console.WriteLine("9  - Display Patient's Medications");
                Console.WriteLine("10 - Display Patient's Immunizations");
                Console.WriteLine("11 - Display Patient's Latest Clinical History");
                Console.WriteLine("0  - Return\n");
                Console.Write("Choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PatientNewMedication();
                    break;
                    case "2":
                        PatientNewAllergy();
                    break;
                    case "3":
                        PatientNewIllness();
                    break;
                    case "4":
                        PatientNewImmunization();
                    break;
                    case "5":
                        PatientAddImmunizationDosis();
                    break;
                    case "6":
                        if(_currentDoctor != null && _currentDoctor.isActive())
                        {   
                            PatientNewClinicalHistory();
                        }
                        else
                        {
                            Console.WriteLine("An active doctor must be selected for this action! Press any key to continue.");
                            Console.ReadKey();
                        }
                    break;
                    case "7":
                        DisplayPatientAllergies();
                    break;
                    case "8":
                        DisplayPatientIllnesses();
                    break;
                    case "9":
                        DisplayPatientMedications();
                    break;
                    case "10":
                        DisplayPatientImmunizations();
                    break;
                    case "11":
                        DisplayPatientClinicalHistories();
                    break;
                    case "q":
                    break;
                    default:
                        Console.WriteLine("Invalid option! Returning to main menu.\nPress any key to continue");
                        Console.ReadKey();
                    break; 
                }
            }
            else{
                Console.WriteLine("There is no selected patient! Press any key to return");
                Console.ReadKey();
            }
        }

        void ManagementMenu(){
            Console.WriteLine("\t\tManagement Options");
            Console.WriteLine("1 - New Patient");
            Console.WriteLine("2 - New Doctor");
            Console.WriteLine("3 - Enable current Doctor");
            Console.WriteLine("4 - Disable current Doctor");
            Console.WriteLine("5 - Select A New Patient");
            Console.WriteLine("6 - Select A New Doctor");
            Console.WriteLine("0 - Return\n");
            Console.Write("Choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _currentPatient = NewPatientData();
                    PersonNewAddress(_currentPatient);
                break;
                case "2":
                    _currentDoctor = NewDoctorData();
                    PersonNewAddress(_currentDoctor);
                break;
                case "3":
                    if (_currentDoctor != null)
                    {
                        Console.WriteLine($"Are sure about ENABLING (Y / N):\nDr {_currentDoctor.GetPersonalData()}\n");
                        Console.Write("Choice: ");
                        string agreed = Console.ReadLine();
                        if (agreed.Equals("Y"))
                        {
                            UpdateProfessionalActivityStatus(true);
                            Console.WriteLine("Enabled!");
                            Console.WriteLine("Press any key to continue!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("A Doctor must be selected! Press any key to continue");
                        Console.ReadKey();
                    }
                break;
                case "4":
                    if (_currentDoctor != null)
                    {
                        Console.WriteLine($"Are sure about DISABLING (Y / N):\nDr {_currentDoctor.GetPersonalData()}\n");
                        Console.Write("Choice: ");
                        string agreed = Console.ReadLine();
                        if (agreed.Equals("Y"))
                        {
                            UpdateProfessionalActivityStatus(false);
                            Console.WriteLine("Disabled! Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("A Doctor must be selected! Press any key to continue");
                        Console.ReadKey();
                    }        
                break;
                case "5":
                    SelectPatient();
                break;
                case "6":
                    SelectDoctor();
                break;
                case "0":
                break;
                default:
                    Console.WriteLine("Invalid option! Returning to main menu.\nPress any key to continue");
                    Console.ReadKey();
                break;
            }
            
        }
        
        while(choice != "q" || choice != "quit")
        {
            Console.Clear();
            Console.WriteLine("\t\tIntegrated Public Health System\n");
            Console.WriteLine("1 - System Management");
            Console.WriteLine("2 - Patient's Menu");
            Console.WriteLine("3 - Display Curent Doctor's Data");
            Console.WriteLine("q - Quit System\n");
            Console.Write("Choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManagementMenu();
                break;
                case "2":
                    PatientMenu();
                break;
                case "3":
                    DisplayDoctor();
                break;
                case "q":
                case "quit":
                    System.Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("Invalid option! Press any key to continue");
                    Console.ReadKey();
                break;
            }
            Console.WriteLine("Bye!");
        }
    }

    private PatientPerson NewPatientData()
    {
        Console.Clear();
        Console.WriteLine("\tAdding New Patient");
        Console.WriteLine("Patient's name:");
        string name = Console.ReadLine();

        Console.WriteLine("Patient's Birthday(dd/mm/yyyy):");
        DateOnly dob = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Patient's document type:");
        string docType = Console.ReadLine();

        Console.WriteLine("Patient's document number:");
        string document = Console.ReadLine();

        Console.WriteLine("Patient's Health Provider (NA for none):");
        string hProvider = Console.ReadLine();

        Console.WriteLine("Patient's Health Provider ID (0 for none):");
        int hProviderId = int.Parse(Console.ReadLine());        
        
        Console.WriteLine("Patient's ART (blank for none)");
        string art = Console.ReadLine();

        return NewPatient(name, document, docType, dob, hProvider, hProviderId, art);        
    }

    private ProfessionalPerson NewDoctorData(){
        Console.Clear();
        Console.WriteLine("\tAdding New Doctor");
        Console.WriteLine("Doctor's name:");
        string name = Console.ReadLine();

        Console.WriteLine("Doctor's Birthday(dd/mm/yyyy):");
        DateOnly dob = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Doctor's document type:");
        string docType = Console.ReadLine();

        Console.WriteLine("Doctor's document number:");
        string document = Console.ReadLine();

        Console.WriteLine("Doctor's Register:");
        string register = Console.ReadLine();

        Console.WriteLine("Doctor's Activity:");
        string activity = Console.ReadLine();

        return NewDoctor(name, document, docType, dob, register, activity, true);        
    }

    private void PersonNewAddress(Person person)
    {
        Console.Clear();
        Console.WriteLine($"\tAdding person address");
        Console.WriteLine("street:");
        string address = Console.ReadLine();

        Console.WriteLine("Number:");
        string num = Console.ReadLine();

        Console.WriteLine("City:");
        string city = Console.ReadLine();

        Console.WriteLine("State:");
        string state = Console.ReadLine();

        Console.WriteLine("ZIP:");
        string zip = Console.ReadLine();

        Console.WriteLine("Country:");
        string country = Console.ReadLine();

        PersonAddress(person,address, num, city, state, zip, country);
    }

    private void PersonAddress(Person person, string address, string number, string city, string state, string zip, string country=null)
    {
        person.SetAddress(address, number, city, state, zip, country);
    }

    private PatientPerson NewPatient(string name, string document, string docType, DateOnly dob, string healthProvider = null, int healthProviderId = -1, string art=null)
    {
        PatientPerson newPatient = new PatientPerson(name, document, docType, dob, healthProvider, healthProviderId, art);
        
        _patients.Add(newPatient);

        return newPatient;
    }

    private ProfessionalPerson NewDoctor(string name, string document, string docType, DateOnly dob, string register, string professionalActivity, bool isActive)
    {
        ProfessionalPerson newDoctor = new ProfessionalPerson(name, document, docType, dob, register, professionalActivity, isActive);
        
        _doctors.Add(newDoctor);

        return newDoctor;
    }
    
    private void SelectPatient()
    {
        if( _patients.Count > 0)
        {
            for (int i = 0; i < _patients.Count; i++)
            {
                Console.WriteLine($"{i+1} - {_patients[i].GetPersonalData()} - {_patients[i].GetPersonSpecificData()}");
            }
            Console.Write("Patient number: ");

            int option = int.Parse(Console.ReadLine()); 

            _currentPatient = _patients[option-1];
        }
    }    
    
    private void SelectDoctor()
    {
        if( _doctors.Count > 0)
        {
            for (int i = 0; i < _doctors.Count; i++)
            {
                Console.WriteLine($"{i+1} - {_doctors[i].GetPersonalData()} - {_doctors[i].GetPersonSpecificData()}");
            }
            Console.Write("Doctor number: ");

            int option = int.Parse(Console.ReadLine()); 

            _currentDoctor = _doctors[option-1];
        }
    } 

    private void DisplayPatientData()
    {
        if(_currentPatient == null)
        {
            Console.WriteLine("There's no selected patient! Press any key to continue.");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("------------------Patient-------------------");
            Console.WriteLine($"{_currentPatient.GetPersonalData()}\n{_currentPatient.GetPersonSpecificData()}");
            Console.WriteLine("---------------------------------------------");
        }
    }

    private void DisplayDoctor()
    {
        if(_currentDoctor == null)
        {
            Console.WriteLine("There's no selected doctor! Press any key to continue.");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("------------------Doctor---------------------");
            Console.WriteLine($"{_currentDoctor.GetPersonalData()}\n{_currentDoctor.GetPersonSpecificData()}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    private void DisplayPatientAllergies()
    {
        Console.Clear();
        Console.WriteLine("Patient Allergies:");

        _currentPatient.DisplayAllergies();

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void DisplayPatientImmunizations()
    {

        Console.Clear();
        Console.WriteLine("Patient Immunizations:");
        _currentPatient.DisplayImmunizations();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void PatientNewImmunization()
    {
        bool isComplete;
        Console.Clear();
        Console.WriteLine("\tAdding Patient's New Immunization");
        
        DateOnly date = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyy"));
        
        Console.WriteLine("Description:");
        string description = Console.ReadLine();

        Console.WriteLine("place:");
        string place = Console.ReadLine();

        Console.WriteLine("current dosis:");
        int currentDosis = int.Parse(Console.ReadLine());

        Console.WriteLine("target dosis:");
        int targetDosis = int.Parse(Console.ReadLine());

        Console.WriteLine("is the schema complete (y/n):");
        string complete = Console.ReadLine();

        if (complete == "y" || complete == "Y")
        {
            isComplete = true;
        }
        else
        {
            isComplete = false;
        }

        AddPatientImmunization(description, place, targetDosis, currentDosis, isComplete);
    }

    private void PatientAddImmunizationDosis()
    {
        int immunizationIdx;

        Console.Clear();
        _currentPatient.DisplayImmunizations();

        Console.WriteLine("Type Immunization number to add a dosis:");
        immunizationIdx = int.Parse(Console.ReadLine());

        _currentPatient.AddImmunizationDosis(immunizationIdx -1);
    }

    private void DisplayPatientMedications()
    {
        Console.Clear();
        Console.WriteLine("Patient Medications:");
        _currentPatient.DisplayMedications();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void DisplayPatientIllnesses()
    {
        Console.Clear();
        Console.WriteLine("Patient Illnesses:");
        _currentPatient.DisplayIllnesses();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void DisplayPatientClinicalHistories()
    {
        List<ClinicalHistory> histories = _currentPatient.GetClinicalHistories();
        Console.Clear();
        Console.WriteLine("Patient Clical Histories:\n");

        foreach(var history in histories)
        {
            Console.WriteLine(history.GetSummary());
        }
        
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }

    private void PatientNewAllergy()
    {
        Console.Clear();
        Console.WriteLine("\tAdding Patient's New Allergy");
        Console.WriteLine("Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Snomed CT(optional):");
        string snomed = Console.ReadLine();

        Console.WriteLine("ICD-10(optional):");
        string icd = Console.ReadLine();

        AddPatientAllergy(description,snomed,icd);
    }

    private void AddPatientAllergy(string description, string snomed=null, string icd=null)
    {
        _currentPatient.AddAllergy(description, snomed, icd);
    }

    private void AddPatientImmunization(string description, string place, int targetDosis, int currentDosis, bool isComplete)
    {
        _currentPatient.AddImmunization(description, place, targetDosis, currentDosis, isComplete);
    }

    private void PatientNewMedication()
    {
        Console.Clear();
        Console.WriteLine("\tAdding Patient's New Medication");
        Console.WriteLine("Medication Starting Date (dd/mm/yyyy):");
        DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Administration:");
        string administration = Console.ReadLine();

        Console.WriteLine("Dosis:");
        string dosis = Console.ReadLine();

        Console.WriteLine("Snomed CT(optional):");
        string snomed = Console.ReadLine();

        AddPatientMedication(date, description, administration, dosis, snomed);
    }
    private void AddPatientMedication(DateOnly date, string description, string administration, string dosis, string snomed = null)
    {
        _currentPatient.AddMedication(date, description, administration, dosis, snomed);
    }

    private void PatientNewIllness()
    {   
        Console.Clear();
        Console.WriteLine("\tAdding Patient's New Illness Diagnostic");
        Console.WriteLine("Illness Starting Date (dd/mm/yyyy):");
        DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Snomed CT(optional):");
        string snomed = Console.ReadLine();

        Console.WriteLine("Illness ICD-10(optional):");
        string icd = Console.ReadLine();

        Console.WriteLine("Illness Still Active(Y / N):");
        string active = Console.ReadLine();

        if (active.Equals("Y") || active.Equals("y") || active.Equals("Yes"))
        {
            AddPatientIllness(description, date, true, snomed, icd);
        }
        else
        {
            Console.WriteLine("Illness Finish Date (dd/mm/yyyy):");
            DateOnly finishDate = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            AddPatientIllness(description, date, false, snomed, icd, finishDate);
        }
    }

    private void AddPatientIllness(string description, DateOnly date, bool isActive, string snomed=null, string icd=null, DateOnly finishDate = default)
    {
        _currentPatient.AddIllness(description, date, isActive, snomed, icd, finishDate);
    }

    public void PatientNewClinicalHistory()
    {
        List<Medication> medications = new List<Medication>();

        MedicalProblemDiagnostic medicalProblem;
        
        void Diagnostic()
        {
            Console.Clear();
            Console.WriteLine("\tClinical History - Diagnostic");
            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Snomed CT(optional):");
            string snomed = Console.ReadLine();

            Console.WriteLine("Illness ICD-10(optional):");
            string icd = Console.ReadLine();

            DateOnly date = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyy"));

            medicalProblem = new MedicalProblemDiagnostic(description, date, snomed, icd);
        }

        void Medications()
        {
            string choice = "y";
            DateOnly date = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyy"));

            while (choice.Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("\tNew Clinical History - Medication");
                Console.WriteLine("Description:");
                string description = Console.ReadLine();

                Console.WriteLine("Administration:");
                string administration = Console.ReadLine();

                Console.WriteLine("Dosis:");
                string dosis = Console.ReadLine();

                Console.WriteLine("Snomed CT(optional):");
                string snomed = Console.ReadLine();

                Medication medication = new Medication(date, description, administration, dosis, snomed);

                medications.Add(medication);

                Console.WriteLine("\nAdd a new medication (y/n):");
                choice = Console.ReadLine();
            }
        }

        Console.Clear();
        Console.WriteLine("\tNew Clinical History");
        
        Console.WriteLine("Reason of Visit:");
        string reasonVisit = Console.ReadLine();

        Console.WriteLine("Temperature (°C):");
        double temperature = double.Parse(Console.ReadLine());

        Console.WriteLine("Blood Pressure (12.3/8.7):");
        string bp = Console.ReadLine();

        Console.WriteLine("Physical Examination Traits:");
        string pe = Console.ReadLine();

        Diagnostic();

        Medications();

        DateOnly date = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyy"));

        AddPatientClinicalHistory(date, _currentDoctor, reasonVisit, temperature, bp, pe, medicalProblem, medications);
    }    

    private void AddPatientClinicalHistory(DateOnly date, ProfessionalPerson doctor, string reasonVisit, double temperature, string bp, string pe, MedicalProblemDiagnostic medicalProblem, List<Medication> medications,int id=default)
    {
        _currentPatient.AddClinicalHistory(date, doctor, reasonVisit, temperature, bp, pe, medicalProblem, medications, id);
    }

    private void UpdateProfessionalActivityStatus(bool isActive)
    {
        if (isActive)
        {
            _currentDoctor.SetActive();
        }
        else
        {
            _currentDoctor.UnsetActive();
        }
    }
}