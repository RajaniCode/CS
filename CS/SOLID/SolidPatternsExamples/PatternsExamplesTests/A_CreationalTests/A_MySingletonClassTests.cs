// #region Copyright
// /* 
// ============================================================
// PatternsExamplesTests - A_MySingletonClassTests.cs
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

namespace PatternsExamplesTests.A_CreationalTests
{
    [TestFixture]
    public class MySingletonClassTests
    {
        [Test]
        public void ShouldReturnSameInstanceWithMultipleCalls()
        {
            MySingletonClass first = MySingletonClass.Instance;
            MySingletonClass second = MySingletonClass.Instance;
            Assert.AreSame(first, second);
            first.SomeValue++;
            Assert.AreEqual(first.SomeValue, second.SomeValue);
            second.SomeValue++;
            Assert.AreEqual(first.SomeValue, second.SomeValue);
            first.Dispose();
            second.Dispose();
        }
    }
}