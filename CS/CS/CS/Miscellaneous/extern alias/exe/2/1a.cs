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


//>csc 1b.cs

//>csc 1.cs 1a.cs /r:X=1b.exe


// OR


//>csc 1b.cs

//>csc 1.cs 1a.cs /reference:X=1b.exe