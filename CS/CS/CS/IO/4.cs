// I/O // Console.ReadKey() // ConsoleKeyInfo // ConsoleModifiers

using System;

class MyClass
{
    static void Main()
    {
        ConsoleKeyInfo k;
        Console.WriteLine("Pess any Key or Press 'Q' to quit");

        do
        {
            k = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("The Key pressed is {0}", k.KeyChar);
            
            if((ConsoleModifiers.Alt & k.Modifiers) != 0)
                Console.WriteLine("Alt Key pressed");

            if((ConsoleModifiers.Control & k.Modifiers) != 0 )
                Console.WriteLine("Control Key pressed"); 
   
            if((ConsoleModifiers.Shift & k.Modifiers) != 0)
                Console.WriteLine("Shift Key pressed");
        }while(k.KeyChar != 'Q');
    }  
}
  
     
