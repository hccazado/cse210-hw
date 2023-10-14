public class Scripture
{
    private List<Word> _words;

    private Reference _reference;

    private int _hiddenWordsCount;


    public Scripture (string book, int chapter, int verse, string text)
    {
        _reference = new Reference(book, chapter, verse);
        _hiddenWordsCount = 0;
        _words = new List<Word>();
        CreateWordsArray(text);
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
            if (i == _words.Count){
                scriptureWords += _words[i].GetWord();
            }
            else{
                scriptureWords += _words[i].GetWord()+" ";
            }
        }

        return scriptureWords;
    }

    public string GetReference()
    {
        return _reference.GetReference();
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        int wordsLength = _words.Count;

        int visibleWords = wordsLength - _hiddenWordsCount;

        int i = 0;

        while (i <= 2 ) 
        {
            if ( i == visibleWords){
                break;
            }
            int randomIndex = random.Next(0, wordsLength);
            
            if (_words[randomIndex].GetVisibility())
            {
                _words[randomIndex].SetHidden();
                
                _hiddenWordsCount +=1;
                
                i++;
            }

        }
    }

}