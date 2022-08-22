// extern alias // global:: //global predefined alias


extern alias X; 

namespace Lnamespace.Library
{
    class MainClass
    {
        static void Main()
        {
            LibraryClass.Library2();
            
            global::LibraryClass.Library3();
            
            X::Lnamespace.Library.LibraryClass.Library1();
        }
    }
}    


//>csc 1a.cs

//>csc 1.cs 1b.cs /r:X=1a.exe


// OR


//>csc 1a.cs

//>csc 1.cs 1b.cs /reference:X=1a.exe