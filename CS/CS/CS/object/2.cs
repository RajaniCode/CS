// object class // boxing & unboxing 

using System;

class MainClass
{
    static void Main()
    {
        int x;

        x = 10;

        object ob; // built-in class

        ob = x; // boxing // Note: int(value type) is derived from object(reference type)
     
        int y = (int)ob; // unboxing using explicit cast
        
        Console.WriteLine(y);
    }
}
    