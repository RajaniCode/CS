// for // while // do while ;


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("for loop");
        
        for(int i=0; i<=10; i++) // ++i not a convention
        {
            Console.WriteLine(i);
        }
        
        Console.WriteLine();   


        Console.WriteLine("while loop: n++ Or ++n after print, otherwise 11"); 
        
        int n = 0;                      
        while(n<=10)
        {
             Console.WriteLine(n);
             n++;                                                                       
        };// NOT COMPULSORY
        
        Console.WriteLine(); 

        
        Console.WriteLine("do-while loop: m++ Or ++m after print, otherwise 11");
        
        int m = 0;                      
        do
        {
            Console.WriteLine(m);
            m++;                                                                      
        } while(m<=10);// COMPULSORY
                             
        Console.WriteLine();  


        Console.WriteLine("for loop - reverse");
        
        for(int j=10; j>=10; j--)
        {
            Console.WriteLine(j);
        }
        
        Console.WriteLine();   


        Console.WriteLine("while loop: nr-- Or --nr after print, otherwise -1"); 
        
        int nr = 10;                      
        while(nr>=0)
        {
             Console.WriteLine(nr);
             nr--;                                                                       
        };// Note
        
        Console.WriteLine(); 

        
        Console.WriteLine("do-while loop: mr-- Or --mr after print, otherwise -1");
        
        int mr = 10;                      
        do
        {
            Console.WriteLine(mr);
            mr--;                                                                      
        } while(mr>=0);// Note
                             
        Console.WriteLine();   
    } 
}