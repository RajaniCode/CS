// #region Copyright
// /* 
// ============================================================
// PatternsExamples - SuperPowers.cs
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
    public interface ISuperPower
    {
        string ExercisePower();
    }

    public class RegularJoe : ISuperPower
    {
        public string ExercisePower() => "Run away";
    }

    public class Fly : ISuperPower
    {
        public string ExercisePower() => "Up, Up, and Away!";
    }

    public class Fight : ISuperPower
    {
        public string ExercisePower() => "KaBaam!";
    }

    public class WeaveWeb : ISuperPower
    {
        public string ExercisePower() => "Catches Thieves Like Flies!";
    }
}