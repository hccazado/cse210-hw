using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Journal
{
    string choice = "-1";

    public List<Entry> _entries = new List<Entry>();

    public List<Scripture> _scriptures = new List<Scripture>();

    public DateTime _date = DateTime.Now;

    public Journal()
    {
        LoadScriptures();
    }

    public void DisplayMenu ()
    {

        

        while( choice != "5"){

            Console.Clear();
            
            Console.WriteLine("Welcome to the Journal Program!\n");

            DisplayRandomScripture();

            Console.WriteLine("\n|-----------Journal Main Menu---------------|");
            Console.WriteLine("|1 - Add a New Entry                        |");
            Console.WriteLine("|2 - Display Entries                        |");
            Console.WriteLine("|3 - Save Journal                           |");
            Console.WriteLine("|4 - Load Journal                           |");
            Console.WriteLine("|5 - Quit Journal Program                   |");
            Console.WriteLine("|6 - Show Json                              |");
            Console.WriteLine("|-------------------------------------------|");
            Console.WriteLine("Type your choice: ");
            
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    NewEntry();

                break;

                case "2":

                    ShowEntries();

                break;

                case "3":

                    string fileName;

                    Console.WriteLine("Please type a name for your journal");
        
                    fileName = Console.ReadLine();

                    SaveJournal(fileName);

                break;

                case "4":
                    
                    Console.WriteLine("Type the name of your journal:");

                    fileName = Console.ReadLine();

                    LoadJournal(fileName);

                break;

                case "5":

                    Console.WriteLine("Bye!");

                    System.Environment.Exit(1);

                break;

                case "6":

                    var opt = new JsonSerializerOptions(){ WriteIndented=true };

                    string entriesJson = JsonSerializer.Serialize(_entries, opt);
                    
                    Console.WriteLine(entriesJson);
                    Console.ReadLine();

                break;
                
                default:
                    Console.WriteLine("Invalid choice!");
                break;
            }
        }  
    }

    public void NewEntry(){
        Prompt promptList = new Prompt();

        int promptIndex = promptList.GetRandomPrompt(GetPromptsCurrentDate());

        string answer;

        if (promptIndex == -99)
        {
            
            Console.WriteLine("You've Already Answered Today's Questions!!!");
            
            Console.WriteLine("Press Any Key To Continue!");
            
            Console.ReadLine();
            
        }
        else
        {
        
            Console.WriteLine(promptList._prompts[promptIndex]);

            answer = Console.ReadLine();

            Entry entry = new Entry();

            entry._date = _date;

            entry._prompt = promptIndex;

            entry._response = answer;

            _entries.Add(entry);
        }
    }

    public List<int> GetPromptsCurrentDate(){

        List<int> prompts = new List<int>();

        foreach (var entry in _entries)
        {
            if (entry._date.ToShortDateString() == _date.ToShortDateString()){

                prompts.Add(entry._prompt);
            
            }
        }

        return prompts;
    }

    public void ShowEntries()
    {

        if (_entries.Any())
        {
            foreach(var entry in _entries)
            {
                entry.DisplayEntry();
            }

            Console.WriteLine("Press Any Key To Continue!");
            
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("You Don't Have Any New Entry In Your Journal Yet.");
            
            Console.WriteLine("Press Any Key To Continue!");
            
            Console.ReadLine();
        }
    } 

    public void SaveJournal(string fileName){

        if (_entries.Any()){

            using (StreamWriter output = new StreamWriter(fileName))
            {
                foreach(var entry in _entries)
                {
                    output.WriteLine($"{entry._date};{entry._prompt};{entry._response}");
                }
            }
        }
    }

    public void LoadJournal(string fileName)
    {
        try
        {

            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                
                Entry entry = new Entry();

                string[] splitLine = line.Split(";");

                Console.WriteLine(splitLine);

                entry._date = DateTime.Parse(splitLine[0]);

                entry._prompt = int.Parse(splitLine[1]);

                entry._response = splitLine[2];
                
                _entries.Add(entry);
            }
        }
        catch(FileNotFoundException error)
        {
            Console.WriteLine(error.Message);

            Console.WriteLine("Press any key to continue!");

            Console.ReadLine();
        }
    }
    
    public void LoadScriptures()
    {
        string fileName = "BoM.csv";
        
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Scripture scripture = new Scripture();

            string[] splitLine = line.Split(";");

            scripture._reference = splitLine[1];

            scripture._text = splitLine[0];

            _scriptures.Add(scripture);
        }
    }

    public void DisplayRandomScripture()
    {
        Random random = new Random();

        int randomScriptureIndex = random.Next(_scriptures.Count);

        _scriptures[randomScriptureIndex].DisplayScripture();
    }
}