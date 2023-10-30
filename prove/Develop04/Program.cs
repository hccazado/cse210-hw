using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breath = new BreathingActivity(10);
        //breath.MindfulBreathing();
        ListingActivity list = new ListingActivity(10);
        //list.MindfulListing();
        ReflectionActivity reflect = new ReflectionActivity(10);
        reflect.MindfulReflection();
    }
}