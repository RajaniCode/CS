// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Ingredients.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.A_Creational.D_AbstractFactory
{
    public enum DoughType
    {
        None,
        Thin,
        Pan,
        DeepDish
    }

    public interface IIngredientFactory
    {
        string GetSauceType();

        string GetSeasonings();

        DoughType GetCrust();
    }

    public class BaseIngredients : IIngredientFactory
    {
        public virtual string GetSauceType() => "Bland";

	    public virtual string GetSeasonings() => "None";

	    public virtual DoughType GetCrust() => DoughType.None;
    }

    public class NYIngredients : BaseIngredients
    {
        public override string GetSauceType() => "Red";

	    public override string GetSeasonings() => "Spicy";

	    public override DoughType GetCrust() => DoughType.Thin;
    }

    public class ChicagoIngredients : BaseIngredients
    {
        public override string GetSauceType() => "TomatoBasil";

	    public override string GetSeasonings() => "Mild";

	    public override DoughType GetCrust() => DoughType.DeepDish;
    }
}