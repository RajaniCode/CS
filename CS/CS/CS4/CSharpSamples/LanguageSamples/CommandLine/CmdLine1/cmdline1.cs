// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// cmdline1.cs
// arguments: A B C
using System;

public class CommandLine
{
   public static void Main(string[] args)
   {
       // The Length property is used to obtain the length of the array. 
       // Notice that Length is a read-only property:
       Console.WriteLine("Number of command line parameters = {0}",
          args.Length);
       for(int i = 0; i < args.Length; i++)
       {
           Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
       }
   }
}

