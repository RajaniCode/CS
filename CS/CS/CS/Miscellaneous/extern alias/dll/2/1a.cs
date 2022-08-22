using System;

namespace Lnamespace.Library
{
    class LibraryClass                // private
    {
        public static void Library1() // public
        {
            Console.WriteLine ("Library1()");
        }
    }
}


//>csc /t:library 1b.cs

//>csc 1.cs 1a.cs /r:X=1b.dll


// OR


//>csc /target:library 1b.cs

//>csc 1.cs 1a.cs /reference:X=1b.dll