// class (essentially namespace)


using System;

class A 
{

}
 
class B // access has nothing to do with its method's access
{
   A F() 
   {
       A a = new A();

       return a;
   }

   internal A G() 
   {
       return new A();
   }

   A H() // public not possible because return type (class) cannot be less accessible than the method 
   {
      return new A();
   }
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Please note");
    }
}