// class memebr accessibility

// private (default)

using System;

class MainClass // Note
{
    private static void staticmethodMainClass()
    {
        Console.WriteLine("staticmethodMainClass()\n");
    }
 
    private void instancemethodMainClass()
    {
        Console.WriteLine("instancemethodMainClass()\n");
    }      
   
    // Note

    static void Main()
    {
        MainClass mc = new MainClass();
        
        staticmethodMainClass(); // same class          

        mc.instancemethodMainClass();
    }
}
      
 