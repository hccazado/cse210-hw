using Microsoft.VisualBasic.FileIO;

public class File
{
    private List <Scripture> _scriptures;

    public File() {
        _scriptures = new List<Scripture>();
        _scriptures = LoadFromFile();
    }

    private List<Scripture> LoadFromFile()
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

    public List<Scripture> GetScripturesList()
    {
        return _scriptures;
    }
}