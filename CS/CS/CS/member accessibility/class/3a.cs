using System;

class DefferentAssemblyMainClass : BaseClass
{
    static void Main()
    {
        DefferentAssemblyMainClass damc = new DefferentAssemblyMainClass();
        
        BaseClass.staticmethodBaseClass();

        DefferentAssemblyMainClass.staticmethodBaseClass(); 
 
        staticmethodBaseClass();         

        damc.instancemethodBaseClass();        
    }
}


// >csc 3.cs

// >csc 3a.cs /reference:3.exe

// >csc 3a

// OR

// >csc /t:library 3.cs

// >csc 3a.cs /reference:3.dll

// >csc 3a