public class Entry
{
    public DateTime _date;
    
    public int _prompt;

    public string _response;

    public Prompt promptList = new Prompt ();


    public void DisplayEntry(){
        Console.WriteLine($"{_date} - {promptList._prompts[_prompt]}\n{_response}\n");
    }
}