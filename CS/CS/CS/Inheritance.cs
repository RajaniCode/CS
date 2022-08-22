using System;

class BaseClass
{
    protected void BaseMethod()
    {
        Console.WriteLine("BaseMethod()");
    }

}

class DerivedClass : BaseClass
{
    public void DerivedMethod()
    {
        base.BaseMethod();
        this.BaseMethod();
        BaseMethod();
        BaseClass bc = new BaseClass();
        // DerivedClass
        // bc.BaseMethod(); // Won't compile
        DerivedClass dc = new DerivedClass();
        dc.BaseMethod();
        DerivedDerivedClass ddc = new DerivedDerivedClass();
        ddc.BaseMethod();
        Console.WriteLine("DerivedClass");
    }
}

class DerivedDerivedClass : DerivedClass
{


}
class Program
{
    public void Print()
    {
        //BaseClass bc = new BaseClass();
        //BaseClass bcr;
        //DerivedClass dc = new DerivedClass();
        
        //bcr = dc;

        //bc = dc;
        //dc = (DerivedClass)bc as DerivedClass;

        DerivedClass dc = new DerivedClass();
        dc.DerivedMethod();
    }

    static void Main(string[] args)
    {
        Program p = new Program();
        p.Print();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
