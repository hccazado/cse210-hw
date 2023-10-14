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

        Console.WriteLine("\tScripture Memorizer - A BYU-I Project");

        _userInput = "";

        _currentScripture = RandomScriptureIndex();

        while (_userInput != "quit")
        {
            Console.WriteLine($"{DisplayReference()} - {DisplayScripture()} ");
            
            _userInput = Console.ReadLine();

            if (_userInput.Equals(""))
            {
                _scriptures[_currentScripture].HideRandomWords();
            }
        
        }
        
        //Console.WriteLine($"Total of Scriptures: {_scriptures.Count()}");
        
    }

    private static string DisplayReference()
    {
        return _scriptures[_currentScripture].GetReference();
    }

    private static string DisplayScripture()
    {
        return _scriptures[_currentScripture].GetWords();
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