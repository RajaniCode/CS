// foreach


using System;

class MainClass
{
    static void Main()
    {
        string[] array = {"Bill", "Gates", "Bjarne", "Strastrup"}; //Remember ;
        foreach(string name in array)
        Console.WriteLine(name);
    }
}