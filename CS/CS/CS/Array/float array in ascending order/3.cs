// float array in ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        float[] array = new float[n];
        
        Console.WriteLine("Enter float type number(s)"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = float.Parse(Console.ReadLine());
        }
        
        Array.Sort(array);

        Console.WriteLine("Array in ascending order is:");
        for(int i=0; i<n; i++)            // for(int i=n-1; i>=0; i--) // descending order
            Console.WriteLine(array[i]);
    }  
}