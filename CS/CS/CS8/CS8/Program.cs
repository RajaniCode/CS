// CS 8
/*
1. Readonly members
2. Default interface methods
3. Pattern matching enhancements:
// Switch expressions
// Property patterns
// Tuple patterns
// Positional patterns
4. Using declarations
5. Static local functions
6. Disposable ref structs
7. Nullable reference types
8. Asynchronous streams
9. Indices and ranges
10. Null-coalescing assignment
11. Unmanaged constructed types
12. Stackalloc in nested expressions
13. Enhancement of interpolated verbatim strings
14. Interface with member access specifiers and static members including fields
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CS8
{
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        // public double Distance => Math.Sqrt(X * X + Y * Y);        
        /*
        public override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
        */
        // 1. Readonly members
        public readonly void Print() => Console.WriteLine("1. Readonly members\n");
        // Like most structs, the ToString() method doesn't modify state. 
        // You could indicate that by adding the readonly modifier to the declaration of ToString():
        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
        // The preceding change generates a compiler warning, because ToString accesses the Distance property, which isn't marked readonly:
        // The compiler warns you when it needs to create a defensive copy. 
        // The Distance property doesn't change state, so you can fix this warning by adding the readonly modifier to the declaration:
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);
        // Notice that the readonly modifier is necessary on a read-only property. 
        // The compiler doesn't assume get accessors don't modify state; you must declare readonly explicitly. 
        // Auto-implemented properties are an exception; the compiler will treat all auto-implemented getters as readonly, so here there's no need to add the readonly modifier to the X and Y properties.

        // The compiler does enforce the rule that readonly members don't modify state. 
        // The following method won't compile unless you remove the readonly modifier:
        // public readonly void Translate(int xOffset, int yOffset)
        public void Translate(int xOffset, int yOffset)
        {
            X += xOffset;
            Y += yOffset;
        }
        // This feature lets you specify your design intent so the compiler can enforce it, and make optimizations based on that intent. 
    }

    interface ILogger
    {
        void Info(string message);
        void Error(string message);

        // 2. Default interface methods
        void Warn(string message)
        {
            Debug.WriteLine(message);
        }
    }

    class DefaultInterfaceMethods : ILogger
    {
        public void Info(string message)
        {
            Debug.WriteLine(message);
        }

        public void Error(string message)
        {
            Debug.WriteLine(message);
        }

        public void Print()
        {
            Console.WriteLine("2. Default interface methods\n");
            ILogger logger = new DefaultInterfaceMethods();
            logger.Warn("This is warning from default interface method");
        }
    }

    enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    class RGBColor
    {
        public int R;
        public int G;
        public int B;

        public RGBColor(int R, int G, int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }

    class Patterns
    {
        // 3. Pattern matching enhancements:
        // Switch expressions
        // If your application defined an RGBColor type that is constructed from the R, G and B components, you could convert a Rainbow value to its RGB values using the following method containing a switch expression:
        private RGBColor FromRainbow(Rainbow colorBand) =>
        colorBand switch
        {
            Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
            Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
            Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
            Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
            Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
            Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
            Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };

        // There are several syntax improvements here:
        // The variable comes before the switch keyword. The different order makes it visually easy to distinguish the switch expression from the switch statement.
        // The case and : elements are replaced with =>. It's more concise and intuitive.
        // The default case is replaced with a _ discard.
        // The bodies are expressions, not statements.
        // Contrast that with the equivalent code using the classic switch statement:
        private RGBColor FromRainbowClassic(Rainbow colorBand)
        {
            switch (colorBand)
            {
                case Rainbow.Red:
                    return new RGBColor(0xFF, 0x00, 0x00);
                case Rainbow.Orange:
                    return new RGBColor(0xFF, 0x7F, 0x00);
                case Rainbow.Yellow:
                    return new RGBColor(0xFF, 0xFF, 0x00);
                case Rainbow.Green:
                    return new RGBColor(0x00, 0xFF, 0x00);
                case Rainbow.Blue:
                    return new RGBColor(0x00, 0x00, 0xFF);
                case Rainbow.Indigo:
                    return new RGBColor(0x4B, 0x00, 0x82);
                case Rainbow.Violet:
                    return new RGBColor(0x94, 0x00, 0xD3);
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
            };
        }

        // 3. Pattern matching enhancements:
        // Property patterns
        private decimal ComputeSalesTax(Address location, decimal salePrice) =>
        location switch
        {
            { State: "WA" } => salePrice * 0.06M,
            { State: "MN" } => salePrice * 0.75M,
            { State: "MI" } => salePrice * 0.05M,
            // other cases removed for brevity...
            _ => 0M
        };

        // 3. Pattern matching enhancements:
        // Tuple patterns
        private string RockPaperScissors(string first, string second) =>
        (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };

        // 3. Pattern matching enhancements:
        // Positional patterns
        private Quadrant GetQuadrant(Point2 point) =>
        point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };

        public void Print()
        {
            Console.WriteLine("3. Pattern matching enhancements: Switch expressions");
            RGBColor rgb = FromRainbow(Rainbow.Red);
            Console.WriteLine("R:{0}, G:{1}, B:{2}", rgb.R, rgb.G, rgb.B);

            Console.WriteLine("3. Pattern matching enhancements: Property patterns");
            Address location = new Address();
            location.State = "WA";
            decimal salesTax = ComputeSalesTax(location, 100);
            Console.WriteLine("Sales Tax = {0}", salesTax);

            Console.WriteLine("3. Pattern matching enhancements: Tuple patterns");
            string message = RockPaperScissors("paper", "rock");
            Console.WriteLine(message);

            Console.WriteLine("3. Pattern matching enhancements: Positional patterns");
            Point2 point = new Point2(-1, -2);
            Quadrant quad = GetQuadrant(point);
            Console.WriteLine("Quadrant:{0}", quad);
            Console.WriteLine();
        }
    }

    class Address
    {
        public string State
        {
            get;
            set;
        }
    }

    class Point2
    {
        public int X { get; }
        public int Y { get; }

        public Point2(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) =>
        (x, y) = (X, Y);
    }


    enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }

    class UsingDeclarations
    {
        public int WriteLinesToFile(IEnumerable<string> lines)
        {
            // 4. Using declarations
            // A using declaration is a variable declaration preceded by the using keyword. It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope. For example, consider the following code that writes a text file:
            Console.WriteLine("4. Using declarations\n");
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            // Notice how we declare skippedLines after the using statement.
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            // Notice how skippedLines is in scope here.
            return skippedLines;
            // file is disposed here
        }

        // In the preceding example, the file is disposed when the closing brace for the method is reached. That's the end of the scope in which file is declared. The preceding code is equivalent to the following code that uses the classic using statement:
        public int WriteLinesToFileClassic(IEnumerable<string> lines)
        {
            // We must declare the variable outside of the using block
            // so that it is in scope to be returned.
            int skippedLines = 0;
            using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                    else
                    {
                        skippedLines++;
                    }
                }
            } // file is disposed here
            return skippedLines;
        }
        // In the preceding example, the file is disposed when the closing brace associated with the using statement is reached.
        // In both cases, the compiler generates the call to Dispose(). 
        // The compiler generates an error if the expression in the using statement isn't disposable.
    }

    // You can now add the static modifier to local functions to ensure that local function doesn't capture (reference) any variables from the enclosing scope. 
    // Doing so generates CS8421, "A static local function can't contain a reference to <variable>."
    // Consider the following code. 
    // The local function LocalFunction accesses the variable y, declared in the enclosing scope (the method M). 
    // Therefore, LocalFunction can't be declared with the static modifier:
    class StaticLocalFunctions
    {
        public int M()
        {
            int y;
            LocalFunction();
            return y;

            void LocalFunction() => y = 0;
        }

        // 5. Static local functions
        // The following code contains a static local function. It can be static because it doesn't access any variables in the enclosing scope:
        public int F()
        {
            int y = 5;
            int x = 7;
            Console.WriteLine("5. Static local functions\n");
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }
    }

    // 6. Disposable ref structs
    // When you compile this program, you would observe a compilation error CS8343: 'Author': ref structs cannot implement interfaces
    // ref struct Author : IDisposable
    // From C# 8 onwards, ref struct can be disposed without the need of implementing the IDisposable interface. 
    // All you need to do is add a public Dispose method to the ref struct. 
    // This would ensure that an instance of thr struct is consumed by using statements as below:
    ref struct Author
    {
        public void Dispose()
        {
            Console.WriteLine("6. Disposable ref structs\n");
        }
    }

    class NullableReferenceTypes
    {
        public void Print()
        {
            // 7. Nullable reference types
            Console.WriteLine("7. Nullable reference types\n");
            /*
            //.csproj
            <PropertyGroup>
                <Nullable>enable</Nullable>
            </PropertyGroup>
            */
#nullable enable
            string strValue1 = null;
#nullable restore
            string strValue2 = null;
        }
    }

    class AsynchronousStreams
    {
        // 8. Asynchronous streams
        // A method that returns an asynchronous stream has three properties:
        // It's declared with the async modifier.
        // It returns an IAsyncEnumerable<T>.
        // The method contains yield return statements to return successive elements in the asynchronous stream.
        private async System.Collections.Generic.IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public async Task AsyncPrint()
        {
            Console.WriteLine("8. Asynchronous streams");
            // Consuming an asynchronous stream requires you to add the await keyword before the foreach keyword when you enumerate the elements of the stream. 
            // Adding the await keyword requires the method that enumerates the asynchronous stream to be declared with the async modifier and to return a type allowed for an async method.
            await foreach (var number in GenerateSequence())
            {
                Console.Write (number + " ");
            }
            Console.WriteLine("\n\n");
        }
    }

    class IndicesAndRanges
    {
        public void Print()
        {
            var alphabet = new string[]
            {
                        // index    // ^index
                "A",	// 0	    // ^26
                "B",	// 1        // ^25
                "C",	// 2        // ^24
                "D",	// 3        // ^23
                "E",	// 4        // ^22
                "F",	// 5        // ^21
                "G",	// 6        // ^20
                "H",	// 7        // ^19
                "I",	// 8        // ^18
                "J",	// 9        // ^17
                "K",	// 10       // ^16
                "L",	// 11       // ^15
                "M",	// 12       // ^14
                "N",	// 13       // ^13
                "O",	// 14       // ^12
                "P",	// 15       // ^11
                "Q",	// 16       // ^10
                "R",	// 17       // ^9
                "S",	// 18       // ^8
                "T",	// 19       // ^7
                "U",	// 20       // ^6
                "V",	// 21       // ^5
                "W",	// 22       // ^4
                "X",	// 23       // ^3
                "Y",	// 24       // ^2
                "Z"     // 25       // ^1
                        // 26 (or alphabet.Length)
            };

            // 9. Indices and ranges
            Console.WriteLine("9. Indices and ranges");

            Console.WriteLine("Array.ForEach:");
            Array.ForEach(alphabet[0..5], x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("ToList().ForEachh:");
            alphabet[0..5].ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("ToList().GetEnumerator():");
            IEnumerator<string> enumerate = alphabet[0..5].ToList().GetEnumerator();
            while (enumerate.MoveNext())
            {
                Console.Write(enumerate.Current);
                Console.Write(" ");
            };
            Console.WriteLine();

            Console.WriteLine($"alphabet[0..5].GetLowerBound(0): {alphabet[0..5].GetLowerBound(0)}");
            Console.WriteLine($"alphabet[0..5].GetUpperBound(0): {alphabet[0..5].GetUpperBound(0)}");

            Console.WriteLine($"The first alphabet: alphabet[0]: {alphabet[0]}");
            Console.WriteLine($"The first alphabet: alphabet[^26]: {alphabet[^26]}");

            Console.WriteLine($"The last alphabet: alphabet[25]: {alphabet[25]}");
            Console.WriteLine($"The last alphabet: alphabet[^1]: {alphabet[^1]}");

            Console.WriteLine($"alphabet[0..5]: {string.Join(", ", alphabet[0..5])}");

            Console.WriteLine($"alphabet[1..4]: {string.Join(", ", alphabet[1..4])}");

            Console.WriteLine($"alphabet[^5..^0]: {string.Join(", ", alphabet[^5..^0])}");

            Console.WriteLine($"alphabet[^4..^1]: {string.Join(", ", alphabet[^4..^1])}");

            Console.WriteLine($"alphabet[5..]: {string.Join(", ", alphabet[5..])}");

            Console.WriteLine($"alphabet[..5]: {string.Join(", ", alphabet[..5])}");

            Console.WriteLine($"alphabet[..]: {string.Join(", ", alphabet[..])}");

            // Range as variable:
            Range rangeDotDot = ..;
            Console.WriteLine($"Range as variable (Range rangeDotDot = ..) in alphabet[rangeDotDot]: {string.Join(", ", alphabet[rangeDotDot])}");

            string alphanumeric = "Indices and ranges";
            Console.WriteLine($"Substring \"and\" in \"9. Indices and ranges\": alphanumeric[^10..^7]: {alphanumeric[^10..^7]}");

            Console.WriteLine($"Substring \"World\" from \"Hello World!\"[^6..^1]: {"Hello World!"[^6..^1]}");
            Console.WriteLine();
        }
    }

    class NullCoalescingAssignment
    {
        public void Print()
        {
            // 10. Null-coalescing assignment
            // C# 8.0 introduces the null-coalescing assignment operator ??=. 
            // You can use the ??= operator to assign the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null.
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            Console.WriteLine("10. Null-coalescing assignment");
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17

            int? j = null;
            numbers.Add(j ??= 27);
            numbers.Add(j ??= 30);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17 27 27
            Console.WriteLine(j);  // output: 27
            Console.WriteLine();
        }
    }

    // 11. Unmanaged constructed types
    // A type is an unmanaged type if it's any of the following types:
    // sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool
    // Any enum type
    // Any pointer type
    // Any user-defined struct type that contains fields of unmanaged types only and, in C# 7.3 and earlier, is not a constructed type (a type that includes at least one type argument)
    // Beginning with C# 7.3, you can use the unmanaged constraint to specify that a type parameter is a non-pointer unmanaged type.
    // Beginning with C# 8.0, a constructed struct type that contains fields of unmanaged types only is also unmanaged, as the following example shows:
    /*
    struct Coords<T>
    {
        public T X;
        public T Y;
    }
    */
    // A generic struct may be the source of both unmanaged and not unmanaged constructed types. 
    // The preceding example defines a generic struct Coords<T> and presents the examples of unmanaged constructed types. 
    // The example of not an unmanaged type is Coords<object>. 
    // It's not unmanaged because it has the fields of the object type, which is not unmanaged. 
    // If you want all constructed types to be unmanaged types, use the unmanaged constraint in the definition of a generic struct:
    struct Coords<T> where T : unmanaged
    {
        public T X;
        public T Y;
    }

    class UnmanagedTypes
    {
        public void Print()
        {
            Console.WriteLine("11. Unmanaged constructed types");
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();
            Console.WriteLine();
        }

        /*
        //.csproj
        <PropertyGroup>
            <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
        </PropertyGroup>
        */
        private unsafe void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
    }

    class StackallocInNestedExpressions
    {
        public void Print()
        {
            // 12. Stackalloc in nested expressions
            // Starting with C# 8.0, if the result of a stackalloc expression is of the System.Span<T> or System.ReadOnlySpan<T> type, you can use the stackalloc expression in other expressions:
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("12. Stackalloc in nested expressions");
            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1 
            Console.WriteLine();
        }
    }

    class EnhancementOfInterpolatedVerbatimStrings
    {
        public void Print()
        {
            // 13. Enhancement of interpolated verbatim strings
            // Order of the $ and @ tokens in interpolated verbatim strings can be any: both $@"..." and @$"..." are valid interpolated verbatim strings. 
            // In earlier C# versions, the $ token must appear before the @ token.
            string name = "Mark";
            var date = DateTime.Now;
            Console.WriteLine("13. Enhancement of interpolated verbatim strings");
            string s = @$"{name} said, ""Today is {date.DayOfWeek}, it's {date:HH:mm} now.""";
            Console.WriteLine(s);
            Console.WriteLine();
        }
    }

    // 14. Interface with member access specifiers and static members including fields
    // Different access modifiers are also enabled
    // The additional fields are private, the new method is public
    // Any of the modifiers are allowed on interface members
    interface IAccessInstancePropertiesMethods
    {
        private string Garply => "Private Instance Property";
        protected string Waldo { get; set; }
        internal string Fred { get; set; }
        protected internal string Plugh { get; set; }
        private protected string Xyzzy { get; set; }
        public string Thud { get; set; }
        string Wibble { get; set; } // default access modifier in interface is public

        private void Wobble() { }
        protected void Wubble() { }
        internal void Flob() { }
        protected internal void Hoge() { }
        private protected void Fuga() { }
        public void Hogera() { }
        void Hogehoge() { } // default access modifier in interface is public
    }

    // 14. Interface with member access specifiers and static members including fields
    // Interfaces can now include static members, including fields, properties, and methods.
    interface IAccessStaticFieldsPropertiesMethods
    {
        private static string Foo = "14. Interface with member access specifiers and static members including fields";
        protected static string Bar = "Bar";
        internal static string Baz = "Baz";
        protected internal static string Qux = "Qux";
        private protected static string Quux = "Quux";
        public static string Corge = "Corge";
        static string Grault => Foo; // default access modifier in interface is public

        private static string Garply { get; set; }
        protected static string Waldo { get; set; }
        internal static string Fred { get; set; }
        protected static internal string Plugh { get; set; }
        private static protected string Xyzzy { get; set; }
        public static string Thud { get; set; }
        static string Wibble { get; set; } // default access modifier in interface is public

        private static void Wobble() { }
        protected static void Wubble() { }
        internal static void Flob() { }
        protected static internal void Hoge() { }
        private static protected void Fuga() { }
        public static void Hogera() { }
        static void Hogehoge() { } // default access modifier in interface is public
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

           Point pnt = new Point();
            pnt.Print();

            DefaultInterfaceMethods defaultInterfaceMethod = new DefaultInterfaceMethods();
            defaultInterfaceMethod.Print();

            Patterns pattern = new Patterns();
            pattern.Print();

            UsingDeclarations usingDeclaration = new UsingDeclarations();
            IEnumerable<string> lines = new string[] { "Apple", "Orange", "Banana" };
            usingDeclaration.WriteLinesToFile(lines);

            StaticLocalFunctions staticLocalFunction = new StaticLocalFunctions();
            staticLocalFunction.F();

            Author athr;
            athr.Dispose();

            NullableReferenceTypes nullableReferenceType = new NullableReferenceTypes();
            nullableReferenceType.Print();

            AsynchronousStreams asyncStreams = new AsynchronousStreams();
            Task asyncTask = asyncStreams.AsyncPrint();
            asyncTask.Wait();

            IndicesAndRanges indicesRanges = new IndicesAndRanges();
            indicesRanges.Print();

            NullCoalescingAssignment nullCoalescingAssign = new NullCoalescingAssignment();
            nullCoalescingAssign.Print();

            UnmanagedTypes unmanagedType = new UnmanagedTypes();
            unmanagedType.Print();

            StackallocInNestedExpressions stackallocInNestedExpress = new StackallocInNestedExpressions();
            stackallocInNestedExpress.Print();

            EnhancementOfInterpolatedVerbatimStrings interpolatedVerbatimStrings = new EnhancementOfInterpolatedVerbatimStrings();
            interpolatedVerbatimStrings.Print();

            Console.WriteLine(IAccessStaticFieldsPropertiesMethods.Grault);
        }
    }
}

