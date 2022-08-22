using System;

namespace Lnamespace.Library
{
    public class LibraryClass         // public         
    {
        public static void Library2() // public
        {
            Console.WriteLine ("Library2()");
        }
    }
}

public class LibraryClass
{
    public static void Library3() // public
    {
        Console.WriteLine ("Library3()");
    }
}


//>csc /t:library 1b.cs

//>csc 1.cs 1a.cs /r:X=1b.dll


// OR


//>csc /target:library 1b.cs

//>csc 1.cs 1a.cs /reference:X=1b.dll