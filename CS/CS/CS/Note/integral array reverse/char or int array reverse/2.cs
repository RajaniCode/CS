// int or char array reverse


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        char[] array = new char[n];
                
        Console.WriteLine("Enter characters or integers"); 
        for(int i=0; i<n; i++) 
        {            
            array[i] = char.Parse(Console.ReadLine());
        }

        Array.Reverse(array);

        Console.WriteLine("int or char array reverse:");
        for(int i=0; i<n; i++)         
            Console.WriteLine(array[i]);
    }  
}