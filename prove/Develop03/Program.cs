using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

class Program
{
    private static string _userInput;

    private static int _currentScripture;

    private static List<Scripture> _scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
    
        LoadScripturesFile();

        _userInput = "";

        bool stillHidding = true;

        _currentScripture = RandomScriptureIndex();

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

                break;

                case "2":

                break;

                case "quit":
                    System.Environment.Exit(0);
                break;

                default:
                    Console.WriteLine("Invalid option!\nType return to try again!");
                break;
            }

            Console.WriteLine($"{DisplayScripture()}");

            if (_userInput.Equals("") && stillHidding)
            {
                stillHidding = _scriptures[_currentScripture].HideRandomWords();
            }
            else if (!_userInput.Equals(""))
            {
                _scriptures[_currentScripture].VerifyHiddenWords(_userInput);
            }
            else if (_userInput.Equals("") && !stillHidding)
            {
                
            }
        } 
        
    }

    private static string DisplayScripture()
    {
        return $"{_scriptures[_currentScripture].GetReference()} - {_scriptures[_currentScripture].GetWords()}";
    }

    private static int RandomScriptureIndex()
    {
        Random random = new Random();

        int index = random.Next(0, 41995);
        
        return index;
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