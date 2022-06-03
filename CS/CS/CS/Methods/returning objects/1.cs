// returning objects

using System;

class MyClass
{
    int width;
    int height;
  
    public MyClass(int w, int h)
    {
        width = w;
        height = h;
    }
   
    public void printMethod()
    {
       Console.WriteLine("printMethod:  width = {0}, height = {1}", width, height);
    }

    public int areaMethod()
    {
     return width *  height;
    }

    public MyClass enlargeMethod(int fp) // *Match: return type, class
    {
        return new MyClass(width * fp, height * fp); // Note
    }
}

class MainClass
{
    static void Main()
    {
        int f = 10;

        MyClass mc1 = new MyClass(5, 6);
        MyClass mc2; // *Match: type, class 
        
        mc1.printMethod();
  
        Console.WriteLine("Area = {0}", mc1.areaMethod());

        mc2 = mc1.enlargeMethod(f); // *Match: type = return type 
       
        mc2.printMethod(); // Note: mc2 has f
  
        Console.WriteLine("Area = {0}", mc2.areaMethod());
    }
}
