using System;

class Program
{
    private static string _userChoice;

    private static int _time;

    static void Main(string[] args)
    {
        DisplayMenu();
    }

    private static void DisplayMenu()
    {
        string response;

        while (_userChoice != "quit")
        {
            Console.Clear();
            Console.WriteLine("\tMindfulness Assignment");
            Console.WriteLine("1    - Breathing Activity");
            Console.WriteLine("2    - Listing Activity");
            Console.WriteLine("3    - Reflecting Activity");
            Console.WriteLine("quit - quit app\n");
            Console.Write("Choice: ");
            
            _userChoice = Console.ReadLine();

            switch (_userChoice)
            {
                case "1":
                    Console.WriteLine("How Long do you want play breathing activity (seconds)?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    BreathingActivity breath = new BreathingActivity(_time);

                    breath.MindfulBreathing();

                break;
                case "2":
                    Console.WriteLine("How Long do you want play listing activity (seconds)?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    ListingActivity list = new ListingActivity(_time);

                    list.MindfulListing();
                break;
                case "3":   

                    Console.WriteLine("How Long do you want play reflecting activity (seconds)?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    ReflectingActivity reflection = new ReflectingActivity(_time);

                    reflection.MindfulReflecting();
                break;
                case "quit":
                    System.Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("Invalid option!\nPress any key to continue.");
                    
                    Console.ReadLine();
                break;
            }
        }
    }
}