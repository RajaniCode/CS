// Friend Assembly


using System;

class MainClass
{   
    static void Main()
    {
        AssemblyClass ac = new AssemblyClass();
        
        AssemblyClass.staticMethod();
        ac.instanceMethod();


	AssemblyClass1 ac1 = new AssemblyClass1();
        
        AssemblyClass1.staticMethod1();
        ac1.instanceMethod1();
    }
}


//>csc /t:library 1a.cs

//>csc /r:1a.dll /out:1.exe 1.cs

//>1