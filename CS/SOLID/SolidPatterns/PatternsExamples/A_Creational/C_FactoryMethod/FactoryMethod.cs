// #region Copyright
// /* 
// ============================================================
// PatternsExamples - FactoryMethod.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

using PatternsExamples.A_Creational.B_SimpleFactory;
using PatternsExamples.A_Creational.D_AbstractFactory;

namespace PatternsExamples.A_Creational.C_FactoryMethod
{
    public interface IPizzaStore
    {
        IPizza OrderLocalizedPizza(PizzaType type);
    }

    public abstract class PizzaStore : IPizzaStore
    {
        protected IIngredientFactory Ingredients;
        protected PizzaStore() : this(new BaseIngredients())
        {
        }

        protected PizzaStore(IIngredientFactory ingredients)
        {
            Ingredients = ingredients;
        }

        public IPizza OrderLocalizedPizza(PizzaType type)
        {
            var pizza = CreateLocalizedPizza(type);
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        //This is the factory "method"
        protected abstract IPizza CreateLocalizedPizza(PizzaType type);
    }

    public class BasePizzaStore : PizzaStore
    {
        public BasePizzaStore() : this(new BaseIngredients())
        {
        }

        public BasePizzaStore(IIngredientFactory ingredients)
        {
            Ingredients = ingredients;
        }

        protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
    }

    public class NewYorkPizzaStore : PizzaStore
    {
        public NewYorkPizzaStore() : this(new NYIngredients())
        {
        }

        public NewYorkPizzaStore(IIngredientFactory ingredientFactory)
        {
            Ingredients = ingredientFactory;
        }

        protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public ChicagoPizzaStore() : this(new ChicagoIngredients())
        {
        }

        public ChicagoPizzaStore(IIngredientFactory ingredients)
        {
            Ingredients = ingredients;
        }

        protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
    }
}