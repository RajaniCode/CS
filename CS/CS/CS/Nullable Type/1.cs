//C# 2.0 Nullable<T> // Only vlaue types // can be static // can be readonly // cannot be volatile // cannot be const 


using System;

class MainClass
{
    char? c = null;
    static decimal? m = null;
     
    static void Main()
    {
        MainClass mac = new MainClass();

        System.Nullable<int> i = null; // LOCAL
        bool? b = null;                // LOCAL
    
        if(i != null)
            Console.WriteLine("i has value: " + i.Value);
        else
            Console.WriteLine("i doesn't have value");

        if(b != null)
            Console.WriteLine("b has value: " + b.Value);
        else
            Console.WriteLine("b doesn't have value");

        if(mac.c != null)
            Console.WriteLine("c has value: " + mac.c.Value);
        else
            Console.WriteLine("c doesn't have value");

        
        if(m != null)
            Console.WriteLine("m has value: " + m.Value);
        else
            Console.WriteLine("m doesn't have value");


        i = 100;
        b = true;
        mac.c = 'C';
        m = 1M;
        
        if(i.HasValue)
            Console.WriteLine("i has value: " + i.Value);
        else
            Console.WriteLine("i doesn't have value");
     
        if(b.HasValue)
            Console.WriteLine("b has value: " + b.Value);
        else
            Console.WriteLine("b doesn't have value");

        if(mac.c.HasValue)
            Console.WriteLine("c has value: " + mac.c.Value);
        else
            Console.WriteLine("c doesn't have value");

        if(m.HasValue)
            Console.WriteLine("m has value: " + m.Value);
        else
            Console.WriteLine("m doesn't have value");   
    }
}