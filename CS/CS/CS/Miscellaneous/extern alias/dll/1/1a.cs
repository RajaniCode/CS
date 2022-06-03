using System;

namespace Lnamespace.Library
{
    public class LibraryClass         // public 
    {
        public static void Library1() // public
        {
            Console.WriteLine ("Library1()");
        }
    }
}


//>csc /t:library 1a.cs

//>csc 1.cs 1b.cs /r:X=1a.dll


// OR


//>csc /target:library 1a.cs

//>csc 1.cs 1b.cs /reference:X=1a.dll