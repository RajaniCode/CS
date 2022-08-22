// indexers in class // indexers don't need an underlying array


using System;

class MyClass
{
    public int this[int index]
    {
        get
        {
            if((index>=0) && (index<8))
                return power(index);  // Note: not an array       
            else
                return -1;
        }
     }

    int power(int p)  // Note
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
        
        for(int i=0; i<10; i++)
            Console.Write(mc[i] + " ");
    }
}       
        
        
        
    
        