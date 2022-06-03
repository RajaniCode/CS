// #region Copyright
// /* 
// ============================================================
// PatternsExamplesTests - B_CommandTests.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using NUnit.Framework;
using PatternsExamples.C_Behavioral.Commands;

namespace PatternsExamplesTests.C_BehavioralTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void ShouldTurnTheLightOnAndOff()
        {
            var light = new Light();
            var c = new Controller();
            c.DemoCommands[0] = new LightCommand(light);
            Assert.IsFalse(light.LightIsOn);
            c.DemoCommands[0].Execute();
            Assert.IsTrue(light.LightIsOn);
            c.DemoCommands[0].Execute();
            Assert.IsFalse(light.LightIsOn);
        }
    }
}