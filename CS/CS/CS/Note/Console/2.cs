// Console.WriteLine


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("string");

        Console.WriteLine('A');

        Console.WriteLine('A'+ 0);  
 
        Console.WriteLine((char)65);
         
        Console.WriteLine((int)'A');
    
        Console.WriteLine((char)('A'+0)); // Note: ('A'+0)

        Console.WriteLine(5);
  
        Console.WriteLine(-5);
    
        Console.WriteLine(5U); 
           
        Console.WriteLine(-5L); 
    
         Console.WriteLine(5UL);

        Console.WriteLine(-5.0F);
      
        Console.WriteLine(-5.0D);

        Console.WriteLine(-5.0M);

        Console.WriteLine(true);
     
        Console.WriteLine(DateTime.Now.ToLongDateString()); 

        Console.WriteLine(0xF);

        Console.WriteLine(0x555); 

        Console.WriteLine(Convert.ToString(1365, 16));      
    }
}
   
        
          