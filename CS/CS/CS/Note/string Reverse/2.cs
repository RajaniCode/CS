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

        Console.WriteLine("The string reverse is:");
        for(int j=array.Length-1; j>=0; j--)             
            Console.Write(array[j]);
    }  
}