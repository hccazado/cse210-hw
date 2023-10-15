public class Reference
{
    private Scripture _scripture;
    private string _verse;
    private List<Word> _words;
    private int _hiddenWordsCount;

    public Reference(Scripture scripture)
    {
        _scripture = scripture;

        _hiddenWordsCount = 0;

        _verse = _scripture.GetVerse()+"";

        _words = new List<Word>();
        Console.WriteLine(scripture.GetText());
        CreateWordsArray(scripture.GetText());
    }

    public Reference(List<Scripture> scriptures)
    {
         _scripture = scriptures[0];

        _hiddenWordsCount = 0;

        _verse = $"{scriptures[0].GetVerse()}-{scriptures[-1].GetVerse()}";

        string text = "";

        foreach(var scripture in scriptures)
        {
            text += scripture.GetText()+" ";
        }
        Console.WriteLine(text);
        _words = new List<Word>();

        CreateWordsArray(text);
    }

    public string GetReference()
    {
        return $"{_scripture.GetBook()} {_verse}";
    }

    private void CreateWordsArray(string text)
    {
        string[] splitText = text.Split(" ");

        foreach(var currentWord in splitText)
        {
            Word word = new Word(currentWord, true);
            _words.Add(word);
        }
    }

    public string GetWords()
    {
        string scriptureWords = "";

        for( int i = 0; i< _words.Count; i++)
        {
            if (i == _words.Count)
            {
                scriptureWords += _words[i].GetWord();
            }
            else
            {
                scriptureWords += _words[i].GetWord()+" ";
            }
        }

        return scriptureWords;
    }

    public bool HideRandomWords()
    {
        Random random = new Random();

        int wordsLength = _words.Count;

        int visibleWords = wordsLength - _hiddenWordsCount;

        int i = 0;

        while (i <= 2 ) 
        {
            if ( i == visibleWords){
                return false;
            }
            int randomIndex = random.Next(0, wordsLength);
            
            if (_words[randomIndex].GetVisibility())
            {
                _words[randomIndex].SetHidden();
                
                _hiddenWordsCount +=1;
                
                i++;
            }

        }
        return true;
    }

    public void VerifyHiddenWords(string input)
    {
        foreach(var word in _words)
        {
            word.CompareWord(input);
        }
    }

}