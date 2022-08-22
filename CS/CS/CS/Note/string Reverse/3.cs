// string Reverse


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter string"); 
        string s = Console.ReadLine();
        
        char[] array = new char[s.Length];
        
        for(int i=0;i<s.Length;i++)
            array[i] = s[i];

        Array.Reverse(array);

        Console.WriteLine("The string reverse is:");
        for(int i=0;i<array.Length;i++)              
            Console.Write(array[i]);
    }  
}