// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation


using System;

class MainClass
{     
    private enum Apple {Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh}; // Note
 
    static void Main()
    {
        string[] color = {"Green", "Yellow", "Red", "Reddish Green", "Reddish Yellow", "Greenish Yellow"};

        Apple i;

        // Note: i is not int
        
        for(i = Apple.Jonathan; i<=Apple.McIntosh; i++)  // for(i = 0; i<=(Apple)5; i++) // for(i=Apple.McIntosh; i>=Apple.Jonathan; i--) 
            Console.WriteLine(i + " has value of " + (int)i); 

        for(i = Apple.Jonathan; i<=Apple.McIntosh; i++) // for(i = 0; i<=(Apple)5; i++)
            Console.WriteLine(i + " has color of " + color[(int)i]);
    }
}