// Friend Assembly // strong named


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


//>sn -k sgKey.snk

//>sn -p sgKey.snk publickey.snk

//>sn -tp publickey.snk


// COPY Public key and NOT Public key token to the attribute in 1a.cs 


//csc /t:library 1a.cs /keyfile:sgKey.snk 

//>csc /keyfile:sgKey.snk /r:1a.dll /out:1.exe 1.cs

//>1


//>csc /keyfile:sgKey.snk /r:1a.dll /out:1.dll 1.cs

//>sn -Tp 1.dll