using System;

namespace ExternAssembly
{
    public class ExternClass //Note: public
    {
        public ExternClass()
        {
            Console.WriteLine("Constructing from ExternAssemblyB.dll.");
        }
    }
}
