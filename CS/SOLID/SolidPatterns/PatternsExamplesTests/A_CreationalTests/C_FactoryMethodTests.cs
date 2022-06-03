// #region Copyright
// /* 
// ============================================================
// PatternsExamplesTests - C_FactoryMethodTests.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using PatternsExamples.A_Creational.C_FactoryMethod;
using PatternsExamples.A_Creational.D_AbstractFactory;
using NUnit.Framework;

namespace PatternsExamplesTests.A_CreationalTests
{
    [TestFixture]
    public class FactoryMethodTests
    {
        [Test]
        public void ShouldReturnThinCrustPizzaFromNYStore()
        {
            var store = new NewYorkPizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Pepperoni);
            Assert.AreEqual(DoughType.Thin, pizza.Dough);
        }

        [Test]
        public void ShouldReturnSausageDefaultPizza()
        {
            var store = new BasePizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Cheese);
            Assert.AreEqual(DoughType.None, pizza.Dough);
        }

        [Test]
        public void ShouldReturnDeepDishPizzaFromChicagoStore()
        {
            var store = new ChicagoPizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Pepperoni);
            Assert.AreEqual(DoughType.DeepDish, pizza.Dough);
        }
    }
}