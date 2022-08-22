using static System.Console;
using System.Collections.Generic;

class Program
{
   private void Writer(string s) 
   {
        WriteLine(s);
   }

   private void Method()
   {
        List<string> names = new List<string>();
        names.Add("Alpha");
        names.Add("Beta");
        names.Add("Gamma");
        names.Add("Delta");
        names.Add("Epsilon");

        // System.Collections.Generic.List`1[System.String]
        // WriteLine(names);

        // Display the contents of the list using the Writer method.
        names.ForEach(Writer);
        
        WriteLine("--lambda--");

        /*
        // The following demonstrates the anonymous method feature of C#
        // to display the contents of the list to the console.
        names.ForEach(delegate(string name)
        {
            WriteLine(name);
        });
        */
        // names.ForEach(name => WriteLine(name));
        names.ForEach(WriteLine);
   }

    static void Main()
    {
	Program prgm = new Program();
	prgm.Method();
    }
}

/* 
// This code will produce output similar to the following:
Alpha
Beta
Gamma
Delta
Epsilon
--lambda--
Alpha
Beta
Gamma
Delta
Epsilon
 */