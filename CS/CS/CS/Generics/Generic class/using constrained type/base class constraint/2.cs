// Generic class // using constrained type // using base class constraint


using System;

class NotFoundException : ApplicationException
{

}

class Phone
{
    string nme;
    int nmr;    

    public string name
    {
        get
        {
            return nme;
        }
        set
        {
            nme = value;
        }
    }  

    public int number
    {
        get
        {
            return nmr;
        }
        set
        {
            nmr = value;
        }
    }

    public Phone(string nmep, int nmrp)
    {
        nme = nmep;
        nmr = nmrp;                
    }   
}

class Office :  Phone
{
    bool wp;
   
    public bool workplace
    {
        get
        {
            return wp;
        } 
    }

    public Office(string namep, int numberp, bool wpp) : base(namep, numberp)
    {
        wp = wpp;
    }
}

class Home : Phone
{
    public Home(string namep, int numberp) : base(namep, numberp)
    {
       
    }
}

class PhoneList<T> where T : Phone
{
    T[] plist;
    int end;

    public PhoneList()
    {
        plist = new T[10];
        end = 0;
    }

    public bool addEntry(T entry)
    {
        if(end==10)
            return false;

        plist[end] = entry;
        end++;
        return true;
    }

    public T nameFind(string namep)
    {
        for(int i=0; i<end; i++)
        {
            if(plist[i].name == namep)
                return plist[i];
        }

        throw new NotFoundException();
    }

    public T numberFind(int numberp)
    {
        for(int i=0; i<end; i++)
        {
            if(plist[i].number == numberp)
                return plist[i];
        }

        throw new NotFoundException(); // Note
    }
}

class MainClass
{
    static void Main()
    {
        PhoneList<Office> PO = new PhoneList<Office>();

        PO.addEntry(new Office("Bill", 123456789, true));
        PO.addEntry(new Office("Gates",543219876, false));
        PO.addEntry(new Office("Bjarne", 987654321, true));
  
        try
        {
            Office of = PO.nameFind("Bill");
           
            Console.Write(of.name + " " + of.number);  

            if(of.workplace) // Note: checking property
                Console.Write(" (workplace)\n");
            else
                Console.Write("\n");     
        }
        catch(NotFoundException)
        {
            Console.WriteLine("\nNot found!\n");
        }

        PhoneList<Home> PH = new PhoneList<Home>();

        PH.addEntry(new Home("straustrup", 777777777));
        PH.addEntry(new Home("James",555555555));
        PH.addEntry(new Home("Goosling", 999999999));
        
        Console.WriteLine("\n");

        try
        {
            Home ho = PH.nameFind("straustrup");
           
            Console.Write(ho.name + " " + ho.number + "\n");             
        }
        catch(NotFoundException)
        {
            Console.WriteLine("\nNot found!\n");
        }
    }
}
                
        
        
            

              
    
 
 
    
    
     

     
 
  
    