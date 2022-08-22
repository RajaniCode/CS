// mulidimensional indexers in interface, public implementation by class


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
    public int[ , ] array;  // Note

    int row; 
    
    int column; 

    public int l; // Note

    public bool error;

    public MyClass(int r, int c)
    {
        row = r;
        column = c;
        array = new int[row, column]; 
        l = row * column; // Also: l = r * c; 
    }

    public int this[int index1, int index2] 
    {
        get
        {
            if(ok(index1, index2)) 
            {
                error = false;
                return array[index1, index2]; 
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
        if((index1>=0 && index1<row) && (index1>=0 && index1<column)) 
            return true;
        else
            return false;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(3, 5); 
   
        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.l); i++)
            mc[i,i] = i; 

        for(int i=0; i<(mc.l); i++)
        {
            x = mc[i,i]; 
            if(x!=-1)
                Console.Write(x + " ");
        }

        Console.WriteLine("\nFail with error records: ");
        for(int i=0; i<(mc.l); i++) // Note
        {
            mc[i,i] = i;
            if(mc.error)
                Console.WriteLine("mc[ " + i + ", " + i + "] out-of-bounds"); 
        }

        for(int i=0; i<(mc.l); i++)  // Note
        {
            x = mc[i,i]; 
            if(!mc.error)
                Console.Write(x + " ");
            else
                Console.WriteLine("mc[ " + i + ", " + i + "] out-of-bounds"); 
        }
    }
}
        





    

    