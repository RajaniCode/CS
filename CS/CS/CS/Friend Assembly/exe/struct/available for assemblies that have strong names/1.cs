// Friend Assembly // strong named


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


//>sn -k sgKey.snk

//>sn -p sgKey.snk publickey.snk

//>sn -tp publickey.snk


// COPY Public key and NOT Public key token to the attribute in 1a.cs 


//csc 1a.cs /keyfile:sgKey.snk 

//>csc /keyfile:sgKey.snk /r:1a.exe /out:1.exe 1.cs

//>1


//>sn -Tp 1.exe