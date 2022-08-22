// Friend Assembly


using System;

struct MainStruct
{   
    static void Main()
    {
        AssemblyStruct structAssembly = new AssemblyStruct();
        
        AssemblyStruct.staticMethod();
        structAssembly.instanceMethod();
    }
}


//>csc /t:library 1a.cs

//>csc /r:1a.dll /out:1.exe 1.cs

//>1