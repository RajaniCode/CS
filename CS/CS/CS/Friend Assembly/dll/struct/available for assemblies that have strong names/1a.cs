// Assembly shared with friend assembly

                                          
using System;
using System.Runtime.CompilerServices;  // NOTE
                                          
[assembly:InternalsVisibleTo("1,PublicKey=002400000480000094000000060200000024000052534131000400000100010051c1af46cf79f059fed5d781ff04dcc62a07c6d3f3954ba5b7e38485f52e8f982442ecf1733ed2418079a38696e15bb6fa2bccbafdf4a38d392df132d55847e20fd7215c7f4b9b9a84e88391091952e246fab50e047bd61ddfa3e31a14cf8279efcfa37665b9bbccbd5758a519de58f003d1e52c5a59ecacbe20f600dc744cd9")]      
// declaring friend assembly
struct AssemblyStruct               // internal (default)
{                                       
    internal static void staticMethod() // internal
    {                                    
        Console.WriteLine("\nstaticMethod() shared with friend assembly\n");
    }                                   
                                         
    internal void instanceMethod()      // internal
    {
        Console.WriteLine("\ninstanceMethod() shared with friend assembly\n");
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