// namespace // using directive
 

using System;

using Mynamespace.Mynestednamespace; // Note
 
class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(); // access instance member
        mc.myPrint(); // access instance member
        // MyClass.myPrint(); // access static member
    }
}

namespace Mynamespace.Mynestednamespace
{
    class MyClass
    {
        public void myPrint() // instance member // public static void myPrint() // static member
        {
            Console.WriteLine("Print");
        }
    }
}
        
        