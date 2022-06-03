using System;

namespace Lnamespace.Library
{
    public class LibraryClass         // public 
    {
        public static void Library1() // public
        {
            Console.WriteLine ("Library1()");
        }
        
        static void Main()
        {

        }
    }
}


//>csc 1a.cs

//>csc 1.cs 1b.cs /r:X=1a.exe


// OR


//>csc 1a.cs

//>csc 1.cs 1b.cs /reference:X=1a.exe