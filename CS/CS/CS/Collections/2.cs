// Collections

// ArrayList


using System;
using System.Collections;

class MainClass
{
    static void Main()
    {
        ArrayList al = new ArrayList();

        Console.WriteLine("Initial capacity of ArrayList: {0}", al.Capacity);

        Console.WriteLine("Initial number of elements in ArrayList: {0}", al.Count);

        Console.WriteLine();



        Console.WriteLine("Enter the number of strings:"); 
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the strings:"); 
        for(int i=0; i<n; i++)
            al.Add(Console.ReadLine());        

        /*
        al.Add("Bill");
        al.Add("Gates");
        al.Add("James");
        al.Add("Goosling");
        al.Add("Bjarne");
        al.Add("Stroustrup");
        */
       
        for(int i=0; i<al.Count; i++)
            Console.Write(al[i] + " ");       
         
        Console.WriteLine("\n");
        
        Console.WriteLine("Current capacity of ArrayList: {0}", al.Capacity);
        Console.WriteLine("Current number of elements in ArrayList: {0}", al.Count);
        


        al.Sort();

        for(int i=0; i<al.Count; i++)
            Console.Write(al[i] + " ");       
         
        Console.WriteLine("\n");

        Console.WriteLine("Capacity of ArrayList after sorting: {0}", al.Capacity);

        Console.WriteLine("Number of elements in ArrayList after sorting: {0}", al.Count);
 
        Console.WriteLine(al.BinarySearch("Rajani"));

    }
}