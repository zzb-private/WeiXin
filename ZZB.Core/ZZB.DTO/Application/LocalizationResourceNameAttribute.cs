using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZZB.DTO.Application
{
    public class LocalizationResourceNameAttribute : Attribute
    {
        public string Name { get; }

        public LocalizationResourceNameAttribute(string name)
        {
            Name = name;
        }

        public static LocalizationResourceNameAttribute GetOrNull(Type resourceType)
        {
            return resourceType
                .GetCustomAttributes(true)
                .OfType<LocalizationResourceNameAttribute>()
                .FirstOrDefault();
        }

        public static string GetName(Type resourceType)
        {
            return GetOrNull(resourceType)?.Name ?? resourceType.FullName;
        }
    }
}
