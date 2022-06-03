// module


using System;

namespace ModuleNamespace
{
    public class ModuleClass
    {
        public static void Main()
        {
            Console.WriteLine("Main() in ModuleClass in ModuleNamespace");
        } 
    }
}


//>csc /t:module 1a.cs

//>al 1a.netmodule /target:exe /out:1.exe /main:ModuleNamespace.ModuleClass.Main