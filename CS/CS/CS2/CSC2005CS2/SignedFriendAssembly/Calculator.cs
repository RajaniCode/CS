using System.Runtime.CompilerServices;

//Note: For Unsigned Friend Assemblies PublicKey is not requied
[assembly: InternalsVisibleTo("CSC2005CS2, PublicKey=002400000480000094000000060200000024000052534131000400000100010089ba824a424e605d8e9eae28f9bf171d621e05e9b48c9876c64a5550ffcc557663fed6028a18d362ed7eb68e4835d086a00f1d169ce7b7cbfe551ab10e3d2f37301d94570f2a7d817f2bac40894f84728114f09fe2d9fc5acfbfc3672ff0d0e3ca10f8562357de0384f9a18a78246a5ad8c1e938e73498c6e88265fd120380a2")]
namespace SignedFriend
{
    class Calculator
    {
        internal int Power(int Number, int Exponent)
        {
            int Counter = 0;
            int Result = 1;
            while (Counter++ < Exponent)
            {
                Result *= Number;
            }
            return Result;
        }
    }
}
