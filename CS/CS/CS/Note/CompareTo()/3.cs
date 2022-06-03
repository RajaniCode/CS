// built-in String.CompareTo(String) // using string parameters

// #Note


using System;

class MainClass
{
    static bool isIn(string sp, string[] sarrayp)  //#Note
    {
        foreach(string s in sarrayp)
            if(s.CompareTo(sp) == 0)               // #Note: calling built-in String.CompareTo(String)
                return true;

        return false;
    }

    static void Main()
    {
        string[] sarray = {"Bill", "Gates", "James", "Goosling", "Straustrup"};

        if(isIn("Bill", sarray))
            Console.WriteLine("\nBill is in sarray\n");
        else
            Console.WriteLine("\nBill is not in sarray\n");

        if(isIn("Bjarne", sarray))
            Console.WriteLine("\nBjarne is in sarray\n");
        else
            Console.WriteLine("\nBjarne is not in sarray\n");        
    }
} 

        

    