using System;
using System.Resources;

namespace GiTracker.Helpers
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public EnumDescriptionAttribute(string description, Type resourceType)
        {
            Description = new ResourceManager(resourceType).GetString(description);
        }

        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}