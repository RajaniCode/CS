// float array in ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        float[] array = new float[n];
        float t;
        
        Console.WriteLine("Enter float type number(s)"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = float.Parse(Console.ReadLine());
        }

        for(int i=0; i<n; i++) 
        {
            for(int j=0 ;j < n-1; j++) 
            {
                if(array[i] < array[j])
                {
                    t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
        }

        Console.WriteLine("Array in ascending order is:");
        for(int i=0; i<n; i++)            // for(int i=n-1; i>=0; i--) // descending
            Console.WriteLine(array[i]);
    }  
}