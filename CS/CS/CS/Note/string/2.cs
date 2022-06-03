// string summary


using System;

class MainClass
{
    static void Main()
    {
        int wordcount = 0;
        int charactercount = 0;
                
                 
        Console.WriteLine("Enter the string");
        string a = Console.ReadLine();
        char[] separator = {' '}; // Note ' ' single space and it is not '' 
        
        string[] parts = a.Split(separator);
        
        for(int i=0; i<parts.Length; i++)
           if(parts[i] != "") //Note "" means empty
               wordcount++;
                  
        //charactercount = a.Length;
        for(int i=0; i<a.Length; i++) 
            if(a[i] != ' ')
                charactercount++;

       
        Console.WriteLine("Number of words = {0} \n", wordcount);
        Console.WriteLine("Number of characters = {0} \n", charactercount); 
      
        int vowels;
        int consonants;
 
        int uc = 0; 
        int lc = 0;
        
        int uv = 0;
        int lv = 0;
        
        int space = 0;
        
        int digit = 0;
        
        int special =0; 
        
        
        for(int i=0; i<a.Length; i++) 
            if(a[i] == 'A' || a[i] == 'E' || a[i] == 'I' || a[i] == 'O' ||a[i] == 'U') 
                uv++;
            else if(a[i] == 'a' || a[i] == 'e' || a[i] == 'i' || a[i] == 'o' || a[i] == 'u') 
                lv++;
            else if(a[i] >= 65 && a[i] <= 90)
                uc++;
            else if(a[i] >= 97 && a[i] <= 122)
                lc++;
            else if(a[i] == 32)
                space++;  
            else if(a[i] >= 48 && a[i] <= 57)
                digit++;
            else if(a[i] >= 0 && a[i] <= 31)
                special++;
            else if(a[i] >= 33 && a[i] <= 47)
                special++;
            else if(a[i] >= 58 && a[i] <= 64)
                special++;
            else if(a[i] >= 91 && a[i] <= 96)
                special++;
            else if(a[i] >= 123 && a[i] < 127 )
                special++;
         
        Console.WriteLine("Number of upper case vowels = {0} \n", uv);
        Console.WriteLine("Number of lower case vowels = {0} \n", lv); 
                 
        Console.WriteLine("Number of upper case consonants = {0} \n", uc);
        Console.WriteLine("Number of lower case consonants = {0} \n", lc);
         
        vowels = uv + lv;
        consonants = uc + lc; 
        Console.WriteLine("Number of vowels = {0} \n", vowels);
        Console.WriteLine("Number of consonants = {0} \n", consonants);
         
        Console.WriteLine("Number of spaces = {0} \n", space);
                  
        Console.WriteLine("Number of digits = {0} \n", digit);
             
        Console.WriteLine("Number of special characters = {0} \n", special);
         
    }
}    
     
