// string array with each string reversed


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter the number of strings:"); 
        int n = int.Parse(Console.ReadLine());
        
        string[] s = new string[n];       
            
        Console.WriteLine("Enter the string(s):");  
        for(int i=0; i<n; i++)
            s[i] = Console.ReadLine();
     
        Console.WriteLine("The string array with each string reversed:");              
        for(int i=0; i<n; i++) 
        {
            char[] array = new char[s[i].Length];
            
            for(int j=0;j<s[i].Length;j++)
                array[j] = s[i][j];
    
            for(int k=array.Length-1; k>=0 ;k--)
                Console.Write(array[k]); 

            Console.WriteLine();
        }
    }  
}