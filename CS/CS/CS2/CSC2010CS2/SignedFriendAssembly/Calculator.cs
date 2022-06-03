using System.Runtime.CompilerServices;

//Note: For Unsigned Friend Assemblies PublicKey is not requied
[assembly: InternalsVisibleTo("CSC2010CS2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100abb9e04800b33a7c9ee09160350f50bca67fe047171b167e5ab18b9630762da48de8f8f8bd085e8ac614b1506076810d83b2f8e8e0c83afe4dd3e8e8fceb32e8810fa6b050d65ed99e25cf6cec12f1eb032191277b6c86109712cc9273cfedcdccf3b77c31bb41a90c9f9489ccef3cb65992910de711022d8105384227fd438b")]
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
