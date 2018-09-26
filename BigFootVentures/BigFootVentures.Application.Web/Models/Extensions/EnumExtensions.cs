using BigFootVentures.Business.Objects.Utilities;
using System;

namespace BigFootVentures.Application.Web.Models.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum value)
        {
            return EnumUtils.GetDescription(value);
        }
    }
}