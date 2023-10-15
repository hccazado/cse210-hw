using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

class Program
{
    private static string _userInput;

    private static Reference _reference;

    private static List<Scripture> _scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
    
        LoadScripturesFile();

        _userInput = "";

        bool stillHidding = true;

        while (!_userInput.Equals("quit"))
        {
            Console.Clear();
            Console.WriteLine("\tScripture Memorizer - CSE210\n");
            Console.WriteLine("1 -    Try a random scripture");
            Console.WriteLine("2 -    Inform a scripture to memorize");
            Console.WriteLine("quit - Anytime finish the program");
            Console.Write("\nYour choice: ");
            _userInput = Console.ReadLine();

            switch (_userInput){

                case "1":
                    RandomReference();
                break;

                case "2":
                    Console.WriteLine("Inform the book, chapter, verse(s) (genesis,1,1-3)");
                    
                    Console.Write("\nscripture: ");

                    _userInput = Console.ReadLine();

                    specificReference(_userInput);
                break;

                case "quit":
                    System.Environment.Exit(0);
                break;

                default:
                    Console.WriteLine("Invalid option!\nType return to try again!");
                break;
            }

            Console.WriteLine($"{DisplayReference()}");

            if (_userInput.Equals("") && stillHidding)
            {
                stillHidding = _reference.HideRandomWords();
            }
            else if (!_userInput.Equals(""))
            {
                _reference.VerifyHiddenWords(_userInput);
            }
            else if (_userInput.Equals("") && !stillHidding)
            {
                
            }
        } 
        
    }

    private static string DisplayReference()
    {
        return $"{_reference.GetReference()} - {_reference.GetWords()}";
    }

    private static void RandomReference()
    {
        Random random = new Random();

        int index = random.Next(0, _scriptures.Count);
        
        _reference = new Reference(_scriptures[index]);
    }

    private static void specificReference(string input)
    {
        string[] splitInput = input.Split(",");
        string[] verses = splitInput[2].Split("-");
        if(verses.Count() > 1)
        {
            List<Scripture>selection = new List<Scripture> ();
            for (int i = int.Parse(verses[0]); i < int.Parse(verses[1]); i++)
            {
                Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == splitInput[0].ToUpper() && 
                                                                    scripture.GetChapter() == int.Parse(splitInput[1]) &&
                                                                    scripture.GetVerse() == i);

                selection.Add(scripture);
                
            }
            _reference = new Reference(selection);
        }

        else{
            Scripture scripture = _scriptures.Find(scripture => scripture.GetBook().ToUpper() == splitInput[0].ToUpper() && 
                                                                    scripture.GetChapter() == int.Parse(splitInput[1]) &&
                                                                    scripture.GetVerse() == int.Parse(splitInput[2]));

            _reference = new Reference(scripture);
        }
    }

    private static void LoadScripturesFile()
    {
        //creating a new instance of TextFieldParser from VisualBasic.FileIO
        using(TextFieldParser parser = new TextFieldParser("lds-scriptures.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            //skipping the read of 1st line since it's the header
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