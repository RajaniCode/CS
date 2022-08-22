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
     
        Console.WriteLine("The string array with each string in alphabetical or ascending order:");              
        for(int i=0; i<n; i++) 
        {
            char[] array = new char[s[i].Length];
            
            for(int j=0;j<s[i].Length;j++)
                array[j] = s[i][j];
             
            Array.Reverse(array);
            
            for(int m=0;m<array.Length;m++)
                Console.Write(array[m]); 

            Console.WriteLine();
        }
    }  
}