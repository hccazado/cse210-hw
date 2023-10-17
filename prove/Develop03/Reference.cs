using System.Runtime.CompilerServices;

public class Reference
{
    private Scripture _scripture;
    private string _verse;
    private List<Word> _words;
    private int _hiddenWords;

    public Reference(Scripture scripture)
    //Public constructor for a single scripture as parameter
    {
        _scripture = scripture;

        _hiddenWords = 0;

        _verse = _scripture.GetVerse()+"";

        _words = new List<Word>();
        
        //converting scripture text into a List of Word 
        CreateWordsArray(scripture.GetText());
    }

    public Reference(List<Scripture> scriptures)
    /*constructor for composed(List) scriptures 
    concatenate each scripture text, and create a list of Word*/
    {
        //only the first scripture is stored for keeping book and chapter references
         _scripture = scriptures[0];

        _hiddenWords = 0;

        //concatenating verses from 1st and last scripture
        _verse = $"{scriptures[0].GetVerse()} - {scriptures.Last().GetVerse()}";

        string text = "";

        //iterating through each scripture from parameter referred list
        foreach(var scripture in scriptures)
        {
            //concatenating each scripture text
            text += scripture.GetText()+" ";
        }
        //instantiating a List of Word to hold previously concatenated texts
        _words = new List<Word>();

        CreateWordsArray(text);
    }

    public string GetReference()
    {
        return $"{_scripture.GetBook()} {_scripture.GetChapter()}, {_verse}";
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

    public string GetWords()
    /*iterates the list _words to concatenate its members into a string to be returned. 
     ->Each word returns its value or a string of "_" according to its visibility*/
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
            if (_words[randomIndex].GetVisibility())
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

    public bool VerifyHiddenWords(string input)
    //calls each Word from _words List to compare user input with their own value.
    {
        bool updated = false;

        foreach(var word in _words)
        {
            updated = word.CompareWord(input);

            if(updated){
                _hiddenWords -= 1;
            }
        }
        //forcily returns true for keeping the program running even if the user don't guess any word
        return true;
    }

}