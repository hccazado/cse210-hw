public class Scripture 
{
    public string _reference;

    public string _text;

    public List<Scripture> _scriptures = new List<Scripture>();

    public Scripture()
    {
        _reference = "";
        _text = "";
        LoadScriptures();
    }

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    private void LoadScriptures()
    //load the BoM.csv file into a list of scriptures
    { 
        string fileName = "BoM.csv";
        
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] splitLine = line.Split(";");

            Scripture scripture = new Scripture (splitLine[1], splitLine[0]);

            _scriptures.Add(scripture);
        }
    }

    public void DisplayRandomScripture()
    //Picks a random index from scriptures array and call scripture's DisplayScripture method.
    {
        Random random = new Random();

        int randomScriptureIndex = random.Next(_scriptures.Count);

        _scriptures[randomScriptureIndex].DisplayScripture();
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"{_reference}: {_text}");
    }
}