// Assembly shared with friend assembly

                                          
using System;
using System.Runtime.CompilerServices;  // NOTE
                                          
[assembly:InternalsVisibleTo("1,PublicKey=0024000004800000940000000602000000240000525341310004000001000100df6420f0f08876cd26d11c53f26a3919c247c7f85e5fd9219441551ef4de331e0f175fea1e32adfd5a4aad90bdd12a99562871c814244a7b272cce07762a5626c9e4d72ad186e7dad2315b5eb9d38fa28f2fb5e4bc2d0ee9a99c02c26d4a7c60800031b61ffc041da3b177397bfd5e080aca71214cb13d6767b98fa786d8e9d2")]


// declaring friend assembly
class AssemblyClass               // internal (default)
{                                       
    internal static void staticMethod() // internal
    {                                    
        Console.WriteLine("\nstaticMethod() shared with friend assembly\n");
    }                                   
                                         
    internal void instanceMethod()      // internal
    {
        Console.WriteLine("\ninstanceMethod() shared with friend assembly\n");
    }  

    static void Main()
    {

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