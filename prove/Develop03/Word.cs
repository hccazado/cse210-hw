using System.Collections.Specialized;

public class Word
{
    private string _word;
    private bool _isVisible;

    public Word (string word)
    {
        _word = word;
        _isVisible = true;
    }

    public string GetWord()
    //returns _word real value if _isVisible is defined as true, or returns a string of "_" 
    //with the same length from _word
    {
        if (_isVisible)
        {
            return _word;
        }
        else
        {
            return new string('*',_word.Length);
        }
    }

    public bool GetVisibility()
    {
        return _isVisible;
    }

    public void SetHidden()
    {
        _isVisible = false;
    }

    public void SetVisible()
    {
        _isVisible = true;
    }

    public bool CompareWord(string input)
    //compares _word with input parameterm, and calls SetVisible if there's a match.
    {
        bool updated = false;
        if (_word.ToUpper().Equals(input.ToUpper()))
        {
            SetVisible();
            updated = true;
        }
        return updated;
    }
}