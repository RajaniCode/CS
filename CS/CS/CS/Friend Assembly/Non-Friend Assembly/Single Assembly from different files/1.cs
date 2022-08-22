// 1.cs and 1a.cs executed as a single assembly


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


//>>csc 1.cs 1a.cs

//>>1