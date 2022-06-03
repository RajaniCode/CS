// interface // public vs private and explicit implementation by struct(s)


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
} 

struct MyStruct2 : MyInterface
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

struct MainStruct 
{ 
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

        MyStruct2 ms2 = new MyStruct2(); 
      
        result = ms2.isEven(6);

        if(result)
            Console.WriteLine("6 is even");
        
        mi  = (MyInterface)ms2; // Note

        result = mi.isOdd(5);

        if(result)
            Console.WriteLine("5 is odd");
    }
}