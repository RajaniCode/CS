// extern alias 


extern alias X; 

namespace Lnamespace.Library
{
    class MainClass
    {
        static void Main()
        {
            X::Lnamespace.Library.LibraryClass.Library2();
            
            X::LibraryClass.Library3();
            
            LibraryClass.Library1();
        }
    }
}    


//>csc /t:library 1b.cs

//>csc 1.cs 1a.cs /r:X=1b.dll


// OR


//>csc /target:library 1b.cs

//>csc 1.cs 1a.cs /reference:X=1b.dll