// Exception Handling


using System;

class MainClass
{   
    static void Main()
    {         
        int[] number = new int[5]; 

        try
        {
            Console.WriteLine("Before exception is generated \n");
            
            // Generate an index out-of-bounds exception;
            
            for(int i=0; i<10; i++)
            {    
                number[i] = i;
                Console.WriteLine("number[{0}] = {1} \n", i, number[i]);
            }
            
            Console.WriteLine("This won't be displayed in case of exception");
        }
        
        catch(IndexOutOfRangeException) // Note
        {
            // catch the exception
            Console.WriteLine("Index out-of-bounds! \n");
        }
        
        Console.WriteLine("After catch statement");
    }
}        
   
             
          

   
        
        
        

   
       
        
    

