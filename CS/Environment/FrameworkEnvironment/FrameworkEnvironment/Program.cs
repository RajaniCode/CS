using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

class Win32Registry
{
    public void Print()
    {
        // Windows ONLY // https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed
        const string FullSubkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full";
        // Feature 'nullable reference types' is not available in C# 7.3
        // const string? REG_DWORD = "Release";
        const string REG_DWORD = "Release";

        RegistryKey subKey = Registry.LocalMachine.OpenSubKey(FullSubkey);

        if (subKey != null)
        {
            IEnumerable<string> valueNames = subKey.GetValueNames().Where(x => x.Contains(REG_DWORD));

            if (valueNames != null && valueNames.Count() > 0)
            {
                Console.WriteLine(".NET Framework 4.5 or later installed");
                Console.WriteLine();
            }
        }
    }
}

class DiagnosticsProcess
{
    public void Print()
    {
        Process cmd = new Process();
        // Windows cmd
        cmd.StartInfo.FileName = "cmd.exe";
        // cmd.StartInfo.FileName = @"C:\Users\rajanis\AppData\Local\Programs\Git\git-bash.exe";
        cmd.StartInfo.RedirectStandardInput = true;
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.CreateNoWindow = true;
        cmd.StartInfo.UseShellExecute = false;
        cmd.Start();
        cmd.StandardInput.WriteLine("dotnet --version");

        StringBuilder builderString = new StringBuilder();
        builderString.Append("start");
        builderString.Append(" \"\" ");

        builderString.Append("\"");
        builderString.Append(@"C:\Users\rajanis\AppData\Local\Programs\Git\git-bash.exe");
        builderString.Append("\"");

        builderString.Append(" -c ");

        builderString.Append("\"");
        builderString.Append("command dotnet --version && /usr/bin/bash");
        builderString.Append("\"");

        string text = builderString.ToString();

        cmd.StandardInput.WriteLine(text);

        cmd.StandardInput.Flush();
        cmd.StandardInput.Close();
        cmd.WaitForExit();
        Console.WriteLine(cmd.StandardOutput.ReadToEnd());
    }
}

class Program
{
    static void Main()
    {
        // Environment.Version property returns the .NET runtime version for .NET 5+ and .NET Core 3.x
        // Not recommend for .NET Framework 4.5+
        Console.WriteLine($"Environment.Version: {Environment.Version}");
        // RuntimeInformation.FrameworkDescription property gets the name of the .NET installation on which an app is running
        // .NET 5+ and .NET Core 3.x // .NET Framework 4.7.1+ // Mono 5.10.1+
        Console.WriteLine($"RuntimeInformation.FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
        Console.WriteLine();

        // Feature 'target-typed object creation' is not available in C# 7.3
        // Win32Registry registryWin32 = new();
        Win32Registry registryWin32 = new Win32Registry();
        registryWin32.Print();
        
        // Feature 'target-typed object creation' is not available in C# 7.3
        // DiagnosticsProcess processDiagnostics = new();
        DiagnosticsProcess processDiagnostics = new DiagnosticsProcess();
        processDiagnostics.Print();
    }
}
