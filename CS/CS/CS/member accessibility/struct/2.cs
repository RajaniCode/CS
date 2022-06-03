// struct memeber accessibility

// private (default)

using System;

struct MainStruct // Note
{
    private static void staticmethodMainStruct()
    {
        Console.WriteLine("staticmethodMainStruct()\n");
    }
 
    private void instancemethodMainStruct()
    {
        Console.WriteLine("instancemethodMainStruct()\n");
    }      
   
    // Note

    static void Main()
    {
        MainStruct ms = new MainStruct();
        
        staticmethodMainStruct(); // same struct          

        ms.instancemethodMainStruct();
    }
}
      
 