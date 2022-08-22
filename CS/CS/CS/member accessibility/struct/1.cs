// struct memeber accessibility

// public

using System;

public struct BaseStruct
{
    public static void staticmethodBaseStruct()
    {
        Console.WriteLine("staticmethodBaseStruct()\n");
    }
 
    public void instancemethodBaseStruct()
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