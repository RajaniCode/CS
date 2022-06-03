// indexers in struct // indexers don't need an underlying array


using System;

struct MyStruct
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

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct();
        
        for(int i=0; i<10; i++)
            Console.Write(ms[i] + " ");
    }
}       
        
        
        
    
        