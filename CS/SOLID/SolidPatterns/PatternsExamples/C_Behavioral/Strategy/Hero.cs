// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Hero.cs
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
    public class Hero : IHero
    {
        private ISuperPower _power;
        public Hero() : this(new RegularJoe())
        {
        }

        public Hero(ISuperPower power)
        {
            _power = power;
        }

        public string DoHeroStuff() => _power.ExercisePower();

	    public void ChangeSuperPower(ISuperPower power)
        {
            _power = power;
        }
    }

    public class SpiderMan : Hero
    {
        public SpiderMan() : base(new WeaveWeb())
        {
        }
    }

    public class SuperMan : Hero
    {
        public SuperMan() : base(new Fly())
        {
        }
    }

    public class BatMan : Hero
    {
        public BatMan() : base(new Fight())
        {
        }
    }
}
