using static System.Console;
using System;

class Program
{
    private void Method()
    {
        string[] names = { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
        Array.ForEach(names, element => WriteLine("Element:{0}", element));
    }
    
    static void Main()
    {
	Program prgm = new Program();
	prgm.Method();
    }
}

/* 
// This code will produce output similar to the following:
Element:Alpha
Element:Beta
Element:Gamma
Element:Delta
Element:Epsilon
 */