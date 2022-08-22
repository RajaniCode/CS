class MainClass
{   
    static void Main()
    {
        PrintClass.printMethod();
    }
}


//>>csc /t:library 1a.cs

//>>csc 1.cs /r:1a.dll