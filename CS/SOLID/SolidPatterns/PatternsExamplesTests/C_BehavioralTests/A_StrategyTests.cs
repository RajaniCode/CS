// #region Copyright
// /* 
// ============================================================
// PatternsExamplesTests - A_StrategyTests.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using PatternsExamples.A_Creational.A_Singleton;
using NUnit.Framework;
using PatternsExamples.C_Behavioral.Strategy;

namespace PatternsExamplesTests.C_BehavioralTests
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void ShouldReturnSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.AreEqual(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            IHero superMan = new SuperMan();
            Assert.AreEqual(new Fly().ExercisePower(), superMan.DoHeroStuff());
            IHero batMan = new BatMan();
            Assert.AreEqual(new Fight().ExercisePower(), batMan.DoHeroStuff());
        }

        [Test]
        public void ShouldReturnChangedSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.AreEqual(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fight());
            Assert.AreEqual(new Fight().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(IOCContainer.Instance.GetSuperPower());
            Assert.AreEqual(new Fly().ExercisePower(), spiderMan.DoHeroStuff());
            //TODO: Add Power Factory
        }
    }
}