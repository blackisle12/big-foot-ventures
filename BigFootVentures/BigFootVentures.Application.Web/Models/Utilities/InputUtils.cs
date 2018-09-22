using BigFootVentures.Application.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class InputUtils
    {
        #region "Public Methods"

        public static MultiSelectList GetMultiSelectList(string[] options)
        {
            var selectListItems = new List<VMSelectListItem>();

            foreach (var option in options)
            {
                selectListItems.Add(new VMSelectListItem { Text = option, Value = option });
            }

            return new MultiSelectList(selectListItems, "Text", "Value");
        }

        #endregion
    }
}