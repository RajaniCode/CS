// string in alphabetical or ascending order

// NOTE: case


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter string"); 
        string s = Console.ReadLine();
        
        char[] array = new char[s.Length];
        
        for(int i=0; i<s.Length; i++)
            array[i] = s[i];

    
        char[] t = new char[s.Length];
               
        Array.Sort(array);

        Console.WriteLine("The string in alphabetical order is:");
        for(int i=0; i<array.Length; i++)            // for(int i=array.Length-1; i>=0; i--)   // reverse alphabetical or descending order
            Console.Write(array[i]);
    }  
}