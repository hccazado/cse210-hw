public class Scripture
{
    private string _text;
    private string _book;
    private int _chapter;
    private int _verse;

    public Scripture (string book, int chapter, int verse, string text)
    //All attributes are required for instantiating a new object of this class
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _text = text;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public string GetText()
    {
        return _text;
    } 
}