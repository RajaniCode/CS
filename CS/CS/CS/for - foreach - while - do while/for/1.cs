// for


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Printing first 5 odd numbers in ascending order");
        for(int i = 0; i < 20; i++)
        {
        if(i == 10)
            break;    // if condition satisfied, break the (for) loop  // Note: return; means if condition is satisfied, end the program
        if(i % 2 == 0)
	    continue; // if condition is satisfied, continue to i++
        Console.WriteLine(i) ;
        }
        
        Console.WriteLine("Printing next 5 odd numbers in descending order");
        for(int i = 20; i > 0; i--)
        {
            if(i == 10)
                break;
            if(i % 2 ==0)
                continue;
            Console.WriteLine(i);
        }         
    }     
   
}

