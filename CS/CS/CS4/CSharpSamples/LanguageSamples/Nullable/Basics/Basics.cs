// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;

class NullableBasics
{
    static void DisplayValue(int? num)
    {
        if (num.HasValue == true)
        {
            Console.WriteLine("num = " + num);
        }
        else
        {
            Console.WriteLine("num = null");
        }

        // num.Value throws an InvalidOperationException if num.HasValue is false
        try
        {
            Console.WriteLine("value = {0}", num.Value);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        DisplayValue(1);
        DisplayValue(null);
    }
}