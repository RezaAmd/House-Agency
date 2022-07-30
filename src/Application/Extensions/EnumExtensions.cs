using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Application.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            Assert.NotNull(value, nameof(value));
            List<string> Messages = new List<string>();

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return Messages[0];

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propValue.ToString();
        }

        public static List<string> ToDisplays(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            Assert.NotNull(value, nameof(value));
            List<string> Messages = new List<string>();

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return Messages;

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            Messages.Add(propValue.ToString());
            return Messages;
        }

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static string ToStringNumber(this Enum value)
        {
            return Convert.ToInt32(value).ToString();
        }
    }

    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}