// Generic class // using constrained type // using interface constraint

using System;

class NotFoundException : ApplicationException
{

}

interface Phone
{
    string name
    {
        get;
        set;
    }
 
    int number
    {
        get;
        set;
    }
}

class Office : Phone
{
    string nme;
    int nmr;
    bool wp;

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

    public bool workplace
    {
        get
        {
            return wp;
        }
    }
       

    public Office(string nmep, int nmrp, bool wpp)
    {
        nme = nmep;
        nmr = nmrp;
        wp = wpp;
    }  
}
 

class Home : Phone
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

    public Home(string nmep, int nmrp)
    {
        nme = nmep;
        nmr = nmrp;
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
        
        throw new NotFoundException();        
    }
}

class MainClass
{
    static void Main()
    {
        PhoneList<Office> PO = new PhoneList<Office>();

        PO.addEntry(new Office("Bill", 123456789, true));
        PO.addEntry(new Office("Gates", 543216789, false)); 
        PO.addEntry(new Office("Bjarne", 987654321, true));

        try
        {
            Office of = PO.nameFind("Gates");
     
            Console.Write(of.name + " " + of.number);

            if(of.workplace)
                Console.Write(" (workplace)\n");
            else
                Console.Write("\n");
        }
        catch(NotFoundException)
        {
            Console.Write("\nNot found!\n");
        }

        PhoneList<Home> PH = new PhoneList<Home>();

        PH.addEntry(new Home("Straustrup", 777777777));
        PH.addEntry(new Home("James", 555555555)); 
        PH.addEntry(new Home("Goosling", 999999999));

        try
        {
            Home ho = PH.nameFind("Goosling");
     
            Console.Write(ho.name + " " + ho.number);            
        }
        catch(NotFoundException)
        {
            Console.Write("\nNot found!\n");
        }
    }
}    
        
    