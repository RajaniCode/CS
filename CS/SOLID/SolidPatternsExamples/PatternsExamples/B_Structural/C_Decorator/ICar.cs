// #region Copyright
// /* 
// ============================================================
// PatternsExamples - ICar.cs
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
    public interface ICar
    {
        int Drive();

        int Attack();

        int Defend();
        //TODO: Add This
        //string CarType { get; set; }
    }
}