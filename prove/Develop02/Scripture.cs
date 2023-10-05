public class Scripture 
{
    public string _reference;

    public string _text;

    public Scripture()
    {
        _reference = "";
        _text = "";
    }

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"{_reference}: {_text}");
    }
}