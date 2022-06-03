using System;
using System.Text;
using System.Runtime.InteropServices;

class Program
{   
    [DllImport("msys64-mingw64-gcc.dll", CharSet=CharSet.Unicode)]
    // unsafe public static extern char* hello_world(char* x, char* y);
    unsafe public static extern char* hello_world(char *x, char *y);

    [DllImport("msys64-mingw64-gcc.dll", CharSet=CharSet.Unicode)]
    // unsafe public static extern char* hello(char* x);
    unsafe public static extern char* hello(char *x);

    [DllImport("msys64-mingw64-gcc.dll", CharSet=CharSet.Unicode)]
    // unsafe public static extern char* world(char* y);
    unsafe public static extern char* world(char *y);

    static void Main()
    { 
        string hw = "Hello, ";
        string h = "World!";
        string w = "World";

        unsafe 
        {
            IntPtr iptrhw = Marshal.StringToHGlobalAnsi(hw);
            IntPtr iptrh = Marshal.StringToHGlobalAnsi(h);
            IntPtr iptrw = Marshal.StringToHGlobalAnsi(w);           

            char* cptrhw = (char*)iptrhw.ToPointer();
            char* cptrh = (char*)iptrh.ToPointer();
            char* cptrw = (char*)iptrw.ToPointer();

            char* cphw = hello_world(cptrhw, cptrh);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)cphw));

            char* cph = hello(cptrh);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)cph));

            char* cpw = world(cptrw);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)cpw));
        }
    }
}