public class Scripture
{
   
    private List<Word> _words;
    private int _hiddenWords;

    private Reference _reference;

    public Scripture (string book, int chapter, int verse, string text)
    //All attributes are required for instantiating a new object of this class
    {
        _words = new List<Word>();

        _reference = new Reference(book, chapter, verse);
        
        CreateWordsArray(text);

        _hiddenWords = 0;
    }

    //public Scripture (string book, int chapter, int startVerse, int endVerse, string text)
    public Scripture (List<Scripture> scriptures)
    //All attributes are required for instantiating a new object of this class
    {
        string book = scriptures[0].GetBook();
        int chapter = scriptures[0].GetChapter();
        
        int lastIndex = scriptures.Count - 1;
        
        int startVerse = scriptures[0].GetVerse();
        
        int endVerse = scriptures[lastIndex].GetVerse();
        
        _words = new List<Word>();
        
        _reference = new Reference(book, chapter, startVerse, endVerse);

        foreach(var scripture in scriptures)
        {
            _words.AddRange(scripture.GetWordsArray());
        }

        _hiddenWords = 0;
    }

    public string GetReference()
    {
        return _reference.GetReference();
    }

    public string GetBook()
    {
        return _reference.GetBook();
    }

    public int GetChapter()
    {
        return _reference.GetChapter();
    }

    public int GetVerse()
    {
        return _reference.GetStartVerse();
    }

     public string GetWords()
    /*iterates the list _words to concatenate its members into a string to be returned. 
     ->Each word returns its value or a string of "_" according to its visibility*/
    {
        string words = "";

        for( int i = 0; i< _words.Count; i++)
        {
            if (i == _words.Count)
            {
                words += _words[i].GetWord();
            }
            else
            {
                words += _words[i].GetWord()+" ";
            }
        }

        return words;
    }

    public List<Word> GetWordsArray()
    {
        return _words;
    }

    private void CreateWordsArray(string text)
    //splits parameter string insto an array of string for adding each word into reference List of Word
    {
        string[] splitText = text.Split(" ");

        foreach(var currentWord in splitText)
        {
            Word word = new Word(currentWord);

            _words.Add(word); 
        }
    }
   
    public bool HideRandomWords()
    /*Randomly calls setHidden from up to three Words elements from _words list.
      Returns: true - if there still any word to be hidden
               false - all _words elements are already hidden*/
    {
        Random random = new Random();

        int wordsLength = _words.Count;

        int visibleWords = wordsLength - _hiddenWords;

        int i = 0;

        while (i <= 2 ) 
        {
            int randomIndex = random.Next(0, wordsLength);
            
            if ( visibleWords <= 0){
                return false;
            }
            
            //checks if the item corresponding to the random index stills visible
            if (!_words[randomIndex].IsHidden())
            {
                //set the random item to hidden
                _words[randomIndex].SetHidden();
                
                _hiddenWords +=1;
                visibleWords -=1;
                
                i++;
            }
        }
        //returning false for preventing another running when after a successful while there's no lefting words to hide
        if (visibleWords == 0){
            return false;
        }
        return true;
    }
    public void VerifyHiddenWords(string input)
    //calls each Word from _words List to compare user input with their own value.
    //decreases the counter for hiddenwords if there is a match
    {
        bool updated = false;

        foreach(var word in _words)
        {
            updated = word.CompareWord(input);

            if(updated){
                _hiddenWords -= 1;
            }
        }
    } 
}