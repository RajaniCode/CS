using System;

namespace Lnamespace.Library
{
    class LibraryClass         
    {
        public static void Library2() // public
        {
            Console.WriteLine ("Library2()");
        }
    }
}

class LibraryClass
{
    public static void Library3() // public
    {
        Console.WriteLine ("Library3()");
    }
}


//>csc /t:library 1a.cs

//>csc 1.cs 1b.cs /r:X=1a.dll


// OR


//>csc /target:library 1a.cs

//>csc 1.cs 1b.cs /reference:X=1a.dll