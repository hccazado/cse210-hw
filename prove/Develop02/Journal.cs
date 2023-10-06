using System.Runtime.CompilerServices;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private static DateTime _date = DateTime.Now;

    public void NewEntry()
    {
        
        Prompt promptList = new Prompt();

        int promptIndex = promptList.GetRandomPrompt(GetUsedPromptsOnCurrentDate());

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

    private List<int> GetUsedPromptsOnCurrentDate()
    {

        List<int> prompts = new List<int>();

        foreach (var entry in _entries)
        {
            if (entry._date.ToShortDateString() == _date.ToShortDateString()){

                prompts.Add(entry._prompt);
            }
        }

        return prompts;
    }

    public void ShowJournalEntries()
    {

        if (_entries.Any())
        {
            foreach(var entry in _entries)
            {
                entry.DisplayEntry();
            }

            Console.WriteLine("Press Enter To Continue!");
            
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("You Don't Have Any New Entry In Your Journal Yet.");
            
            Console.WriteLine("Press Enter To Continue!");
            
            Console.ReadLine();
        }
    } 

    public void SaveCsvJournal(string fileName)
    {
        if (_entries.Any())
        {
            using (StreamWriter output = new StreamWriter(fileName))
            {
                output.WriteLine("sep=;");

                output.WriteLine("date;promptIndex;response");
            
                foreach(var entry in _entries)
                {
                    output.WriteLine($"{entry._date};{entry._prompt};{entry._response}");
                }
            }
        }
        else
        {
            Console.WriteLine("Your journal doesn't have any item to be saved!\nPress Enter to continue!");

            Console.ReadLine();
        }
    }

    public void LoadCsvJournal(string fileName)
    //Try to load user's specified journal name
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            
            for (int i = 2; i< lines.Length; i++)
            //indext starts on 3rd line, for skiping csv separator definition and csv header
            { 
                Entry entry = new Entry();

                string[] splitLine = lines[i].Split(";");

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

            Console.WriteLine("Press Enter to continue!");

            Console.ReadLine();
        }
    }
    
}