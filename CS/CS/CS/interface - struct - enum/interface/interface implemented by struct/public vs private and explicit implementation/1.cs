// interface // public vs private and explicit implementation by struct


using System;

interface MyInterface
{
    bool isEven(int x);
    bool isOdd(int x);
}

struct MyStruct : MyInterface
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
} //

struct MainStruct //
{ //
    static void Main()
    {
        MyStruct ms = new MyStruct();
      
        bool result;
        
        result = ms.isEven(4);

        if(result)
            Console.WriteLine("4 is even");
        
        MyInterface mi  = (MyInterface)ms;

        result = mi.isOdd(3);

        if(result)
            Console.WriteLine("3 is odd");
    }
}