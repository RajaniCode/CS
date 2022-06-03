// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// Marshal.cs
using System;
using System.Runtime.InteropServices;

class PlatformInvokeTest
{
    [DllImport("msvcrt.dll")]
    public static extern int puts(
        [MarshalAs(UnmanagedType.LPStr)]
        string m);
    [DllImport("msvcrt.dll")]
    internal static extern int _flushall();


    public static void Main() 
    {
        puts("Hello World!");
        _flushall();
    }
}

