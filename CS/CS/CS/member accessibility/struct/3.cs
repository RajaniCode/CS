// struct memeber accessibility

// internal

using System;

public struct BaseStruct
{
    internal static void staticmethodBaseStruct()
    {
        Console.WriteLine("staticmethodBaseStruct()\n");
    }
 
    internal void instancemethodBaseStruct()
    {
        Console.WriteLine("instancemethodBaseStruct()\n");
    }      
}


struct MainStruct
{
    static void Main()
    {
        BaseStruct bs = new BaseStruct();
    
        BaseStruct.staticmethodBaseStruct();          

        bs.instancemethodBaseStruct();
    }
}