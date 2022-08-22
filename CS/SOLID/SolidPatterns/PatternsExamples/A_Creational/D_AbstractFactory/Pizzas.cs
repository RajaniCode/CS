// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Pizzas.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

using System.Collections.Generic;

namespace PatternsExamples.A_Creational.D_AbstractFactory
{
	 public enum PizzaType
	 {
		  Cheese,
		  Pepperoni,
		  Sausage,
		  UnKnown
	 }

	 public interface IPizza
	 {
		  IList<string> Toppings { get; }
		  DoughType Dough { get; set; }
		  string Seasonings { get; }
		  string SauceType { get; }
		  void Bake();

		  void Cut();

		  void Box();
	 }

	 public abstract class Pizza : IPizza
	 {
		  public IList<string> Toppings { get; }
		  public DoughType Dough { get; set; }
		  public string Seasonings { get; }
		  public string SauceType { get; }
		  public virtual void Bake()
		  {
		  }

		  public virtual void Cut()
		  {
		  }

		  public virtual void Box()
		  {
		  }

		  protected Pizza()
		  {
				Toppings = new List<string>
				{
					 "Sauce",
					 "Crust"
				};
		  }

		  protected Pizza(IIngredientFactory ingredientFactory) : this()
		  {
				if (ingredientFactory != null)
				{
					 Dough = ingredientFactory.GetCrust();
					 Seasonings = ingredientFactory.GetSeasonings();
					 SauceType = ingredientFactory.GetSauceType();
				}
		  }
	 }

	 public class CheesePizza : Pizza
	 {
		  public CheesePizza()
		  {
				Toppings.Add(PizzaType.Cheese.ToString());
		  }

		  public CheesePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
		  {
				Toppings.Add(PizzaType.Cheese.ToString());
		  }
	 }

	 public class SausagePizza : CheesePizza
	 {
		  public SausagePizza()
		  {
				Toppings.Add(PizzaType.Sausage.ToString());
		  }

		  public SausagePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
		  {
				Toppings.Add(PizzaType.Sausage.ToString());
		  }
	 }

	 public class PepperoniPizza : CheesePizza
	 {
		  public PepperoniPizza()
		  {
				Toppings.Add(PizzaType.Pepperoni.ToString());
		  }

		  public PepperoniPizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
		  {
				Toppings.Add(PizzaType.Pepperoni.ToString());
		  }
	 }
}