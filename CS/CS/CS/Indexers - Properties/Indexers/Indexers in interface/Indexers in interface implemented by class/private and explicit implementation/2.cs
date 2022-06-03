// overloading indexers in interface, private and explicit implementation by class


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


class MyClass : MyInterface 
{
    int[] array;

    public int l;

    public bool error;

    public MyClass(int size) 
    {
        array = new int[size];
        l = size;
    }

    int MyInterface.this[int index]
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

    int MyInterface.this[double idx] // overloading indexer
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

        MyInterface mi = (MyInterface)mc;

        for(int i=0; i<(mc.l*2); i++) // *Note
            mi[i] = i; // Note

        Console.WriteLine("mi[1] = {0}", mi[1]);
        Console.WriteLine("mi[2] = {0}", mi[2]);
        Console.WriteLine("mi[1.4] = {0}", mi[1.4]);
        Console.WriteLine("mi[2.8] = {0}", mi[2.8]);
    }
}