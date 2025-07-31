using System.ComponentModel;
using System.Reflection;

namespace BlogV3.Application.Extensions
{
    public static class EnumExtensions
    {
        #region Public Methods

        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        #endregion Public Methods
    }
}