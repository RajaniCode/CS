// Exception Handling // Exception members


using System;

class MyClass
{
    public static void myMethod()
    {
        int[] number = new int[5];
        
        Console.WriteLine("Before Exception is generated \n");
        
        // Generating Index out-of-bounds Exception 
        for(int i=0; i<10; i++)
        {
            number[i] = i;
            Console.WriteLine("number[{0}] = {1}", i, number[i]);
        }
        
        Console.WriteLine("This won't be displayed");
    }
}

class MainClass
{
    static void Main()
    {
        try
        {
            MyClass.myMethod();
        }
        
        // catch Exception
        catch(IndexOutOfRangeException e) // Note
        {
            Console.WriteLine("Standard message: ");
            Console.WriteLine(e); // calls ToString()
            Console.WriteLine("StackTrace: " + e.StackTrace);
            Console.WriteLine("Message: " + e.Message);
            Console.WriteLine("TargetSite: " + e.TargetSite);
            Console.WriteLine();
        }

        Console.WriteLine("After catch statement");
    }
}  
          
        
