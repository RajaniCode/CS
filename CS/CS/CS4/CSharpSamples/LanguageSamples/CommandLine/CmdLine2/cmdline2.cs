// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// cmdline2.cs
// arguments: John Paul Mary
using System;

public class CommandLine2
{
   public static void Main(string[] args)
   {
       Console.WriteLine("Number of command line parameters = {0}",
          args.Length);
       foreach(string s in args)
       {
          Console.WriteLine(s);
       }
   }
}

