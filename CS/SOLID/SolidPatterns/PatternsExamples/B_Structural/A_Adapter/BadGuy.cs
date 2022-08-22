// #region Copyright
// /* 
// ============================================================
// PatternsExamples - BadGuy.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.B_Structural.A_Adapter
{
    public class BadGuy : IBadGuy
    {
        public int Drive() => 30;

	    public int Shoot() => 50;
    }
}
