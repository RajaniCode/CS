using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

class MainClass
{
    public static void Main(string[] args)
    {
        string ShowMessage;
        string EnterMessage;
        string InputBoxTitle;
        string DefaultValue;

        object obj;


        EnterMessage = "Enter message";

        InputBoxTitle = "InputBox";

        DefaultValue = "";

        // Display dialog box at position 100, 100. 
        obj = Interaction.InputBox(EnterMessage, InputBoxTitle, DefaultValue, 500, 500);

        ShowMessage = (string)obj;

        if (ShowMessage != string.Empty)
            Interaction.MsgBox("Your message will be displayed in MessageBox!", 0, "MsgBox");

        MessageBox.Show(ShowMessage);
    }
}
