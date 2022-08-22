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


// >csc 5.cs

// >csc 5a.cs /reference:5.exe

// >csc 5a

// OR

// >csc /t:library 5.cs

// >csc 5a.cs /reference:5.dll

// >csc 5a