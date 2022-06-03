// do while ; 


using System;

class MainClass
{     
    static void Main()
    {
       string input;
        do
        {
            Console.WriteLine("A or a to Add");
            Console.WriteLine("D or d to Delete");
            Console.WriteLine("M or m to Modify");
            Console.WriteLine("V or v to View");
            Console.WriteLine("Q or q to Quit");

           input = Console.ReadLine();

            switch(input)
            {
                case "A":
                case "a":
                    Console.WriteLine("Adding");
                    break;
                case "D":
                case "d":
                    Console.WriteLine("Deleting");
                    break;
                case "M":
                case "m":
                    Console.WriteLine("Modifying");
                    break;
                case "V":
                case "v":
                    Console.WriteLine("Viewing");
                    break;
                case "Q":
                case "q":
                    Console.WriteLine("Quitting");
                    break;
                default:
                    Console.WriteLine("You did not enter properly");
                    break;
            }
        }while(input != "Q" && input != "q");
    }
}    