using System;

struct DefferentAssemblyMainStruct
{
    static void Main()
    {
        BaseStruct bs = new BaseStruct();
        
        BaseStruct.staticmethodBaseStruct();          

        bs.instancemethodBaseStruct();
    }
}


// >csc 1.cs

// >csc 1a.cs /reference:1.exe

// >csc 1a

// OR

// >csc /t:library 1.cs

// >csc 1a.cs /reference:1.dll

// >csc 1a