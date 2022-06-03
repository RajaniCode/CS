// Localization // CS // Java

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Localization local = new Localization();
        local.Print();
    }
}

class Localization
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


        // string email = "Tıtle@example.com"; // ı
        // Console.WriteLine(email);
        Console.WriteLine("Please enter your Turkish ı input:"); // ı // Tıtle@Example.Com
        string email = Console.ReadLine();
        Console.WriteLine($"Email: {email}");

        string existingEmail = "title@example.com";
        Console.WriteLine($"Existing Email: {existingEmail}"); ;

        bool compare = email.Equals(existingEmail, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"string Equals StringComparison.OrdinalIgnoreCase: {compare}");

	// Fine for EFCore
	compare = email.Equals(existingEmail);
        Console.WriteLine($"string Equals: {compare}");
	

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
/Users/rajaniapple/Desktop/Mnemonics/Localization/Program.cs(53,24): warning CS8600: Converting null literal or possible null value to non-nullable type. [/Users/rajaniapple/Desktop/Mnemonics/Localization/Localization.csproj]
/Users/rajaniapple/Desktop/Mnemonics/Localization/Program.cs(59,24): warning CS8602: Dereference of a possibly null reference. [/Users/rajaniapple/Desktop/Mnemonics/Localization/Localization.csproj]
Default
Thread.CurrentThread.CurrentCulture.Name: 
DateTime.Now: 05/03/2022 00:46:06

tr-TR
False
TITLE
False
TITLE
Please enter your Turkish ı input:
Tıtle@Example.Com
Email: Tıtle@Example.Com
Existing Email: title@example.com
string Equals StringComparison.OrdinalIgnoreCase: False
string Equals: False
3.05.2022 00:46:09
3.05.2022 00:46:09
Salı, Mayıs 03, 2022, 12:46:09.973 ÖÖ, +05:30
Salı, Mayıs 03, 2022, 12:46:09.981 ÖÖ, +05:30
3.05.2022 00:46:09
₺0,00 ₺1,00 ₺2,00 ₺3,00 ₺4,00 ₺5,00 ₺6,00 ₺7,00 ₺8,00 ₺9,00 
₺0,00, ₺1,00, ₺2,00, ₺3,00, ₺4,00, ₺5,00, ₺6,00, ₺7,00, ₺8,00, ₺9,00
-₺2.147.483.648,00
₺2.147.483.647,00


False
TıTLE
False
TıTLE
Please enter your Turkish ı input:
Tıtle@Example.Com
Email: Tıtle@Example.Com
Existing Email: title@example.com
string Equals StringComparison.OrdinalIgnoreCase: False
string Equals: False
05/03/2022 00:46:11
05/03/2022 00:46:11
Tuesday, May 03, 2022, 12:46:11.300 AM, +05:30
Tuesday, May 03, 2022, 12:46:11.300 AM, +05:30
05/03/2022 00:46:11
¤0.00 ¤1.00 ¤2.00 ¤3.00 ¤4.00 ¤5.00 ¤6.00 ¤7.00 ¤8.00 ¤9.00 
¤0.00, ¤1.00, ¤2.00, ¤3.00, ¤4.00, ¤5.00, ¤6.00, ¤7.00, ¤8.00, ¤9.00
(¤2,147,483,648.00)
¤2,147,483,647.00

az-Latn-AZ
False
TITLE
False
TITLE
Please enter your Turkish ı input:
Tıtle@Example.Com
Email: Tıtle@Example.Com
Existing Email: title@example.com
string Equals StringComparison.OrdinalIgnoreCase: False
string Equals: False
03.05.2022 00:46:12
03.05.2022 00:46:12
çərşənbə axşamı, may 03, 2022, 12:46:12.192 AM, +05:30
çərşənbə axşamı, may 03, 2022, 12:46:12.192 AM, +05:30
03.05.2022 00:46:12
0,00 ₼ 1,00 ₼ 2,00 ₼ 3,00 ₼ 4,00 ₼ 5,00 ₼ 6,00 ₼ 7,00 ₼ 8,00 ₼ 9,00 ₼ 
0,00 ₼, 1,00 ₼, 2,00 ₼, 3,00 ₼, 4,00 ₼, 5,00 ₼, 6,00 ₼, 7,00 ₼, 8,00 ₼, 9,00 ₼
-2.147.483.648,00 ₼
2.147.483.647,00 ₼

en-GB
True
TITLE
True
TITLE
Please enter your Turkish ı input:
Tıtle@Example.Com
Email: Tıtle@Example.Com
Existing Email: title@example.com
string Equals StringComparison.OrdinalIgnoreCase: False
string Equals: False
03/05/2022 00:46:13
03/05/2022 00:46:13
Tuesday, May 03, 2022, 12:46:13.139 am, +05:30
Tuesday, May 03, 2022, 12:46:13.139 am, +05:30
03/05/2022 00:46:13
£0.00 £1.00 £2.00 £3.00 £4.00 £5.00 £6.00 £7.00 £8.00 £9.00 
£0.00, £1.00, £2.00, £3.00, £4.00, £5.00, £6.00, £7.00, £8.00, £9.00
-£2,147,483,648.00
£2,147,483,647.00
*/