public class Scripture 
{
    public string _reference;

    public string _text;

    public void DisplayScripture()
    {
        Console.WriteLine($"{_reference}: {_text}");
    }
}