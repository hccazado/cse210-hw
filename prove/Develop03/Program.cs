using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


class Program
{
    private static string _userInput;

    private static Scripture _memorizeScripture;

    private static bool _stillPlaying;

    private static List<Scripture> _scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
        File _file = new File();

        _scriptures = _file.GetScripturesList();
    
        _userInput = "";

        _stillPlaying = true;

        List<Scripture> searchResult; 

        while (!_userInput.Equals("quit"))
        {
            Console.Clear();
            Console.WriteLine("\tScripture Memorizer - CSE210\n");
            Console.WriteLine("   1    -    Try a random scripture");
            Console.WriteLine("   2    -    Inform a scripture to memorize");
            Console.WriteLine("   3    -    Inform a scripture to memorize (RegEX)");
            Console.WriteLine("quit    -    Anytime finish the program");
            Console.Write("\nYour choice: ");
            _userInput = Console.ReadLine();

            switch (_userInput){

                case "1":
                    _memorizeScripture = RandomScripture();
                    Memorize(_memorizeScripture);
                break;

                case "2":
                    Console.Write("Book (genesis): ");
                    string book = Console.ReadLine();

                    Console.Write("\nChapter: ");
                    string chapter = Console.ReadLine();

                    Console.Write("\nVerses: (1 or 1-7): ");
                    string verses = Console.ReadLine();

                    searchResult = SearchScripture(book, chapter, verses);

                    if (searchResult.Count == 1)
                    {
                        _memorizeScripture = searchResult[0];
                    }
                    else{
                        _memorizeScripture = new Scripture(searchResult);
                    } 

                    if (!String.IsNullOrEmpty(_memorizeScripture.ToString()))
                    {
                        Memorize(_memorizeScripture);
                    }
                break;

                case "3":
                    Console.WriteLine("Type the scripture (1 Nephi 2:2 or 1 Nephi 2:4-6):");
                    Console.Write("> ");
                    
                    _userInput = Console.ReadLine();

                    searchResult = EvaluateScriptureExpression(_userInput);

                    if (searchResult.Count == 1)
                    {
                        _memorizeScripture = searchResult[0];
                    }
                    else{
                        _memorizeScripture = new Scripture(searchResult);
                    } 

                    if (!String.IsNullOrEmpty(_memorizeScripture.ToString()))
                    {
                        Memorize(_memorizeScripture);
                    }
                break;

                case "quit":
                    Console.WriteLine("Bye!");
                    System.Environment.Exit(0);
                break;
            }
        }
    }

    private static string DisplayScripture()
    //Prints the scripture, refence and Words list
    {
        return $"{_memorizeScripture.GetReference()}\n{_memorizeScripture.GetWords()}";
    }

    private static void Memorize(Scripture scripture)
    /*loops user input to call HideRandomWords method from _memorizeScripture each time the user return an empty input;
      Calls VerifyHiddenWords from _memorizeScripture when the user return a value;
      Checks for a "quit" input, ending the application. Also, will end the application if the user return an empty input
      when there's no more words to be hidden.*/
    {
        string input = "";

        while (!input.Equals("quit"))
        {
            Console.Clear();
            Console.WriteLine($"{DisplayScripture()}");
            Console.Write("> ");
            input = Console.ReadLine();

            //empty input with lefting words to be hidden
            if (input.Equals("") && _stillPlaying)
            {
                _stillPlaying = scripture.HideRandomWords();
            }

            //not empty input, calls reference for verifying the input for any match
            else if (!input.Equals(""))
            {
                _stillPlaying = true;
                scripture.VerifyHiddenWords(input);
            }
            //empty input without anymore words to hide, will terminate the program
            else if (input.Equals("") && !_stillPlaying)
            {
                System.Environment.Exit(0);
            }
        }
        System.Environment.Exit(0);
    }

    private static List<Scripture> SearchScripture(string book, string chapter, string verses)
    //finds the scriptures that match the parameters and returns a list with one or more scriptures
    {
        string[] splitVerses = verses.Split("-");

        //temporary list for holding user's scriptures selection
        List<Scripture>selectedScriptures = new List<Scripture> ();
        try{
            //Treating compound verse scenario
            if(verses.Count() > 1 && int.Parse(splitVerses[0]) != int.Parse(splitVerses[1]))
            {   
                for (int i = int.Parse(splitVerses[0]); i <= int.Parse(splitVerses[1]); i++)
                {
                    //Finding user informed scripture
                    Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == i);

                    //adding found scripture into selectio array
                    selectedScriptures.Add(scripture);
                    
                }
            }
            //Treating single verse scripture scenario
            else{
                //finding user desired scripture
                Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == book.ToUpper() && 
                                                                        scripture.GetChapter() == int.Parse(chapter) &&
                                                                        scripture.GetVerse() == int.Parse(splitVerses[0]));
                
                //adding found scripture into selectio array
                selectedScriptures.Add(scripture);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("An error has ocurred!\nPress enter to continue");
            Console.ReadLine();
        }
        return selectedScriptures;
    }

    public static Scripture RandomScripture()
    //Picks a random index in _scriptures array and return a new instance of Reference with index associated scripture
    {
        Random random = new Random();
        
        //picking a random index from scriptures list
        int index = random.Next(0, _scriptures.Count);
        
        //instantiating a new reference object with scripture from random index
        return _scriptures[index];
    }

    public static List<Scripture> EvaluateScriptureExpression(string userInput)
    //Evaluates user input as an regular expression, and returns a list containing user's scriptures
    {
        MatchCollection matches;

        string pattern;

        string GetBook(string userInput)
        {
            pattern = @"((\d*) (\w*))|(\w*)";

            matches = Regex.Matches(userInput, pattern);

            return matches[0].Groups[0].Value;
        }

        string GetChapter(string userInput)
        //returns 2nd position from regex matches since it corresponds to the 1st group of matches' pattern 
        {
            pattern = @" (\d*):";

            matches = Regex.Matches(userInput, pattern);

            return matches[0].Groups[1].Value;
        }

        string GetVerses(string userInput)
        {

            pattern = @":(\d*)-(\d*)|:(\d*)";

            matches = Regex.Matches(userInput, pattern);

            //Regex matched for one single verse, 3 group of match
            //returns 4th index because the the 1st contains the expression
            if (matches[0].Groups[1].Value.Equals(""))
            {
                return matches[0].Groups[3].Value;
            }
            //Regex matched first pattern, multiple verses, again index o holds the entire expression
            //concatenating 2nd and 3rd groups from match, which corresponds to initial and final versicles
            else
            {
                string verses = "";
                verses = matches[0].Groups[1].Value;

                verses +="-"+matches[0].Groups[2].Value;

                return verses;
            }            
        }

        //returning the result from SpecificScripture Method

        string book = GetBook(userInput);
        string chapter = GetChapter(userInput);
        string verses = GetVerses(userInput);

        return SearchScripture(book, chapter, verses);
    }
}