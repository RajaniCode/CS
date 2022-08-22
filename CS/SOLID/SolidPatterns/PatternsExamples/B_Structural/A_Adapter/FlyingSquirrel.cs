// #region Copyright
// /* 
// ============================================================
// PatternsExamples - FlyingSquirrel.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using PatternsExamples.B_Structural.A_Adapter;

namespace PatternsExamples.B_Structural.A_Adapter
{
    public class FlyingSquirrel : IFlyingSquirrel
    {
        public int Fly() => 20;

	    public int DropAcorns() => 1;
    }
}
