using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

class Program
{
    // <AllowUnsafeBlocks>true</AllowUnsafeBlocks>

    [DllImport(@"D:\RajaniS Master Folder\.NET\CS\CS.NET-Core\CS9\CdeclStdcall\stdcall.dll", EntryPoint = "hello_stdcall", CharSet=CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
    unsafe static extern void hello_stdcall();

    [DllImport(@"D:\RajaniS Master Folder\.NET\CS\CS.NET-Core\CS9\CdeclStdcall\cdecl.dll", EntryPoint = "hello_cdecl", CharSet=CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    unsafe static extern void hello_cdecl();

    [DllImport(@"D:\RajaniS Master Folder\.NET\CS\CS.NET-Core\CS9\CdeclStdcall\thiscall.dll", EntryPoint = "hello_thiscall", CharSet=CharSet.Unicode, CallingConvention = CallingConvention.ThisCall)]
    unsafe static extern void hello_thiscall(char* c);

    unsafe public void Print() 
    {
        // Unmanaged calling convention: must be one of stdcall, cdecl, or thiscall
        // Thiscall requires that the first parameter is present and can be enregistered
        string marshal = "Marshal: thiscall";
        IntPtr iptrmarshal = Marshal.StringToHGlobalAnsi(marshal);  
        char *cptrmarshal = (char*)iptrmarshal.ToPointer();
        /*
        delegate* unmanaged <void> delUnmanagedS = (delegate* unmanaged <void>)(delegate* <void>)&hello_stdcall;
        delegate* unmanaged <void> delUnmanagedC = (delegate* unmanaged <void>)(delegate* <void>)&hello_cdecl;
        delegate* unmanaged <char*, void> delUnmanagedT = (delegate* unmanaged <char*, void>)(delegate* <char*, void>)&hello_thiscall;
  	delUnmanagedS();
        delUnmanagedC();
        delUnmanagedT(cptrmarshal);
        */	

        delegate* unmanaged[Stdcall]<void> delUnmanagedStdcall = (delegate* unmanaged[Stdcall]<void>)(delegate* <void>)&hello_stdcall;
        delegate* unmanaged[Cdecl]<void> delUnmanagedCdecl = (delegate* unmanaged[Cdecl]<void>)(delegate* <void>)&hello_cdecl;
        delegate* unmanaged[Thiscall]<char*, void> delUnmanagedThiscall = (delegate* unmanaged[Thiscall]<char*, void>)(delegate* <char*, void>)&hello_thiscall;
	delUnmanagedStdcall();
        delUnmanagedCdecl();
        delUnmanagedThiscall(cptrmarshal);
    }

    static void Main()
    {    
        Program prgm = new();
        prgm.Print();       
    }
}