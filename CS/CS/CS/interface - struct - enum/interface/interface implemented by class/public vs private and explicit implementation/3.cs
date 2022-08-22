// interface // public vs private and explicit implementation by class(s)


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
       return !isEven(x);
    }
}

class MyClass2 : MyInterface
{
    public bool isEven(int x)    // public implementation   
    {
        if(x%2==0)
            return true;
        else
            return false;
    }

    bool MyInterface.isOdd(int x) // private and explicit implementation
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


        MyInterface mi = (MyInterface)mc; //  Keyword 'this' is not valid in a static property, static method, or static field initializer

        result = mi.isOdd(3);

        if(result)
            Console.WriteLine("3 is odd");


        MyClass2 mc2 = new MyClass2(); // Note
              
        result = mc2.isEven(6);

        if(result)
            Console.WriteLine("6 is even");


        mi = (MyInterface)mc2; //  Note
        result = mi.isOdd(5);

        if(result)
            Console.WriteLine("5 is odd");
    }
}