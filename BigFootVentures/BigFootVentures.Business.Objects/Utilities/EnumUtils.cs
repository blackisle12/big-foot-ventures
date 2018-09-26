using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BigFootVentures.Business.Objects.Utilities
{
    public static class EnumUtils
    {
        #region "Public Methods"

        public static ICollection<string> GetDescriptions<TEnum>(string[] excludedValues = null) where TEnum : struct, IConvertible
        {
            var descriptions = new List<string>();


            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                descriptions.Add(EnumUtils.GetDescription((object)value));
            }

            return excludedValues == null ? descriptions : descriptions.Where(i => !excludedValues.Contains(i)).ToList();
        }

        public static string GetDescription(object value)
        {
            var enumValue = (Enum)value;
            var attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault();

            return attribute == null ? value.ToString() : ((DescriptionAttribute)attribute).Description;
        }

        #endregion
    }
}
