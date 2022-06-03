// mulidimensional indexers in interface, private and explicit implementation by class


using System;

interface MyInterface
{
    int this[int index1, int index2]
    {
        get;
        set;
    }
}

class MyClass : MyInterface
{
    int[ , ] array; // Note two dimensional

    int row; // Note: index1 will be limited to row
    
    int column; // Note: index2 will be limited to column

    public bool error;

    public MyClass(int r, int c)
    {
        row = r;
        column = c;
        array = new int[row, column]; // Also: array = new int[r, c]
    }

    int MyInterface.this[int index1, int index2] // Note
    {
        get
        {
            if(ok(index1, index2)) // Note
            {
                error = false;
                return array[index1, index2]; // Note
            }
            else
            {
                error = true;
                return 0;
            }
        }

        set
        {
            if(ok(index1, index2))
            {
                array[index1, index2] = value;
                error = false;
            }
            else
                error = true;               
        }
    }

    bool ok(int index1, int index2)
    {
        if((index1>=0 && index1<row) && (index1>=0 && index1<column)) // Note
            return true;
        else
            return false;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(3, 5); // Note
   
        int x;

        MyInterface mi = (MyInterface)mc; // Note

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<6; i++)
            mi[i,i] = i; // Note

        for(int i=0; i<6; i++)
        {
            x = mi[i,i]; // Note
            if(x!=-1)
                Console.Write(x + " ");
        }

        Console.WriteLine("\nFail with error records: ");
        for(int i=0; i<6; i++)
        {
            mi[i,i] = i; // Note
            if(mc.error)
                Console.WriteLine("mi[ " + i + ", " + i + "] out-of-bounds"); // Note
        }

        for(int i=0; i<6; i++)
        {
            x = mi[i,i]; // Note
            if(!mc.error)
                Console.Write(x + " ");
            else
                Console.WriteLine("mi[ " + i + ", " + i + "] out-of-bounds"); // Note 
        }
    }
}
        





    

    