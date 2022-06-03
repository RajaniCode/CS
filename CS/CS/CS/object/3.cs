// object class // boxing also occurs when passing values // static method

using System;

class MyClass
{
    static void Main()
    {
        int x;
        x = 10;
        
        Console.WriteLine("Here is the value of x: " + x);
      
        MyClass mc = new MyClass();
        x = MyClass.squareMethod(x); // Note
        Console.WriteLine("Here is the value of x when squared: " + x);        
    }

    static int squareMethod(object ob) // Note
    {
        return (int)ob * (int)ob; // Note
    }
}

