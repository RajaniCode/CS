// indexers in struct // Note: : this()

using System;

struct MyStruct
{
    int[] array;
    
    public int l; // Note: index will be limited to l

    public bool error;

    public MyStruct(int size) : this() // Note
    {
        array = new int[size];
        l = size;
    }

    // indexers cannot be static as 'this' cannot be used with static
    // public, being member of struct // int, type of element being processed // this, keyword // int, type of array indexing // index, index of element being processed and not keyword 
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

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct(5); // mc indexed like an array // invoke constructor by passing argument 5 to parameter size

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(ms.l*2); i++)  // Also: instead of ms.l, ms.array.Length but array should be public
            ms[i] = i; // assignment

        for(int i=0; i<(ms.l*2); i++) 
        {
            x = ms[i]; // copy to x
            if(x!=-1) //
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(ms.l*2); i++)
        {
            ms[i] = i; // assignment
            if(ms.error)
                Console.WriteLine("ms[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(ms.l*2); i++) 
        {
            x = ms[i]; // copy to x
            if(!ms.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("ms[ " + i + " ] out-of-bounds");
        }
    }
}