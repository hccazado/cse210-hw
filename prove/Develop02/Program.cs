using System.Runtime.CompilerServices;
using System;

class Program
{ 
    private static Journal _journal = new Journal();
    
    private static Scripture _scriptures = new Scripture();
    
    private static int _choice = -1;
    
    static void Main(string[] args)
    {
        
        while( _choice != 5){

            Console.Clear();
            
            Console.WriteLine("Welcome to the Journal Program!\n");

            _scriptures.DisplayRandomScripture();

            Console.WriteLine("\n|-----------Journal Main Menu---------------|");
            Console.WriteLine("|1 - Add a New Entry                        |");
            Console.WriteLine("|2 - Display Entries                        |");
            Console.WriteLine("|3 - Save Journal                           |");
            Console.WriteLine("|4 - Load Journal                           |");
            Console.WriteLine("|5 - Quit Journal Program                   |");
            Console.WriteLine("|-------------------------------------------|\n");
            Console.Write("Type your choice: ");
            
            _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:

                    _journal.NewEntry();

                break;

                case 2:

                    _journal.ShowJournalEntries();

                break;

                case 3:

                    string fileName;

                    Console.WriteLine("Please type a name for your journal (without file's extension): ");
        
                    fileName = Console.ReadLine();

                    fileName += ".csv";

                    _journal.SaveCsvJournal(fileName);

                break;

                case 4:
                    
                    Console.WriteLine("Type the name of your journal (without file's extension):");

                    fileName = Console.ReadLine();

                    fileName += ".csv";

                    _journal.LoadCsvJournal(fileName);

                break;

                case 5:

                    Console.WriteLine("Bye!");

                    System.Environment.Exit(1);

                break;
                
                default:
                    Console.WriteLine("Invalid _choice! Press enter to continue");

                    Console.ReadLine();

                break;
            }
        }
    }
}