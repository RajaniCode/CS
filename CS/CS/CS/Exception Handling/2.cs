// Exception Handling


using System;

class MyClass
{
    public static void myMethod()
    {   
        int[] number = new int[5]; 
        Console.WriteLine("Before generating exception \n");

        // Generationg index out-of-bounds exception
        for(int i=0; i<10; i++)
        {
            number[i] = i;
            Console.WriteLine("number[{0}] = {1} \n", i, number[i]);
        }
        Console.WriteLine("This won't be displayed in case of exception");
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
        
        catch(IndexOutOfRangeException)
        {
            // Catch the Exception
            Console.WriteLine("Index out-of-bounds! \n");
        }
    
        Console.WriteLine("After catch statement");
    }
}     
            



          
    
 