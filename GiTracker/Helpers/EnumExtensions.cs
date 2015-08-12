using System;
using System.Linq;
using System.Reflection;

namespace GiTracker.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var attribute = enumValue.GetType()
                .GetRuntimeField(enumValue.ToString())
                .GetCustomAttributes(typeof(EnumDescriptionAttribute), false)
                .SingleOrDefault() as EnumDescriptionAttribute;

            return attribute == null ? enumValue.ToString() : attribute.Description;
        }
    }
}