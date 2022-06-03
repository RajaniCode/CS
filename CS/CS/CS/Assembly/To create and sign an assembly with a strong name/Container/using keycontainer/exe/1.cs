// Assembly // To create and sign an assembly with a strong name using keycontainer


using System;

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

        static void Main()
        {

        } 
    }   
}


//>sn -k sgKey.snk

//>sn -p sgKey.snk publicKey.snk

//>sn -tp publicKey.snk

//>sn -i sgKey.snk MyContainer

//>csc 1.cs /keycontainer:MyContainer

//>sn -Tp 1.exe


//>sn -d MyContainer