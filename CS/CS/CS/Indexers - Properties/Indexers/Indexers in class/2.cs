// overloading indexers 

using System;

class MyClass
{
    int[] array;

    public int l;

    public bool error;

    public MyClass(int size) 
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

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(5);

        for(int i=0; i<(mc.l*2); i++)
            mc[i] = i;

        Console.WriteLine("mc[1] = {0}", mc[1]);
        Console.WriteLine("mc[2] = {0}", mc[2]);
        Console.WriteLine("mc[1.4] = {0}", mc[1.4]);
        Console.WriteLine("mc[2.8] = {0}", mc[2.8]);
    }
}