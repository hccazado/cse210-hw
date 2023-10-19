using Microsoft.VisualBasic.FileIO;

public static class AppData
{
    private static readonly List <Scripture> _scriptures;

    //static constructor runs only once, at the first call to class
    static AppData() {
        _scriptures = LoadFromFile();
    }

    private static List<Scripture> LoadFromFile()
    {
        List<Scripture>scriptures = new List<Scripture>();
        //creating a new instance of TextFieldParser from VisualBasic.FileIO
        using(TextFieldParser parser = new TextFieldParser("lds-scriptures.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            //skipping file's 1st line
            if(!parser.EndOfData)
            {
                parser.ReadLine();
            }
            
            //reading file's lines
            while(!parser.EndOfData)
            {    
                //parsing csv line's fields into an array
                string[] data = parser.ReadFields();

                string book = data[5];
                //string shortBook = data[13];

                int chapter = int.Parse(data[14]);
                int verse = int.Parse(data[15]);
                string text = data[16];

                //creating a new scripture object with current line data
                Scripture scripture = new Scripture(book, chapter, verse, text);

                //adding scripture object to _scriptures list
                scriptures.Add(scripture);
            }
            return scriptures;
        }
    }
    public static List<Scripture> GetList()
    //returns the list with all loaded scriptures
    {
        return _scriptures;
    }

    public static Scripture RandomReference()
    //Picks a random index in _scriptures array and return a new instance of Reference with index associated scripture
    {
        Random random = new Random();
        
        //picking a random index from scriptures list
        int index = random.Next(0, _scriptures.Count);
        
        //instantiating a new reference object with scripture from random index
        return _scriptures[index];
    }

    public static List<Scripture> SpecificReference(string book, string chapter, string verses)
    //finds the scriptures that match the parameters and returns a list with one or more scriptures
    {
        string[] splitVerses = verses.Split("-");

        //temporary list for holding user's scriptures selection
        List<Scripture>selectedScriptures = new List<Scripture> ();
        try{
            //Treating compound verse scenario
            if(verses.Count() > 1 && int.Parse(splitVerses[0]) != int.Parse(splitVerses[1]))
            {   
                for (int i = int.Parse(splitVerses[0]); i <= int.Parse(splitVerses[1]); i++)
                {
                    //Finding user informed scripture
                    Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == i);

                    //adding found scripture into selectio array
                    selectedScriptures.Add(scripture);
                    
                }
            }
            //Treating single verse scripture scenario
            else{
                //finding user desired scripture
                Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == int.Parse(splitVerses[0]));
                
                //adding found scripture into selectio array
                selectedScriptures.Add(scripture);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("An error has ocurred!\nPress enter to continue");
            Console.ReadLine();
        }
        return selectedScriptures;
    }
}