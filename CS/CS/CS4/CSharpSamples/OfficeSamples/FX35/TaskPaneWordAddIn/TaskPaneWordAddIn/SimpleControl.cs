// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace TaskPaneWordAddIn
{
    public partial class SimpleControl : UserControl
    {
        public SimpleControl()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(insertTextBox.Text))
                {
                    Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    object start = 0;
                    object end = 0;
                    Word.Range range = (Word.Range)document.Range(ref start, ref end);
                    range.InsertAfter(insertTextBox.Text);
                }
            }
            catch (COMException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
