// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Confusing.cs
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
    public class Confusing : IConfusing
    {
        /// <summary>
        /// this is a terrible name for an api
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Execute(int a, int b, int c) => a + b + c;

	    public int Method1() => 0;

	    public int Method2(int x) => x;

	    public int Method2(int x, int y) => x + y;
    }
}