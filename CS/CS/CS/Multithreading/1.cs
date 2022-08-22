// Thread class

using System;
using System.Threading; // NOTE

class MyClass
{
    public int count;
    string name;

    public MyClass(string namep)
    {
        count = 0;
        name = namep;
    }

    public void run()
    {
        Console.WriteLine("Thread " + name + " starting");

        do
        {
            Thread.Sleep(500);
            Console.WriteLine("Thread count # " + count);
            count++;
        }while(count < 10);

        Console.WriteLine("Thread " + name + " terminating");
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass("MyThread");
       
        Thread tr = new Thread(new ThreadStart(mc.run)); // NOTE: run without parenthesis as ThreadStart is a delegate
  
        tr.Start();

        do
        {
            Console.Write(".");
            Thread.Sleep(500);
        } while(mc.count != 10);
    }
}
   
