// indexers in interface, private and explicit implementation by class // indexers don't need an underlying array


using System;

interface MyInterface
{
    int this[int index]
    {
        get;
    }
}

class MyClass : MyInterface
{
    int MyInterface.this[int index]
    {
        get
        {
            if((index>=0) && (index<8))
                return twoPower(index);  // Note: not an array       
            else
                return -1;
        }
     }

    int twoPower(int p)  // Note
    {
        int result= 1;
        for(int i=0; i<p; i++)
            result *= 2;
        return result;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        MyInterface mi = (MyInterface)mc;
        
        for(int i=0; i<10; i++)
            Console.Write(mi[i] + " ");
    }
}       
        
        
        
    
        