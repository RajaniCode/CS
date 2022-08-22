// object class // boxing also occurs when passing values // instance method

using System;

class MyClass
{
    static void Main()
    {
        int x;
        x = 10;
        
        Console.WriteLine("Here is the value of x: " + x);
      
        MyClass mc = new MyClass();
        x = mc.squareMethod(x); // Note
        Console.WriteLine("Here is the value of x when squared: " + x);        
    }

    int squareMethod(object ob) // Note
    {
        return (int)ob * (int)ob; // Note
    }
}

