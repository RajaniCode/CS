// string array reverse


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        string[] array = new string[n];
        
        Console.WriteLine("Enter string"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = Console.ReadLine();
        }

        Array.Reverse(array);
    
        Console.WriteLine("Array reverse is:");
        for(int i=0; i<n; i++)
            Console.WriteLine(array[i]);          
    }  
} 