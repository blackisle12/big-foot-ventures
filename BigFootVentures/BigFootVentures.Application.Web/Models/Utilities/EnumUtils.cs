using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class EnumUtils
    {
        #region "Enumerators"

        public static class Models
        {
            public static class Management
            {
                public static class Brand
                {
                    public enum Purpose
                    {
                        [Description("")]
                        NotSet,

                        [Description("Core")]
                        Core,

                        [Description("Non-Core")]
                        NonCore
                    }
                }

                public enum Value
                {
                    [Description("")]
                    NotSet,

                    [Description("Low")]
                    Low,

                    [Description("Medium")]
                    Medium,

                    [Description("High")]
                    High
                }
            }
        }

        public static class ViewModels
        {
            public enum PageMode
            {
                View,
                Edit,
                PersistSuccess,
                PersistError
            }
        }

        #endregion

        #region "Public Methods"

        public static ICollection<string> GetDescriptions<TEnum>() where TEnum : struct, IConvertible
        {
            var descriptions = new List<string>();
            

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {                                
                descriptions.Add(EnumUtils.GetDescription((object)value));
            }

            return descriptions;
        }        

        #endregion

        #region "Private Methods"

        private static string GetDescription(object value)
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

        #region "Custom Bindings"

        public static string ToDescription(this Enum value)
        {
            return EnumUtils.GetDescription(value);
        }

        #endregion
    }
}