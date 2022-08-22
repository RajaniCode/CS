// interface // public vs private and explicit implementation by class


using System;

interface MyInterface
{
    bool isEven(int x);
    bool isOdd(int x);
}

class MyClass : MyInterface
{
    public bool isEven(int x)     // public implementation  
    {
        if(x%2==0)
            return true;
        else
            return false;
    }

    bool MyInterface.isOdd(int x) // private and explicit implementation 
    {
       // MyInterface mi1 = this;
       // return !mi1.isEven(x);

        return !isEven(x);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(); 
      
        bool result;
        
        result = mc.isEven(4);

        if(result)
            Console.WriteLine("4 is even");


        MyInterface mi = (MyInterface)mc; //  Keyword 'this' is not valid in a static property, static method, or static field initializer

        result = mi.isOdd(3);

        if(result)
            Console.WriteLine("3 is odd");
    }
}
