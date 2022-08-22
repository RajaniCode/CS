// #region Copyright
// /* 
// ============================================================
// PatternsExamples - SimpleFactory.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using PatternsExamples.A_Creational.D_AbstractFactory;

namespace PatternsExamples.A_Creational.B_SimpleFactory
{
    public static class PizzaFactory
    {
        public static IPizza CreatePizza(PizzaType type)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new CheesePizza();
                case PizzaType.Sausage:
                    return new SausagePizza();
                case PizzaType.Pepperoni:
                    return new PepperoniPizza();
                default:
                    return null;
            }
        }

        public static IPizza CreateLocalizedPizza(PizzaType type, IIngredientFactory ingredients)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new CheesePizza(ingredients);
                case PizzaType.Sausage:
                    return new SausagePizza(ingredients);
                case PizzaType.Pepperoni:
                    return new PepperoniPizza(ingredients);
                default:
                    return null;
            }
        }
    }
}
