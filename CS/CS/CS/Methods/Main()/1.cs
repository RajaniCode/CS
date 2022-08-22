// passing arguments to Main()

using System;

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("There are {0} command-line arguments", args.Length);

        Console.WriteLine("They are: ");
        for(int i=0; i<args.Length; i++)
            Console.WriteLine(args[i]);
    }
}
     
    
  