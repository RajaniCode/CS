// [although not virtual in interface, indexers (can only be instance) [can only be accessor based] in interface can be mapped onto virtual 
// in the implementing (only public implementation is possible) class/abstract class]

// Note: what happens when not overridden


using System;

interface MyInterface
{
    int this[int index]
    {
        get;
        set;
    }  
}

class BaseClass : MyInterface
{
    public int[] array; // Note: public 
    
    public int l; 

    public bool error;

    public BaseClass() // Note
    {
        array = new int[0];
        l = 0;
    } 
    public BaseClass(int size) 
    {
        array = new int[size];
        l = size;
    }

  
    public virtual int this[int index] 
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
                return 0;    //Note
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

class DerivedClass : BaseClass
{  
    public DerivedClass() // Note
    {
        array = new int[0];
        l = 0;
    } 

    public DerivedClass(int size)
    {
        array = new int[size];
        l = size;
    }

    // virtual indexer not overridden
}

class MainClass
{
    static void Main()
    {
        int x;

        Console.WriteLine("\n# 1");     
        BaseClass bc = new BaseClass(5); 
        
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(bc.l*2); i++)  
            bc[i] = i; 

        for(int i=0; i<(bc.l*2); i++) 
        {
            x = bc[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
        Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(bc.l*2); i++)
        {
            bc[i] = i; 
            if(bc.error)
                Console.WriteLine("bc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(bc.l*2); i++) 
        {
            x = bc[i]; 
            if(!bc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("bc[ " + i + " ] out-of-bounds");
        }
              
        Console.WriteLine("\n# 2");  
        BaseClass bcr;   
        DerivedClass dc = new DerivedClass(7); 
        bcr = dc;        

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(bcr.l*2); i++)  
           bcr[i] = i; 

        for(int i=0; i<(bcr.l*2); i++) 
        {
            x = bcr[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(bcr.l*2); i++)
       {
           bcr[i] = i; 
           if(bcr.error)
                Console.WriteLine("bcr[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(bcr.l*2); i++) 
       {
           x = bcr[i]; 
           if(!bcr.error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("bcr[ " + i + " ] out-of-bounds");
       }  


        Console.WriteLine("\n# 3");     
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(dc.l*2); i++)  
           dc[i] = i; 

        for(int i=0; i<(dc.l*2); i++) 
        {
            x = dc[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(dc.l*2); i++)
       {
           dc[i] = i; 
           if(dc.error)
                Console.WriteLine("dc[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(dc.l*2); i++) 
       {
           x = dc[i]; 
           if(!dc.error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("dc[ " + i + " ] out-of-bounds");
       }

       Console.WriteLine("\n# 4");     
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(((BaseClass)dc).l*2); i++)  
           dc[i] = i; 

        for(int i=0; i<(((BaseClass)dc).l*2); i++) 
        {
            x = ((BaseClass)dc)[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(((BaseClass)dc).l*2); i++)
       {
           ((BaseClass)dc)[i] = i; 
           if(((BaseClass)dc).error)
                Console.WriteLine("((BaseClass)dc)[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(((BaseClass)dc).l*2); i++) 
       {
           x = ((BaseClass)dc)[i]; 
           if(!((BaseClass)dc).error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("((BaseClass)dc)[ " + i + " ] out-of-bounds");
       }      
    }
}