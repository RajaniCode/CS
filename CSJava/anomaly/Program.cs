// anomaly in CS/Java

using static System.Console;
using System.Collections.Generic;

class Method { }

class Program 
{
    void Method() 
    {
        WriteLine("class name and method name");
    }
        
    static void Main() 
    {
        List<Method> Method = new List<Method>();
        Program prgm = new Program();
        prgm.Method();            
    }
}