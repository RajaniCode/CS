// indexers

using System;

class MyClass
{
    int[] array;
    
    public int l; // Note: index will be limited to l

    public bool error;

    public MyClass(int size)
    {
        array = new int[size];
        l = size;
    }

    // indexers cannot be static as 'this' cannot be used with static
    // public, being member of class // int, type of element being processed // this, keyword // int, type of array indexing // index, index of element being processed and not keyword 
    public int this[int index] 
    {
        get
        {
            if(ok(index)) // if ok method passed with index is true/false
            {
                error = false;
                return array[index]; // return value specified by index // array, elememt being processed
            }
            else
            {
                error = true;
                return 0;
            }
        }

        set
        {
            if(ok(index))
            {
                array[index] = value; // set value specified by index
                error = false;
            }
            else 
                error = true;
        }
    }

    bool ok(int index)
    {
        if((index>=0) && (index<l))
            return true;
        else
            return false;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(5); // mc indexed like an array // invoke constructor by passing argument 5 to parameter size

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.l*2); i++)  // Also: instead of mc.l, mc.array.Length but array should be public
            mc[i] = i; // assignment

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i]; // copy to x
            if(x!=-1) //
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mc.l*2); i++)
        {
            mc[i] = i; // assignment
            if(mc.error)
                Console.WriteLine("mc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i]; // copy to x
            if(!mc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("mc[ " + i + " ] out-of-bounds");
        }
    }
}