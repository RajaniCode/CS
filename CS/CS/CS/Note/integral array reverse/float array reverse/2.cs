// float array reverse


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

        Array.Reverse(array);

        Console.WriteLine("Array reverse is:");
        for(int i=0; i<n; i++)
            Console.WriteLine(array[i]);
    }  
}