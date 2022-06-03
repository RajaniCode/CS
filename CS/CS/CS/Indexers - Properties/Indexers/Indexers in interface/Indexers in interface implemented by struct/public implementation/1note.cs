// indexers in interface, public implementation by struct // Note: : this()


using System;

interface MyInterface
{
    int this[int index]
    {
        get;
        set;
    }
}

struct MyStruct : MyInterface
{
    public int[] array; //Note: public for ms.array.Length
    
    public int l;

    public bool error;

    public MyStruct(int size) : this() // Note
    {
        array = new int[size];
        l = size;
    }

    // public, being member of struct // int, type of element being processed // this, keyword // int, type of array indexing // index, index of element being processed and not keyword 
    public int this[int index] 
    {
        get
        {
            if(ok(index)) 
            {
                error = false;
                return array[index]; 
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
                array[index] = value; 
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
        MyStruct ms = new MyStruct(5); 

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(ms.array.Length*2); i++)  // Note: instead of ms.l, ms.array.Length 
            ms[i] = i; 

        for(int i=0; i<(ms.array.Length*2); i++) 
        {
            x = ms[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(ms.array.Length*2); i++)
        {
            ms[i] = i; 
            if(ms.error)
                Console.WriteLine("ms[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(ms.array.Length*2); i++) 
        {
            x = ms[i]; 
            if(!ms.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("ms[ " + i + " ] out-of-bounds");
        }
    }
}