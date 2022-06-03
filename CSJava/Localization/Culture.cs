using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

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

        Canonical canon = new Canonical();
        canon.Print();
    }
}

class Canonical
{
    private void CultureVariance(CultureInfo culture)
    {
        Thread.CurrentThread.CurrentCulture = culture;
        Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);

        // Achtung
        // The canonical example is the Turkish-I problem
        // The Turkish ("tr-TR") alphabet includes an "I with a dot" character "İ" (\u0130), which is the capital version of "i"
        // Turkish also includes a lowercase "i without a dot" character, "ı" (\u0131), which capitalizes to "I"
        // This behavior occurs in the Azerbaijani ("az") culture as well
        // Capitalizing "i" or lowercasing "I" are not valid among all cultures
        // The default overloads for string comparison routines will be subject to variance between cultures
        // If the data to be compared is non-linguistic, using the default overloads can produce undesirable results
        Console.WriteLine("title".ToUpper() == "t\u0131tle".ToUpper());
        Console.WriteLine("t\u0131tle".ToUpper());

        Console.WriteLine("title".ToUpper() == "tıtle".ToUpper());
        Console.WriteLine("tıtle".ToUpper());
	
	/*
        // Sort ONLY
        string i = "title";
        string iTurkish = "t\u0131tle";
	Console.WriteLine($"string.Compare: {string.Compare(i, iTurkish)}");
	Console.WriteLine($"string.Compare CultureInfo.CurrentCulture: {string.Compare(i, iTurkish, false, culture)}");
	Console.WriteLine($"string.Compare StringComparison.Ordinal: {string.Compare(i, iTurkish, StringComparison.Ordinal)}");
        Console.WriteLine($"string.Compare CultureInfo.CurrentCulture, CompareOptions.Ordinal: {string.Compare(i, iTurkish, culture, CompareOptions.Ordinal)}");
	*/

	/*
        // string email = "Tıtle@example.com"; // ı
        // Console.WriteLine(email);
        Console.WriteLine("Please enter your Turkish ı cmd input:); // ı // cmd only // Tıtle@Example.Com
        string email = Console.ReadLine();
        Console.WriteLine($"Email: {email}");

        string existingEmail = "title@example.com";
        Console.WriteLine($"Existing Email: {existingEmail}"); ;

        bool compare = email.Equals(existingEmail, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"string Equals StringComparison.OrdinalIgnoreCase: {compare}");

	// Fine for EFCore
	compare = email.Equals(existingEmail);
        Console.WriteLine($"string Equals: {compare}");
	*/

	Console.WriteLine(DateTime.Now);
	Console.WriteLine(DateTime.Now.ToString(culture));
	// string format = "dddd, MMMM dd, yyyy, h:mm:ss.fff tt, K";
        string format = "dddd, MMMM dd, yyyy, h:mm:ss.fff tt, zzz";
	Console.WriteLine(DateTime.Now.ToString(format));
        Console.WriteLine(DateTime.Now.ToString(format, culture));
        DateTime dateTimeParseExact = DateTime.ParseExact(DateTime.Now.ToString(format, culture), format, culture);
        Console.WriteLine(dateTimeParseExact);

	int start = 0;	
	Func<int, IEnumerable<string>> numbers = counter =>
            from i in Enumerable.Range(start, counter)
            where Enumerable.Range(1, 1).All(j => i >= start)
            select i.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
	int count = 10;
        numbers(count).ToList().ForEach(x => { Console.Write(x + " "); });
	Console.WriteLine();
	Console.WriteLine(string.Join(", ", numbers(count).ToArray()));

	Console.WriteLine(int.MinValue.ToString("C", CultureInfo.CurrentCulture.NumberFormat));
	Console.WriteLine(int.MaxValue.ToString("C", CultureInfo.CurrentCulture.NumberFormat));
        Console.WriteLine();
    }

    public void Print()
    {
        Console.WriteLine("Default");
        Console.WriteLine($"Thread.CurrentThread.CurrentCulture.Name: {Thread.CurrentThread.CurrentCulture.Name}");
        Console.WriteLine($"DateTime.Now: {DateTime.Now}");
	Console.WriteLine();

        CultureInfo currentCulture = CultureInfo.CurrentCulture;

        // Turkish
        CultureInfo turkish = new CultureInfo("tr-TR");
        CultureVariance(turkish);

        // Current Culture        
        CultureVariance(currentCulture);

        // Azerbaijani
        CultureInfo azerbaijani = new CultureInfo("az-Latn-AZ");
        CultureVariance(azerbaijani);

        // US "en-US" // OR // UK "en-GB"
        CultureInfo enU = new CultureInfo("en-GB");
        CultureVariance(enU);
    }
}

// Output
/*
Environment.Version: 4.0.30319.42000
RuntimeInformation.FrameworkDescription: .NET Framework 4.8.4390.0

Default
Thread.CurrentThread.CurrentCulture.Name: en-GB
DateTime.Now: 04/08/2021 11:38:01 AM

tr-TR
False
TITLE
4.08.2021 11:38:01
4.08.2021 11:38:01
Çarşamba, Ağustos 04, 2021, 11:38:01.758 ÖÖ, +05:30
Çarşamba, Ağustos 04, 2021, 11:38:01.773 ÖÖ, +05:30
4.08.2021 11:38:01

en-GB
True
TITLE
04/08/2021 11:38:01 AM
04/08/2021 11:38:01 AM
Wednesday, August 04, 2021, 11:38:01.773 AM, +05:30
Wednesday, August 04, 2021, 11:38:01.773 AM, +05:30
04/08/2021 11:38:01 AM

az-Latn-AZ
False
TITLE
04.08.2021 11:38:01
04.08.2021 11:38:01
çərşənbə, avqust 04, 2021, 11:38:01.773 AM, +05:30
çərşənbə, avqust 04, 2021, 11:38:01.773 AM, +05:30
04.08.2021 11:38:01

en-US
True
TITLE
8/4/2021 11:38:01 AM
8/4/2021 11:38:01 AM
Wednesday, August 04, 2021, 11:38:01.773 AM, +05:30
Wednesday, August 04, 2021, 11:38:01.773 AM, +05:30
8/4/2021 11:38:01 AM
*/