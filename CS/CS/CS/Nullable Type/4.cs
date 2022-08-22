//C# 2.0 Nullable<T> // Only vlaue types // can be static // can be readonly // cannot be volatile // cannot be const 


using System;

class MainClass
{
    static void Main()
    {
        System.Nullable<bool> b = true; // LOCAL            
        Console.WriteLine("!b: " + !b.Value); // b = null = !b // System.InvalidOperationException

        byte? i1 = 1;
        byte? i2 = null;

        if(i1 > i2) 
            Console.WriteLine(true);
        else
              Console.WriteLine(false);   

        if(i1 < i2) // NOTE 
            Console.WriteLine(true);
        else
            Console.WriteLine(false);     
    }
}