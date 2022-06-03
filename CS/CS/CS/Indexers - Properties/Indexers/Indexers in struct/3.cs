// mulidimensional indexers in struct

using System;

struct MyStruct
{
    int[ , ] array; // Note two dimensional

    int row; // Note: index1 will be limited to row
    
    int column; // Note: index2 will be limited to column

    public bool error;

    public MyStruct(int r, int c) : this()
    {
        row = r;
        column = c;
        array = new int[row, column]; // Also: array = new int[r, c]
    }

    public int this[int index1, int index2] // Note
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

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct(3, 5); // Note
   
        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<6; i++)
            ms[i,i] = i; // Note

        for(int i=0; i<6; i++)
        {
            x = ms[i,i]; 
            if(x!=-1)
                Console.Write(x + " ");
        }

        Console.WriteLine("\nFail with error records: ");
        for(int i=0; i<6; i++)
        {
            ms[i,i] = i;
            if(ms.error)
                Console.WriteLine("ms[ " + i + ", " + i + "] out-of-bounds"); // Note
        }

        for(int i=0; i<6; i++)
        {
            x = ms[i,i]; 
            if(!ms.error)
                Console.Write(x + " ");
            else
                Console.WriteLine("ms[ " + i + ", " + i + "] out-of-bounds"); // Note 
        }
    }
}
        





    

    