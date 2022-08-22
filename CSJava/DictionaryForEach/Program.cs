using static System.Console;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private void Writer(KeyValuePair<string, int> kvp) 
    {
        WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
    }

    private void Method()
    {
        Dictionary<string, int> names = new Dictionary<string, int>();
        names.Add("Alpha", 1);
        names.Add("Beta", 2);
        names.Add("Gamma", 3);
        names.Add("Delta", 4);
        names.Add("Epsilon", 5);

        // System.Collections.Generic.Dictionary`2[System.String,System.Int32]
        // WriteLine(names);

        // Display the contents of the Dictionary using the Writer method.
        names.ToList().ForEach(Writer);
        
        WriteLine("--lambda--");

        /*
        // The following demonstrates the anonymous method feature of C#
        // to display the contents of the Dictionary to the console.
        names.ToList().ForEach(delegate(KeyValuePair<string, int> kvp)
        {
            WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }); 
        */

	// names.ToList().ForEach(kvp => WriteLine(kvp));
        names.ToList().ForEach(kvp => WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value));
    }

    static void Main()
    {
	Program prgm = new Program();
	prgm.Method();
    }
}

/* 
// This code will produce output similar to the following:
Key: Alpha, Value: 1
Key: Beta, Value: 2
Key: Gamma, Value: 3
Key: Delta, Value: 4
Key: Epsilon, Value: 5
--lambda--
Key: Alpha, Value: 1
Key: Beta, Value: 2
Key: Gamma, Value: 3
Key: Delta, Value: 4
Key: Epsilon, Value: 5
*/