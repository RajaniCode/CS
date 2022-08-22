using System;
using System.Runtime.InteropServices;

class MainClass
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]

		public struct SHFILEOPSTRUCT
		{

			public IntPtr hwnd;

			[MarshalAs(UnmanagedType.U4)]

			public int wFunc;

			public string pFrom;

			public string pTo;

			public short fFlags;

			[MarshalAs(UnmanagedType.Bool)]

			public bool fAnyOperationsAborted;

			public IntPtr hNameMappings;

			public string lpszProgressTitle;
	} 

	[DllImport("shell32.dll", CharSet = CharSet.Auto)]

	static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

	const int FO_DELETE = 3;

	const int FOF_ALLOWUNDO = 0x40;

	const int FOF_NOCONFIRMATION = 0x10; //Don't prompt the user.; 
 

	private static void DeleteFileToRecycleBin(string filename)
	{

		SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();

		shf.wFunc = FO_DELETE;

		shf.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;

		shf.pFrom = filename + "\0"; 

		int result = SHFileOperation(ref shf); 

		if (result != 0)

			Console.WriteLine(string.Format("error: {0} while moving file {1} to recycle bin", result, filename));

	}
	
	public static void Main()
	{
		DeleteFileToRecycleBin("New Text file.txt");
	}
}
