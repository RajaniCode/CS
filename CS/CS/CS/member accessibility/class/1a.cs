using System;

class DefferentAssemblyMainClass
{
    static void Main()
    {
        BaseClass bc = new BaseClass();
        
        BaseClass.staticmethodBaseClass();          

        bc.instancemethodBaseClass();

        DerivedClass dc = new DerivedClass();
   
        DerivedClass.staticmethodDerivedClass();

        dc.instancemethodDerivedClass();
    }
}


// >csc 1.cs

// >csc 1a.cs /reference:1.exe

// >csc 1a

// OR

// >csc /t:library 1.cs

// >csc 1a.cs /reference:1.dll

// >csc 1a