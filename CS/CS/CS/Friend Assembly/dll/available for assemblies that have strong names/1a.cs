// Assembly shared with friend assembly

                                          
using System;
using System.Runtime.CompilerServices;  // NOTE
                                          
[assembly:InternalsVisibleTo("1,PublicKey=0024000004800000940000000602000000240000525341310004000001000100430fdd5d8ddab439d9e0a0e5eb0726b6fe41ae314d2b98a52e6d5d2365e14cd50dad25e6f1085ca1fd4c137b70bd904c4d23e174ab49845d82fd241d9f0bb4816144f3cbd0dee48d5b808a59cd6cae997c215b9482e2e5dd520c1ad4636bf0fb4dd43e2c5d67e65dadc74a4d69a2b2288b0cf11365f58fd1c3e6108b72e3b58c")]      
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