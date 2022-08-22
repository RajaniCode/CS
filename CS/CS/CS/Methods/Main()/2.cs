// returning values from Main()

using System;

class MainClass
{
    static int Main(string[] args)
    {
        if(args.Length < 2)
        {
            Console.WriteLine("Enter encode/decode word1 [word2 . . . wordn]");
            return 1; // Note: return failure code
        }

        if((args[0] != "encode") && (args[0] != "decode"))
        {
            Console.WriteLine("First argument must be encode or decode");
            return 1; // Note: return failure code
        }
        else
        {
            for(int n=1; n<args.Length; n++) // Note: n=1
            {
                for(int i=0;i<args[n].Length; i++) // Note: args[n].Length
                {  
                    if((args[0] == "encode"))
                        Console.Write((char)(args[n][i] + 1)); // Note: args[n][i]
                    else
                        Console.Write((char)(args[n][i] - 1)); // Note: args[n][i]
                }
                Console.Write(" ");
            }
            Console.WriteLine(); 
            return 0;
        }
    }
}
               
            
