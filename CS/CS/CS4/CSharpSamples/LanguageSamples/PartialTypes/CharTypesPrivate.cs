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
    // This file contains private methods defined by CharValues.
    partial class CharValues
    {
        private static bool IsAlphabetic(char ch)
        {
            if (ch >= 'a' && ch <= 'z')
                return true;
            if (ch >= 'A' && ch <= 'Z')
                return true;
            return false;
        }

        private static bool IsNumeric(char ch)
        {
            if (ch >= '0' && ch <= '9')
                return true;
            return false;
        }
    }
}

