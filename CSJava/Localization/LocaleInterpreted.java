import java.lang.System;
import java.text.Collator;
import java.text.DateFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;
import java.time.LocalDate;
import java.time.LocalTime;
import java.time.ZonedDateTime;
import java.time.ZoneId;
import java.util.Currency;
import java.util.Date; // Deprecated
import java.util.Locale;

class LocaleInterpreted {
    public static void main(String[] args) {
        System.out.printf("Java Version: %s%n%n", System.getProperty("java.version"));

        Result rslt = new Result();
        rslt.print();
    }
}

class Result {

    private void localeSensitive(Locale local) {

	System.out.println(local.toString());
	// Achtung	
	// toUpperCase() is equivalent to toUpperCase(Locale.getDefault()).
	// This method is locale sensitive, and may produce unexpected results if used for strings that are intended to be interpreted locale independently
        // For instance, "title".toUpperCase() in a Turkish locale returns "T\u0130TLE", where '\u0130' is the LATIN CAPITAL LETTER I WITH DOT ABOVE character
        // To obtain correct results for locale insensitive strings, use toUpperCase(Locale.ROOT)
        System.out.println("title".toUpperCase(local));

	Date dt = new Date(); // Deprecated
	System.out.println("Deprecated Date: " + dt);
	DateFormat formatDate = DateFormat.getDateInstance(DateFormat.DEFAULT, local);
        System.out.println("Deprecated Date DateFormat Locale: " + formatDate.format(dt));

	NumberFormat formatNumber = NumberFormat.getInstance(local);
        System.out.println(formatNumber.format(Integer.MIN_VALUE));
        System.out.println(formatNumber.format(Integer.MAX_VALUE));

	formatNumber = NumberFormat.getCompactNumberInstance(local, NumberFormat.Style.SHORT);
	formatNumber.setMaximumFractionDigits(2);
        System.out.println(formatNumber.format(Integer.MIN_VALUE));
	formatNumber = NumberFormat.getCompactNumberInstance(local, NumberFormat.Style.LONG);
	formatNumber.setMaximumFractionDigits(2);
        System.out.println(formatNumber.format(Integer.MAX_VALUE));

	Currency currencyInstance = Currency.getInstance(local);
        System.out.println(currencyInstance.getSymbol());
        System.out.println();

        System.out.println("Please enter your Turkish ı cmd input:"); // ı // cmd only // Tıtle@Example.Com
        String email = System.console().readLine();
        System.out.printf("Email: %s", email);
        System.out.println();

        String existingEmail = "title@example.com";
        System.out.printf("Existing Email: %s", existingEmail);
        System.out.println();

        Boolean compare = email.equalsIgnoreCase(existingEmail);
        System.out.printf("String equalsIgnoreCase(): %b", compare);
        System.out.println();

	// Note that this method does not take locale into account
        // Compares two strings lexicographically, ignoring case differences
        int sign = email.compareToIgnoreCase(existingEmail);  // ı // cmd only // Tıtle@Example.Com // t@example.com
        System.out.printf("String compareToIgnoreCase(): %d", sign);
        System.out.println();
  
        Collator collate = Collator.getInstance(local);
        compare = collate.equals(email, existingEmail); // ı // cmd only // tıtle@example.com
        System.out.printf("collate.compare: %b", compare);
        System.out.println();

        System.out.println();
    }

