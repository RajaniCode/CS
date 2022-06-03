// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Moose.cs
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
    public class Moose : IMoose
    {
        public int Run() => 5;

	    public int Charge() => 10;
    }
}