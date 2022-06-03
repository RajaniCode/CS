// Split()


using System;

class MyClass
{
    static string methodReplace(string sp)
    {       
        string temp = "";         

        char[] separator = {'\''}; 
      
        string[] parts = sp.Split(separator);
        Console.WriteLine("Pieces from split:");
        for(int i=0; i<parts.Length; i++)
        {          
            temp += parts[i];
            if(i!=parts.Length-1) 
                temp += "''";   
        }
        return temp;         
    }

    static void Main()
    { 
        Console.WriteLine("Enter string");
        string s = Console.ReadLine();
        Console.Write("The string replaced is: {0}", methodReplace(s));
    }
}