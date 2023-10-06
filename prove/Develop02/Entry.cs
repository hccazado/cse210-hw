public class Entry
{
    public DateTime _date;
    
    public int _prompt;

    public string _response;

    public Prompt _promptList = new Prompt ();

    public void DisplayEntry(){
        Console.WriteLine($"Date: {_date}\nQuestion: {_promptList._prompts[_prompt]}\nAnswer: {_response}\n");
    }
}