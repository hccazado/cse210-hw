public class Prompt
{
    public List<string> _prompts = new List<string>(){
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How have I helped someone in need today?",
        "What was my favorite scripture today?",
        "What is a new plan that I have for this weekend?",
        "Is there anyone that I need to forgive?",
        "How can I become a better follower of Christ?"
    };

    public int GetRandomPrompt (List<int> usedPrompts){
    //returns a random index of a not yet answered prompt during the current day
    //Parameter: A index list of current's day ansewered prompts

        Random random = new Random();

        int randomIndex = random.Next(_prompts.Count);
        
        if (usedPrompts.Count == _prompts.Count)
        {
            return -99;
        }
        else
        {
            if(usedPrompts.Contains(randomIndex))
            {
                while(usedPrompts.Contains(randomIndex))
                {
                    randomIndex = random.Next(_prompts.Count);
                }

                return randomIndex;
                
            }
            else {
                return randomIndex;
            }
        }
    }
}