// instance indexer and instance properties in interface, private and explicit implementation by class

// using l and error as properties

// #Note: 'MyInterface mi = this & mi;' in case of interface properties' private and explicit implementation by class/struct


using System;

interface MyInterface
{
    int l 
    {
        get; // Note: read-only 
    } 

    bool er
    {
        get; // Note: read-only
    } 

    int this[int index]   
    {
        get;
        set;
    }
}

class MyClass : MyInterface
{
    int[] array;
    
    int len; // Note

    int MyInterface.l // Note: read-only 
    {
        get
        {
            return len;
        }       
    }
   
    bool error; // Note
    
    bool MyInterface.er // Note: read-only
    {   
        get
        {
            return error;
        }    
    }
     
    public MyClass(int size)
    {
        array = new int[size];
        len = size; // Note: Because l is read-only
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

    bool ok(int index)
    {
       MyInterface mi = this;         // #Note

       if((index>=0) && (index<mi.l)) // #Note
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

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mi.l*2); i++)  
            mi[i] = i; 

        for(int i=0; i<(mi.l*2); i++) 
        {
            x = mi[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mi.l*2); i++)
        {
            mi[i] = i; 
            if(mi.er) // Note: error is private
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(mi.l*2); i++) 
        {
            x = mi[i]; 
            if(!mi.er) // Note: error is private
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds");
        }
    }
}