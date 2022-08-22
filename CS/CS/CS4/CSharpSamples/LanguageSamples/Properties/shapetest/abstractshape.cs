// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

// abstractshape.cs
// compile with: /target:library
// csc /target:library abstractshape.cs
using System;

public abstract class Shape
{
   private string myId;

   public Shape(string s)
   {
      Id = s;   // calling the set accessor of the Id property
   }

   public string Id
   {
      get 
      {
         return myId;
      }

      set
      {
         myId = value;
      }
   }

   // Area is a read-only property - only a get accessor is needed:
   public abstract double Area
   {
      get;
   }

   public override string ToString()
   {
      return Id + " Area = " + string.Format("{0:F2}",Area);
   }
}

