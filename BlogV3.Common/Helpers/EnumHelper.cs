using System.ComponentModel;
using System.Reflection;

namespace BlogV3.Common.Helpers
{
    public static class EnumHelper
    {
        #region Public Methods

        public static string? GetDescription(this Enum value)
        {
            return value
                .GetType()
                .GetField(value.ToString())?
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description;
        }

        #endregion Public Methods
    }
}