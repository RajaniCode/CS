// #region Copyright
// /* 
// ============================================================
// PatternsExamples - BadAPIS.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.B_Structural.B_Facade
{
    public interface IOverdone
    {
        int DoSomething(int x, int y);

        int DoSomethingElse(int x, int y, int z);

        int DoSomethingAgain(int x, int y, int z, int a);
    }
    public interface IConfusing
    {
        int Execute(int a, int b, int c);

        int Method1();

        int Method2(int x);

        int Method2(int x, int y);
    }
}