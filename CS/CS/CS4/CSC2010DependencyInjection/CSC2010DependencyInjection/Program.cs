using System;

//class A and class B are Tightly Coupled
class A
{
    //Code
}

class B
{
    A a = new A();
    //Code
}

//Dependency Injection for Loose Coupling
interface IBusinessLogic
{

}

class ProductBusinessLogic : IBusinessLogic
{

}

class CustomerBusinessLogic : IBusinessLogic
{

}

interface IBusinessFacade
{
    void SetBusinessLogic(IBusinessLogic BusinessLogic);
}

class BusinessFacadeConstructorInjection
{
    IBusinessLogic BusinessLogic;
    public BusinessFacadeConstructorInjection(IBusinessLogic BusinessLogic)
    {
        this.BusinessLogic = BusinessLogic;
    }
}

class BusinessFacadeSettorInjection
{
    public IBusinessLogic BusinessLogic
    {
        get;
        set;
    }
}

class BusinessFacadeInterfaceInjection : IBusinessFacade
{
    IBusinessLogic BusinessLogic;
    public void SetBusinessLogic(IBusinessLogic BusinessLogic)
    {
        this.BusinessLogic = BusinessLogic;
    }
}

class Client
{
    static void Main()
    {
        IBusinessLogic Product = new ProductBusinessLogic();

        BusinessFacadeConstructorInjection ConstructorInjection = new BusinessFacadeConstructorInjection(Product);

        BusinessFacadeSettorInjection SettorInjection = new BusinessFacadeSettorInjection();
        SettorInjection.BusinessLogic = Product;

        BusinessFacadeInterfaceInjection InterfaceInjection = new BusinessFacadeInterfaceInjection();
        InterfaceInjection.SetBusinessLogic(Product);

        Console.ReadKey();
    }
}
