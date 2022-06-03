// if else


using System;

class MainClass
{
    static void Main()
    {
        string s;

        int i;

        Console.Write("Enter any integer: ");
        s = Console.ReadLine();
        i = int.Parse(s); //  i = System.Int32.Parse(s); // i = Int32.Parse(s);
        
        if(i > 0)
            Console.WriteLine("The entered integer {0} is greater than 0", i);

        if(i < 0)
            Console.WriteLine("The entered integer {0} is lesser than 0", i);
              
        if(i != 0) //But not: if(s <> 0)
            Console.WriteLine("The entered integer {0} is not equal to 0", i);
        else
            Console.WriteLine("The entered integer {0} is equal to 0", i);
      
        if(i < 0 || i == 0)  
            Console.WriteLine("The entered integer {0} is less than or equal to zero", i); 
        else if(i > 0 && i <= 10)  
            Console.WriteLine("The entered integer {0} is between zero and 11", i);
        else if(i > 10 && i <= 20)  
            Console.WriteLine("The entered integer {0} is between 10 and 21", i);
        else if(i > 20 && i <= 30)  
            Console.WriteLine("The entered integer {0} is between 20 and 31", i);
        else
            Console.WriteLine("The entered integer {0} is greater than 30", i);
    }
}