// Output
/*
Environment.Version: 3.1.12
RuntimeInformation.FrameworkDescription: .NET Core 3.1.12

1. Readonly members

2. Default interface methods

3. Pattern matching enhancements: Switch expressions
R:255, G:0, B:0
3. Pattern matching enhancements: Property patterns
Sales Tax = 6.00
3. Pattern matching enhancements: Tuple patterns
paper covers rock. Paper wins.
3. Pattern matching enhancements: Positional patterns
Quadrant:Three

4. Using declarations

5. Static local functions

6. Disposable ref structs

7. Nullable reference types

8. Asynchronous streams
0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19


9. Indices and ranges
Array.ForEach:
A B C D E
ToList().ForEachh:
A B C D E
ToList().GetEnumerator():
A B C D E
alphabet[0..5].GetLowerBound(0): 0
alphabet[0..5].GetUpperBound(0): 4
The first alphabet: alphabet[0]: A
The first alphabet: alphabet[^26]: A
The last alphabet: alphabet[25]: Z
The last alphabet: alphabet[^1]: Z
alphabet[0..5]: A, B, C, D, E
alphabet[1..4]: B, C, D
alphabet[^5..^0]: V, W, X, Y, Z
alphabet[^4..^1]: W, X, Y
alphabet[5..]: F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
alphabet[..5]: A, B, C, D, E
alphabet[..]: A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
Range as variable (Range rangeDotDot = ..) in alphabet[rangeDotDot]: A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
Substring "and" in "9. Indices and ranges": alphanumeric[^10..^7]: and
Substring "World" from "Hello World!"[^6..^1]: World

10. Null-coalescing assignment
17 17
17
17 17 27 27
27

11. Unmanaged constructed types
CS8.Coords`1[System.Int32] is unmanaged and its size is 8 bytes
CS8.Coords`1[System.Double] is unmanaged and its size is 16 bytes

12. Stackalloc in nested expressions
1

13. Enhancement of interpolated verbatim strings
Mark said, "Today is Wednesday, it's 17:55 now."

14. Interface with member access specifiers and static members including fields
*/

/*
Courtesy:
https://docs.microsoft.com
*/