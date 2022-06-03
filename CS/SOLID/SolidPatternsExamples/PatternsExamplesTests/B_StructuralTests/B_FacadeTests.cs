// #region Copyright
// /* 
// ============================================================
// PatternsExamplesTests - B_FacadeTests.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using NUnit.Framework;
using PatternsExamples.A_Creational.A_Singleton;
using PatternsExamples.B_Structural.B_Facade;

namespace PatternsExamplesTests.B_StructuralTests
{
    [TestFixture]
    public class FacadeTests
    {
        [Test]
        public void ShouldExecuteConfusingAPICalls()
        {
            IBetterAPI betterAPI = IOCContainer.Instance.GetFacadeForBadAPI();
            IBetterAPI betterAPIOldStyle = new BetterAPI(new Confusing(), new Overdone("foo"));
            Assert.AreEqual(6, betterAPI.AddThreeNumbers(1, 2, 3));
            Assert.AreEqual(20, betterAPI.AddThenMultiply(4, 5));
            Assert.AreEqual(35, betterAPI.AddThenMultiply(4, 3, 5));
            Assert.AreEqual(45, betterAPI.AddThenMultiply(4, 3, 2, 5));
        }
    }
}