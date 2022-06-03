// ASCII // char


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine((int)'A');
         
        Console.WriteLine('A' + 0); 
        
        Console.WriteLine((char)45);

        Console.WriteLine((char)46);


        for(int i=0; i<26; i++)
        {
            Console.Write((char)('A' + i) + " ");            
        }
        Console.WriteLine("\n");
 
        for(int i=0; i<26; i++)
        {
            Console.Write((char)('a' + i) + " ");            
        }
        Console.WriteLine("\n");

        for(int i=0; i<26; i++)
        {
            Console.Write('A' + i + " ");            
        }
        Console.WriteLine("\n");

        for(int i=0; i<26; i++)
        {
            Console.Write('a' + i + " ");            
        }
        Console.WriteLine("\n");     
    }
}






