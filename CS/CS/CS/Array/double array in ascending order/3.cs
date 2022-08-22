// double array in ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];
        
        Console.WriteLine("Enter double type number(s)"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = double.Parse(Console.ReadLine());
        }
        
        Array.Sort(array);

        Console.WriteLine("Array in ascending order is:");
        for(int i=0; i<n; i++)          // for(int i=n-1; i>=0; i--) // descending order
            Console.WriteLine(array[i]);
    }  
}