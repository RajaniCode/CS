// Split()


using System;

class MainClass
{
    static void Main()
    {
        string temp = ""; //Note "" means empty
        string a = "This  is   a    string";
        char[] separator = {' '}; // Note ' ' single space and it is not '' 
      
        string[] parts = a.Split(separator);
         
        for(int i=0; i<parts.Length; i++)
        {
            // Console.WriteLine(parts[i]); // See parts[i] is only one space less
            if(parts[i] != "") //Note "" means empty 
            {   
                temp += parts[i];
                temp += " ";
               
            }
        }
        Console.WriteLine("The string with multiple spaces trimmed to a single space is: {0}", temp);
    }
}


