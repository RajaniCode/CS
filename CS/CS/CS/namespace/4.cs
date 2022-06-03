// namespace // nested


using System;

namespace Mynamespace
{
    namespace Mynestednamespace
    {
        class MyClass1
        {
            //can be internal, protected internal as accessed from outside the class but within same namespace although nested; but cannot be private (default) or protected
            public void myPrint() // public, access outside class // static, access using class
            {
                Console.WriteLine("Print1");
            }
        }
    }
    
    class MainClass 
    {
        static void Main()
        {
            Mynestednamespace.MyClass1 mc1 = new Mynestednamespace.MyClass1();                                             // No need for Mynamespace
            mc1.myPrint();  
             
            Mynestednamespace.MyClass2 mc2 = new Mynestednamespace.MyClass2();                                             // No need for Mynamespace
            mc2.myPrint(); // in case of // public void myPrint() // in // class MyClass2
           
            // Mynestednamespace.MyClass1.myPrint(); // in case of // public static void myPrint() // in // class MyClass1 // No need for Mynamespace
            // Mynestednamespace.MyClass2.myPrint(); // in case of // public static void myPrint() // in // class MyClass2 // No need for Mynamespace
        }
    }
}

namespace Mynamespace.Mynestednamespace
{
    class MyClass2
    {
        //can be internal, protected internal as accessed from outside the class but within same namespace; but cannot be private (default) or protected
        public void myPrint() // public, access outside class // static, access using class
        {
            Console.WriteLine("Print2");
        }        
    }
}   


     
    