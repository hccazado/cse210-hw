using System;

class Program
{
    static string _userChoice;

    static int _time;

    static void Main(string[] args)
    {
        Console.Clear();
        DisplayMenu();
    }

    private static void DisplayMenu()
    {
        string response;

        while (_userChoice != "quit" || _userChoice == "q")
        {
            Console.WriteLine("\tMindfulness Assignment");
            Console.WriteLine("1    - Breathing Activity");
            Console.WriteLine("2    - Listing Activity");
            Console.WriteLine("3    - Reflection Activity");
            Console.WriteLine("quit - quit app\n");
            Console.Write("Choice: ");
            
            _userChoice = Console.ReadLine();

            switch (_userChoice)
            {
                case "1":
                    Console.WriteLine("How Long do you want play breathing activity?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    BreathingActivity breath = new BreathingActivity(_time);

                    breath.MindfulBreathing();

                break;
                case "2":
                    Console.WriteLine("How Long do you want play listing activity?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    ListingActivity list = new ListingActivity(10);

                    list.MindfulListing();
                break;
                case "3":
                    ReflectionActivity reflection = new ReflectionActivity(10);

                    Console.WriteLine("How Long do you want play reflection activity?");

                    response = Console.ReadLine();

                    _time = int.Parse(response);

                    reflection.MindfulReflection();
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