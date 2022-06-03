// Split()


using System;

class MainClass
{
    static void Main()
    {       
        string a = "This is                                                         a      string";
        char[] separator = {' '}; // Note ' ' single space and it is not '' 
        
        string[] parts = a.Split(separator);
        Console.WriteLine("Pieces from split:");
        for(int i=0; i<parts.Length; i++)
            if(parts[i] != "") //Note "" means empty
                Console.Write(parts[i] + " ");     
    }      
}