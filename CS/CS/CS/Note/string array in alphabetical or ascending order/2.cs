// string array in alphabetical or ascending order


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

        Array.Sort(array);
    
        Console.WriteLine("Array in alphabetical or ascending order is:");
        for(int i=0; i<n; i++)           // for(int i=n-1; i>=0; i--) // reverse alphabetical or descending order
            Console.WriteLine(array[i]);          
    }  
} 