// Friend Assembly


using System;

class MainClass
{   
    static void Main()
    {
        AssemblyClass ac = new AssemblyClass();
        
        AssemblyClass.staticMethod();
        ac.instanceMethod();
    }
}


//>csc 1a.cs

//>csc /r:1a.exe /out:1.exe 1.cs

//>1