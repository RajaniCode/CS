// string palindrome


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter the string of alphabets:");
        string s = Console.ReadLine();

        char[] array = new char[s.Length];

        for(int i=0; i<s.Length; i++) 
            array[i] = s[i];  

        char[] t = new char[s.Length];

        for(int i=0; i<s.Length; i++) 
        {
            if(s[i] >= 65 && s[i] <= 91)
                t[i] = (char)(s[i]);
            else if(s[i] >= 97 && s[i] <= 123) 
                t[i]= (char)(s[i] - 32);
            else
                t[i]= s[i];
        }
    
        string str1 = string.Empty;
        for(int i=0; i<s.Length; i++)
            str1 += t[i];

        Array.Reverse(t);

        string str2 = string.Empty;
        for(int i=0; i<s.Length; i++)
            str2 += t[i];
    
        
        
       if(str1==str2)
           Console.WriteLine("The string of alphabets is a palindrome");
       else
           Console.WriteLine("The string of alphabets is not a palindrome");    
        
    }
}
