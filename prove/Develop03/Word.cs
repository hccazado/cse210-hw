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

    public Word (string word, Boolean visible)
    {
        _word = word;
        _isVisible = visible;
    }

    public string GetWord()
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

    public void CompareWord(string input)
    {
        if (_word.ToUpper().Equals(input.ToUpper()))
        {
            SetVisible();
        }
    }
}