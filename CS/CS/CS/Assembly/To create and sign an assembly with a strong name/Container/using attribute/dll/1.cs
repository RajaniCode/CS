// Assembly // To create and sign an assembly with a strong name using attribute


using System;
using System.Reflection;

[assembly:AssemblyKeyNameAttribute(@"MyContainer")] // NOTE
namespace MathLibrary
{ 
    public class MathClass
    {
        public long Add(long x, long y)
        {
            Console.WriteLine("Add");
            return x + y;
        }
         
        public long Sub(long x, long y)
        {
            Console.WriteLine("Sub");
            return x - y;
        } 
    }   
}


//>sn -k sgKey.snk

//>sn -p sgKey.snk publicKey.snk

//>sn -tp publicKey.snk

//>sn -i sgKey.snk MyContainer

//>csc /t:library 1.cs

//>sn -Tp 1.dll


//>sn -d MyContainer