using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Utility
{
    class Enums
    {
        public enum Suit
        {
            [Description("Here's Spades"), Category("♠")]
            Spades,
            [Description("Here's Hearts"), Category("♥")]
            Hearts,
            [Description("Here's Clubs"), Category("♣")]
            Clubs,
            [Description("Here's Diamonds"), Category("♦")]
            Diamonds
        }
    }

    public static class EnumExtensionMethods
    {
        public static string GetDescriptionAttribute<T>(this T enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        public static string GetCategoryAttribute<T>(this T enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var categoryAttributes = (CategoryAttribute[])fieldInfo.GetCustomAttributes(typeof(CategoryAttribute), false);

            return categoryAttributes.Length > 0 ? categoryAttributes[0].Category : enumValue.ToString();
        }
    }

}
