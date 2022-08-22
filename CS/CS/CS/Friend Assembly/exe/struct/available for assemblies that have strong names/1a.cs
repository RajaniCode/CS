// Assembly shared with friend assembly

                                          
using System;
using System.Runtime.CompilerServices;  // NOTE
                                          
[assembly:InternalsVisibleTo("1,PublicKey=00240000048000009400000006020000002400005253413100040000010001000b30d8a536e79cf55dc9214d72118cb6752997c66bee23e6779040439a11e6baef1a407cc8231582ee23708f14c731baa0c83136bd371278cbba8363e139a0f6afd87af9c65d46071dcccc9b151dd1faff43475794d7847eb21887419ebd08e28c468e5f27889449fdb5d8d35b469c83ce8d45b3d01c62b7da074ec8de376aa9")]

// declaring friend assembly
struct AssemblyStruct              // internal (default)
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