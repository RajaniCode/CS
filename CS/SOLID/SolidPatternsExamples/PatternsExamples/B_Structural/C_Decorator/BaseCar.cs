// #region Copyright
// /* 
// ============================================================
// PatternsExamples - BaseCar.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.B_Structural.C_Decorator
{
    public class BaseCar : ICar
    {
	    public int Drive() => 100;

	    public int Attack() => 100;

	    public int Defend() => 100;
    }
}
