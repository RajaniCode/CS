// for


using System;

class MainClass
{
    static void Main()
    {
        int wordcount = 1;
        int charactercount = 0;
        
        Console.WriteLine("Enter string:");
        string s =  Console.ReadLine();
         
        try
        {
            for(int i=0; s[i] != '\0'; i++)  // for(int i=0; s[i] != '\n'; i++)
                if(s[i] == ' ')
                    wordcount++;
                else
                    charactercount++;
        }
        catch(Exception)
        {
            
        } 
        Console.WriteLine("Number of words (including extra spaces if any) = " + wordcount);
        Console.WriteLine("Characters = " + charactercount);               
    }
}   