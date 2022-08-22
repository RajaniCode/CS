// #region Copyright
// /* 
// ============================================================
// PatternsExamples - IHero.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.C_Behavioral.Strategy
{
    public interface IHero
    {
        string DoHeroStuff();

        void ChangeSuperPower(ISuperPower power);
    }
}