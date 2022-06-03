// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// CondMethod.cs
// compile with: /target:library /d:DEBUG
using System; 
using System.Diagnostics;
namespace TraceFunctions 
{
   public class Trace 
   { 
       [Conditional("DEBUG")] 
       public static void Message(string traceMessage) 
       { 
           Console.WriteLine("[TRACE] - " + traceMessage); 
       } 
   } 
}

