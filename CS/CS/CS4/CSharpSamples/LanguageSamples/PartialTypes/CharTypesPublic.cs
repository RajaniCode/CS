// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassesExample
{
    // The partial keyword allows additional methods, fields, and
    // properties of this class to be defined in other .cs files.
    // This file contains the public methods defined by CharValues.
    partial class CharValues
    {
        public static int CountAlphabeticChars(string str)
        {
            int count = 0;
            foreach (char ch in str)
            {
                // IsAlphabetic is defined in CharTypesPrivate.cs
                if (IsAlphabetic(ch))
                    count++;
            }
            return count;
        }
        public static int CountNumericChars(string str)
        {
            int count = 0;
            foreach (char ch in str)
            {
                // IsNumeric is defined in CharTypesPrivate.cs
                if (IsNumeric(ch))
                    count++;
            }
            return count;
        }

    }
}

