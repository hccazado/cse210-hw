using System;
using System.Runtime.CompilerServices;

class Program
{
    private static string _userInput;

    private static Reference _reference;

    private static bool _stillPlaying;

    static void Main(string[] args)
    {
    
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
                    _reference = new Reference(AppData.RandomReference());
                    Memorize(_reference);
                break;

                case "2":
                    Console.Write("Book (genesis): ");
                    string book = Console.ReadLine();

                    Console.Write("\nChapter: ");
                    string chapter = Console.ReadLine();

                    Console.Write("\nVerses: (1 or 1-7): ");
                    string verses = Console.ReadLine();

                    _reference = new Reference(AppData.SpecificReference(book, chapter, verses));

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
}