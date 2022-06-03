// lowercase


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
                t[i] = (char)(s[i] + 32);
            else if(s[i] >= 97 && s[i] <= 123) 
                t[i]= (char)(s[i]);
        }
    
        Console.WriteLine("Converted case of the string is:");
        for(int i=0; i<s.Length; i++)
            Console.Write(t[i]);
    }
}
