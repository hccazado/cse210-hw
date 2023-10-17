using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

class Program
{
    private static string _userInput;

    private static Reference _reference;

    private static bool _stillPlaying;

    private static List<Scripture> _scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
    
        LoadScripturesFile();

        _userInput = "";

        _stillPlaying = true;

        while (!_userInput.Equals("quit"))
        {
            Console.Clear();
            Console.WriteLine("\tScripture Memorizer - CSE210\n");
            Console.WriteLine("   1    -    Try a random scripture");
            Console.WriteLine("   2    -    Inform a scripture to memorize");
            Console.WriteLine("quit    -    Anytime finish the program");
            Console.Write("\nYour choice: ");
            _userInput = Console.ReadLine();

            switch (_userInput){

                case "1":
                    _reference = RandomReference();
                    Memorize(_reference);
                break;

                case "2":
                    Console.Write("Book (genesis): ");
                    string book = Console.ReadLine();

                    Console.Write("\nChapter: ");
                    string chapter = Console.ReadLine();

                    Console.Write("\nVerses: (1 or 1-7): ");
                    string verses = Console.ReadLine();

                    _reference = SpecificReference(book, chapter, verses);

                    if (_reference != null)
                    {
                        Memorize(_reference);
                    }
                break;

                case "quit":
                    Console.WriteLine("Bye!");
                    System.Environment.Exit(0);
                break;
            }
        }
    }

    private static string DisplayReference()
    //Prints the reference and its associated Words list
    {
        return $"{_reference.GetReference()}: {_reference.GetWords()}";
    }

    private static void Memorize(Reference reference)
    /*loops user input to call HideRandomWords method from _reference each time the user return an empty input;
      Calls VerifyHiddenWords from _reference when the user return a value;
      Checks for a "quit" input, ending the application. Also, will end the application if the user return an empty input
      when there's no more words to be hidden.*/
    {
        string input = "";

        while (!input.Equals("quit"))
        {
            Console.Clear();
            Console.WriteLine($"{DisplayReference()}");
            Console.Write("> ");
            input = Console.ReadLine();

            //empty input with lefting words to be hidden
            if (input.Equals("") && _stillPlaying)
            {
                _stillPlaying = reference.HideRandomWords();
            }

            //not empty input, calls reference for verifying the input for any match
            else if (!input.Equals(""))
            {
                _stillPlaying = reference.VerifyHiddenWords(input);
            }
            //empty input without anymore words to hide, will terminate the program
            else if (input.Equals("") && !_stillPlaying)
            {
                System.Environment.Exit(0);
            }
        }
        System.Environment.Exit(0);
    }

    private static Reference RandomReference()
    //Picks a random index in _scriptures array and return a new instance of Reference with index associated scripture
    {
        Random random = new Random();
        
        //picking a random index from scriptures list
        int index = random.Next(0, _scriptures.Count);
        
        //instantiating a new reference object with scripture from random index
        return new Reference(_scriptures[index]);
    }

    private static Reference SpecificReference(string book, string chapter, string verses)
    {
        string[] splitVerses = verses.Split("-");
        try{
            //Treating compound verse scenario
            if(verses.Count() > 1 && int.Parse(splitVerses[0]) != int.Parse(splitVerses[1]))
            {
                //temporary list for holding user's scriptures selection
                List<Scripture>selection = new List<Scripture> ();
                for (int i = int.Parse(splitVerses[0]); i <= int.Parse(splitVerses[1]); i++)
                {
                    //Finding user informed scripture
                    Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == i);

                    //adding found scripture into temporary array
                    selection.Add(scripture);
                    
                }
                //instantiating a new Reference object with the temporary list as parameter
                return new Reference(selection);
            }
            //Treating single verse scripture scenario
            else{
                //finding user desired scripture
                Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == int.Parse(splitVerses[0]));
                
                //instantiating a new reference object with user selected scripture as parameter
                return new Reference(scripture);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("An error has ocurred!\nPress enter to continue");
            Console.ReadLine();
            return _reference;
        }
    }

    private static void LoadScripturesFile()
    {
        //creating a new instance of TextFieldParser from VisualBasic.FileIO
        using(TextFieldParser parser = new TextFieldParser("lds-scriptures.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            //skipping file's 1st line
            if(!parser.EndOfData)
            {
                parser.ReadLine();
            }
            
            //reading file's lines
            while(!parser.EndOfData)
            {    
                //parsing csv line's fields into an array
                string[] data = parser.ReadFields();

                string book = data[5];
                //string shortBook = data[13];

                int chapter = int.Parse(data[14]);
                int verse = int.Parse(data[15]);
                string text = data[16];

                //creating a new scripture object with current line data
                Scripture scripture = new Scripture(book, chapter, verse, text);

                //adding scripture object to _scriptures list
                _scriptures.Add(scripture);
            }
        }
    }
}