// interface(s) // public vs private and explicit implementation by class


using System;

interface MyInterface1
{
    bool isEven(int x);    
}

interface MyInterface2
{
    bool isOdd(int x);   
}

class MyClass : MyInterface1, MyInterface2
{
    public bool isEven(int x)        // public implementation  
    {
        if(x%2==0)
            return true;
        else
            return false;
    }

    bool MyInterface2.isOdd(int x)  // private and explicit implementation
    {
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


        MyInterface2 mi2 = (MyInterface2)mc; //  Keyword 'this' is not valid in a static property, static method, or static field initializer

        result = mi2.isOdd(3);

        if(result)
            Console.WriteLine("3 is odd");
    }
}