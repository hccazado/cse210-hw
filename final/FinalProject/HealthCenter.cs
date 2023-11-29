using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;

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
        string document;

        void ManagementMenu(){
            Console.WriteLine("\t\tManagement Options");
            Console.WriteLine("1 - New Patient");
            Console.WriteLine("2 - New Doctor");
            Console.WriteLine("3 - Enable current Doctor");
            Console.WriteLine("4 - Disable current Doctor");
            Console.WriteLine("5 - Save System State");
            Console.WriteLine("6 - Load System State");
            Console.WriteLine("0 - Return\n");
            Console.Write("Choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _currentPatient = NewPatientData();
                    PersonAddressMenu(_currentPatient);
                break;
                case "2":
                    _currentDoctor = NewDoctorData();
                    PersonAddressMenu(_currentDoctor);
                break;
                case "3":
                    if (_currentDoctor != null)
                    {
                        Console.WriteLine($"Are sure about ENABLING (Y / N):\nDr {_currentDoctor.GetPerson}\n");
                        Console.Write("Choice: ");
                        string agreed = Console.ReadLine();
                        if (agreed.Equals("Y"))
                        {
                            _currentDoctor.SetActive();
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
                        Console.WriteLine($"Are sure about DISABLING (Y / N):\nDr {_currentDoctor.GetPerson}\n");
                        Console.Write("Choice: ");
                        string agreed = Console.ReadLine();
                        if (agreed.Equals("Y"))
                        {
                            _currentDoctor.UnsetActive();
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
                break;
                case "6":
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
            Console.WriteLine("2 - Find a Doctor");
            Console.WriteLine("3 - Find a Patient");
            Console.WriteLine("4 - Patient Data");
            Console.WriteLine("5 - Display Patient's Allergies");
            Console.WriteLine("6 - Display Patient's Medical Problems");
            Console.WriteLine("7 - Display Patient's Medications");
            Console.WriteLine("8 - Display Patient's Last Clinical History\n");
            Console.WriteLine("q - Quit System\n");
            Console.Write("Choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManagementMenu();
                break;
                case "2":
                    Console.WriteLine("Type doctor's document:");
                    document = Console.ReadLine(); 
                break;
                case "3":
                    ManagementMenu();
                break;
                case "4":
                    ManagementMenu();
                break;
                case "5":
                    ManagementMenu();
                break;
                case "6":
                    ManagementMenu();
                break;
                case "7":
                    ManagementMenu();
                break;
                case "8":
                    ManagementMenu();
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

    private void FindDoctor(string document)
    {
        foreach(var doctor in _doctors)
        {
            if (doctor.ComparePerson(document))
            {
                _currentDoctor = doctor;
            }   
        }
    }

    private void FindPatient(string document)
    {
        foreach(var patient in _patients)
        {
            if (patient.ComparePerson(document))
            {
                _currentPatient = patient;
            }   
        }
    }

    private PatientPerson NewPatientData(){
        Console.WriteLine("Patient's name:");
        string name = Console.ReadLine();

        Console.WriteLine("Patient's Birthday(dd/mm/yyyy):");
        DateOnly dob = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Patient's document type:");
        string docType = Console.ReadLine();

        Console.WriteLine("Patient's document number:");
        string document = Console.ReadLine();

        Console.WriteLine("Patient's Health Provider:");
        string hProvider = Console.ReadLine();

        Console.WriteLine("Patient's Health Provider ID:");
        int hProviderId = int.Parse(Console.ReadLine());        
        
        Console.WriteLine("Patient's ART");
        string art = Console.ReadLine();

        return NewPatient(name, document, docType, dob, hProvider, hProviderId, art);        
    }

    private ProfessionalPerson NewDoctorData(){
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

    private void PersonAddressMenu(Person person)
    {
        Console.WriteLine("Address:");
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