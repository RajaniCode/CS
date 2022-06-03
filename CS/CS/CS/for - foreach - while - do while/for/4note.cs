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

        for(int i=0; i < s.Length; i++)  // for(int i=0; s[i] != 126; i++) 
                if(s[i] == ' ')
                    wordcount++;
                else
                    charactercount++;
        Console.WriteLine("Number of words (including extra spaces if any) = " + wordcount);
        Console.WriteLine("Characters = " + charactercount); 
    }
}   