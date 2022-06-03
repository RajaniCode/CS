using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


namespace WebPartSample
{
	public class ListProperties
	{
        public string ListTitle { get; set; }
        public int ItemCount { get; set; }
        public int FieldCount { get; set; }
        public int FolderCount { get; set; }
        public int ViewCount {get; set; }
        public int WorkFlowCount { get; set; }
	}
}
