// Console.ReadLine() // Console.Read() 


using System;

class MainClass
{
    static void Main()
    {
        Console.Write("Enter name: ");
        Console.WriteLine("Hello, how are you {0}?", Console.ReadLine());

        Console.Write("Enter city: ");
        string city = Console.ReadLine();
        Console.WriteLine("Welcome to {0}! ", city);

        Console.Write("Enter any unsigned long integer: ");
        ulong n = ulong.Parse(Console.ReadLine()); //Also: System.Convert.ToUInt64
        Console.WriteLine("The unsigned long integer + 9000000000000000000 is " + (n + 9000000000000000000));
	
        Console.Write("Enter date: ");
        DateTime d = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("The date you entered is " + d);

        /* Note: If you use Console.Read() which reads a single character's ASCII value as integer, 
        you cannot further use Console.ReadLine() or Console.Read()) */
        
        Console.Write("Enter any character: ");
        Console.WriteLine("The character's ASCII value is {0}", Console.Read());
        /*
        Console.Write("Enter any character: ");
        int a = Console.Read();
        Console.WriteLine("The character's ASCII value is {0}", a);
        */ 
        
        Console.ReadLine();
    }
}