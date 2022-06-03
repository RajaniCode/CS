// Collections

// ArrayList


using System;
using System.Collections;

class MainClass
{
    static void Main()
    {
        ArrayList al = new ArrayList();

        Console.WriteLine("Current capacity of ArrayList: {0}", al.Capacity);

        Console.WriteLine("Initial number of elements in ArrayList: {0}", al.Count);

        Console.WriteLine();

        al.Add('E');
        al.Add('A');
        al.Add('B');
        al.Add('D');
        al.Add('C');
        al.Add('F');

        Console.WriteLine("Current capacity of ArrayList: {0}", al.Capacity);

        for(int i=0; i<al.Count; i++)
            Console.Write(al[i] + " ");
         
        Console.WriteLine("\n");

        al.Remove('C');
        al.Remove('A');

        foreach(char c in al)
            Console.Write(c + " ");

        Console.WriteLine("\n");          
   
        for(int i=0; i<20; i++)
            al.Add((char)('a' + i));

        Console.WriteLine("Current capacity of ArrayList: {0}", al.Capacity);
 
        Console.WriteLine("Number of elements in ArrayList after adding 20: {0}", al.Count);      
 
        foreach(char c in al)
            Console.Write(c + " ");
         
        Console.WriteLine("\n");

        Console.WriteLine("Change first yhree elements");
        al[0] = 'X';
        al[1] = 'Y';
        al[2] = 'Z';

        foreach(char c in al)
            Console.Write(c + " ");
         
        Console.WriteLine("\n"); 
    }
}