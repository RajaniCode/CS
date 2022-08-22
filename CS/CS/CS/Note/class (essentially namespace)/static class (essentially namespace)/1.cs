// static class (essentially namespace)


using System;

static class StaticClass
{
    class MainClass
    {
        static void Main()
        {
            bool yes = true;
            bool no = false;
    
            Console.WriteLine("It's {0} that .NET is a Microsoft technology.", yes);
            Console.WriteLine("And this is not {0}.", no);
        }
    }
}

