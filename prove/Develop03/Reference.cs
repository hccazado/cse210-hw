using System.Runtime.CompilerServices;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    //Public constructor for a single scripture as parameter
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    //Public constructor for a single scripture as parameter
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public string GetReference()
    {
        if(_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else{
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
    
}