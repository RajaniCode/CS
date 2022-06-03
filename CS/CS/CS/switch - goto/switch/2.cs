// switch // Works only with integral types (also char type), string type, boolean type, and enums


using System;

class MainClass 
{
    static void Main()
    {
        string s1;
        ulong u1;

        Console.WriteLine("Enter 1 or 2 or 3");
        s1 = Console.ReadLine();
        u1 = ulong.Parse(s1); // u1 = System.UInt64.Parse(s1); // u1 = UInt64.Parse(s1); 

        switch(u1)
        {
            case 1:
                Console.WriteLine("Printing 1");
                break;
            case 2:
                Console.WriteLine("Printing 2");
                break;
            case 3:
                Console.WriteLine("Printing 3");
                break;
            default:
                Console.WriteLine("You did not enter properly");
                break;
        }

        string s2;
        char c;
        Console.WriteLine("Enter A or a");
        s2 = Console.ReadLine();
        c = Char.Parse(s2); // c = System.Char.Parse(s2); //  c = Char.Parse(s2);
        
        switch(c)
        {
            case 'A':
                Console.WriteLine("Printing A");
                break;
             case 'a':
                Console.WriteLine("Printing a");
                break;
             default:
                Console.WriteLine("You did not enter properly");
                break;
        }

        Console.WriteLine("Enter Green or Red: ");
        string stringput = Console.ReadLine();
        
        switch(stringput)
        {
            case "Green":
                Console.WriteLine("Printing Green");
                break;
            case "Red":
                Console.WriteLine("Printing Red");
                break;
            default:
                Console.WriteLine("You did not enter properly");
                break;
        }          

        Console.WriteLine("Enter true or false:");
        bool boolean = bool.Parse(Console.ReadLine());
        //bool boolean = System.Boolean.Parse(Console.ReadLine()); // bool boolean = Boolean.Parse(Console.ReadLine());
                  
        switch(boolean)
        {
            case true:
                Console.WriteLine("Printing true");
                 break;
            case false:
                Console.WriteLine("Printing false");
                 break;
            default:
                Console.WriteLine("You did not enter properly");
                break;
        }
    
    }
}