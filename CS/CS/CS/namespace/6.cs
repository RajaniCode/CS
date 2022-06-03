// namespace // nested // alias // alias is not a keyword


using System;

using alias = Mynamespace.Mynestednamespace.MyClass;

class MainClass
{
    static void Main()
    {
        alias a = new alias(); // Note 
        a.myPrint();           // Note  // alais.myPrint(); // in case // public static void myPrint(); 
       
        myPrint(); // Class not required calling the static member (method) of the same class
        // MainClass mc = new MainClass(); // But object required while calling the instance member (method) of the same class
        // mc.myPrint();
    }
     
    static void myPrint() // static membe // void myPrint() // instance member
    {
        Console.WriteLine("MainClass Class");
    }
}

namespace Mynamespace.Mynestednamespace
{
    class MyClass
    {
        public void myPrint() // public static void myPrint();
        {
            Console.WriteLine("MyClass Class");
        }
    }
}
            

    