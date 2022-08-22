// SpacesToNoSpace


using System;
 
class MainClass
{
    static void Main()
    {
        int space = 0;
       
        string StrValue = string.Empty;

        Console.WriteLine("Enter string:");
        string s = Console.ReadLine();

        for(int i=0; i<s.Length; i++)
        {
            if(s[i] != ' ')
            {
                space = 0;
                StrValue += s[i];
            } 
            else
            {
                if(s[i]==' ') 
                {
                    space = space + 1;
                }
            }
         } 
         Console.WriteLine(StrValue);                 
    }    
}
