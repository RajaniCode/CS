// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation


using System;

class MainClass
{
    enum Apple {Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh}; // Note: inside class // only alphabets and not in quotation

    static void Main()
    {
        string[] color = {"Green", "Yellow", "Red", "Reddish Green", "Reddish Yellow", "Greenish Yellow"};
        
        Apple a; // Note
        
        int i; // Note
        
        Console.WriteLine(a=0);
               
        Console.WriteLine(a=Apple.Jonathan);
        
        
        //for(a = 0, i = 0; i<= 6; i++) // for(a = Apple.Jonathan, i = 0; i<= 6; i++) 
        // for(a = Apple.Jonathan, i = (int)Apple.Jonathan; i<= (int)Apple.McIntosh; i++)
        for(a = 0, i = (int)Apple.Jonathan; i<= (int)Apple.McIntosh; i++)
            Console.WriteLine(a++ + " has value of " + i);
              
        
        Console.WriteLine();
               

        
        //for(a = 0, i = 0; i<= 6; i++) // for(a = Apple.Jonathan, i = 0; i<= 6; i++) 
        // for(a = Apple.Jonathan, i = (int)Apple.Jonathan; i<= (int)Apple.McIntosh; i++)
        for(a = 0, i = (int)Apple.Jonathan; i<= (int)Apple.McIntosh; i++)
            Console.WriteLine(a++ + " has color of " + color[i]);
    }
}