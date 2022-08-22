// dll

using System;

public class PrintClass
{   
    public static void printMethod()
    {
        Console.WriteLine("This is the print method!");
    }
}


//>>csc /t:library 1a.cs

//>>csc 1.cs /r:1a.dll