    public void print() {
	
	System.out.println("Default");
	System.out.println("LocalDate.now(): " + LocalDate.now());
	System.out.println("LocalTime.now(): " + LocalTime.now());
	System.out.println("ZoneId.systemDefault(): " + ZoneId.systemDefault());
	// DateTimeFormatter formatterDateTime = DateTimeFormatter.ofPattern("uuuu/MM/dd HH:mm:ss");
	DateTimeFormatter formatterDateTime = DateTimeFormatter.ofPattern("EEEE, MMMM dd, yyyy, h:mm:ss.A a, z, O");
	// DateTimeFormatter formatterDateTime = DateTimeFormatter.ofLocalizedDateTime(FormatStyle.FULL);

	ZonedDateTime now = ZonedDateTime.now();
	System.out.println("ZonedDateTime.now(): " + formatterDateTime.format(now));
	System.out.println("ZonedDateTime.now().getOffset(): " + now.getOffset());

	// Current date-time with specified time zone
	ZonedDateTime dateTimeZonedEuropeIstanbul = now.withZoneSameInstant(ZoneId.of("Europe/Istanbul"));
	System.out.println("Current Date Time with Specified Time Zone of Europe/Istanbul: " + formatterDateTime.format(dateTimeZonedEuropeIstanbul));

	ZonedDateTime dateTimeZonedEuropeLondon = now.withZoneSameInstant(ZoneId.of("Europe/London"));
	System.out.println("Current Date Time with Specified Time Zone of Europe/London: " + formatterDateTime.format(dateTimeZonedEuropeLondon));  

	ZonedDateTime dateTimeZonedAsiaBaku = now.withZoneSameInstant(ZoneId.of("Asia/Baku"));
	System.out.println("Current Date Time with Specified Time Zone of Asia/Baku: " + formatterDateTime.format(dateTimeZonedAsiaBaku));

	ZonedDateTime dateTimeZonedAmericaLos_Angeles = now.withZoneSameInstant(ZoneId.of("America/Los_Angeles"));
	System.out.println("Current Date Time with Specified Time Zone of America/Los_Angeles: " + formatterDateTime.format(dateTimeZonedAmericaLos_Angeles));  

	// Locale and LocalDate are orthogonal unlike Locale and deprecated Date
	System.out.println("Locale.getDefault(): " + Locale.getDefault());
	Date dt = new Date(); // Deprecated
	System.out.println("Deprecated Date: " + dt);

	System.out.println("Locale.ROOT language, country, and variant are empty strings, and is language/country neutral locale for the locale sensitive operations.");

	System.out.println();

        Locale defaultLocale = Locale.getDefault();

	// Turkish
        Locale turkish = new Locale("tr", "TR");	
        localeSensitive(turkish);

        // Default locale
        localeSensitive(defaultLocale);

        // Azerbaijani
	Locale azerbaijani = new Locale("az", "AZ");
        localeSensitive(azerbaijani);

        // US // "en", "US" // OR // UK // "en", "GB" 
	Locale enU = new Locale("en", "GB");
        localeSensitive(enU );
    }
}

// Output
/*
Java Version: 16

Default
LocalDate.now(): 2021-08-04
LocalTime.now(): 03:19:36.252522
ZoneId.systemDefault(): Asia/Calcutta
ZonedDateTime.now(): 2021/08/04 03:19:36
ZonedDateTime.now().getOffset(): +05:30
Current Date Time with Specified Time Zone of America/Los_Angeles: 2021/08/03 14:49:36
Locale.getDefault(): en_GB
Deprecated Date: Wed Aug 04 03:19:36 IST 2021

tr_TR
T?TLE
TITLE
Deprecated Date: Wed Aug 04 03:19:36 IST 2021
Deprecated Date DateFormat Locale: 4 A?u 2021
Deprecated Date DateFormat Locale.ROOT: 03:19:36

en_GB
TITLE
TITLE
Deprecated Date: Wed Aug 04 03:19:36 IST 2021
Deprecated Date DateFormat Locale: 4 Aug 2021
Deprecated Date DateFormat Locale.ROOT: 03:19:36

az_AZ
T?TLE
TITLE
Deprecated Date: Wed Aug 04 03:19:36 IST 2021
Deprecated Date DateFormat Locale: 4 avq 2021
Deprecated Date DateFormat Locale.ROOT: 03:19:36

en_US
TITLE
TITLE
Deprecated Date: Wed Aug 04 03:19:36 IST 2021
Deprecated Date DateFormat Locale: Aug 4, 2021
Deprecated Date DateFormat Locale.ROOT: 03:19:36
*/