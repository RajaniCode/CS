// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// Hello3.cs
// arguments: A B C D
using System;

public class Hello3
{
   public static void Main(string[] args)
   {
      Console.WriteLine("Hello, World!");
      Console.WriteLine("You entered the following {0} command line arguments:",
         args.Length );
      for (int i=0; i < args.Length; i++)
      {
         Console.WriteLine("{0}", args[i]); 
      }
   }
}

