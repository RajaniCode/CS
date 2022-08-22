// Split()


using System;

class MainClass
{
    static void Main()
    {       
        string temp = ""; //Note "" means empty
        
        Console.WriteLine("Enter the string with multiple spaces");
        string a = Console.ReadLine();
       
        char[] separator = {' '}; // Note ' ' single space and it is not '' 
        
        string[] parts = a.Split(separator);
        Console.WriteLine("Pieces from split:");
        for(int i=0; i<parts.Length; i++)
        {
            if(parts[i] != "") //Note "" means empty
            {   
                temp += parts[i];
                temp += " ";               
            }
        }
        Console.Write("The string with multiple spaces trimmed to a single space is: {0}", temp);
    }
}