// passing arguments to an anonymous method

using System;

delegate void MyDelegate(int a);

class MainClass
{
    static void Main()
    {
        MyDelegate md = delegate(int a)
        {
            for(int i=0; i<a; i++)
                Console.WriteLine(i);
        }; // Note
   
        md(5);
        Console.WriteLine();
        md(3);
    }
}
           

