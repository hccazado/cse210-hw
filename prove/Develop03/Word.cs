using System.Collections.Specialized;

public class Word
{
    private string _word;
    private bool _isHidden;

    public Word (string word)
    {
        _word = word;
        _isHidden = false;
    }

    public string GetWord()
    //returns _word real value if _isVisible is defined as true, or returns a string of "_" 
    //with the same length from _word
    {
        if (!_isHidden)
        {
            return _word;
        }
        else
        {
            return new string('*',_word.Length);
        }
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void SetHidden()
    {
        _isHidden = true;
    }

    public void UnSetHidden()
    {
        _isHidden = false;
    }

    public bool CompareWord(string input)
    //compares _word with input parameterm, and calls UnSetHidden if there's a match.
    {
        bool updated = false;
        if (_word.ToUpper().Equals(input.ToUpper()))
        {
            UnSetHidden();
            updated = true;
        }
        return updated;
    }
}