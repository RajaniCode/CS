// anonymous method

using System;

delegate void MyDelegate();
  
class MainClass
{
    static void Main()
    {
        MyDelegate md = delegate
        {
            for(int i=0; i<5; i++)
                Console.WriteLine(i);
        }; // Note
        
        md();
    }
}