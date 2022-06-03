// overloading indexers in interface, public implementation by struct
 

using System;

interface MyInterface 
{
    int this[int index] // Note
    {
        get; // Note
        set; // Note
    }

    int this[double idx] // Note
    {
        get; // Note
        set; // Note
    }
}

struct MyStruct : MyInterface 
{
    int[] array;

    public int l;

    public bool error;

    public MyStruct(int size) : this()
    {
        array = new int[size];
        l = size;
    }

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

    public int this[double idx] // overloading indexer
    {
        get
        {
            int index; // Note

            if((idx-(int)idx) < .5) // Note
                index = (int)idx;
            else
                index = (int)idx + 1;

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
            int index; // Note

            if((idx-(int)idx) < .5) // Note
                index = (int)idx;
            else
                index = (int)idx + 1;

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
        if((index>=0) && (index < l))
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

        for(int i=0; i<(ms.l*2); i++)
            ms[i] = i;

        Console.WriteLine("ms[1] = {0}", ms[1]);
        Console.WriteLine("ms[2] = {0}", ms[2]);
        Console.WriteLine("ms[1.4] = {0}", ms[1.4]);
        Console.WriteLine("ms[2.8] = {0}", ms[2.8]);
    }
}