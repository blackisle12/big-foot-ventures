using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Brand : BusinessBase
    {
        #region "Private Members"

        private string _category { get; set; }
        private string _hvt { get; set; }
        private string _deletionRequest { get; set; }

        #endregion

        #region "Properties"

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public string Purpose { get; set; }

        public string Value { get; set; }

        public string HVT
        {
            get
            {
                return this._hvt;
            }
            set
            {
                this._hvt = value;
                this.HVTChk = string.Equals(value, true.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
        }
        public string EMV { get; set; }

        public string DeletionRequest
        {
            get
            {
                return this._deletionRequest;
            }
            set
            {
                this._deletionRequest = value;
                this.DeletionRequestChk = string.Equals(value, true.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public string DeletionRequestReason { get; set; }

        public string Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.Categories = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        public string OwnerName { get; set; }

        public string Premium { get; set; }

        public string CharacterCount { get; set; }

        public string BNF { get; set; }

        #endregion

        #region "Calculated Properties"

        public string[] Categories { get; set; }
        public string[] CategoriesAvailable { get; set; }
        public string[] CategoriesSelected { get; set; }

        public bool HVTChk { get; set; }
        public bool DeletionRequestChk { get; set; }

        #endregion

        #region "Picklist"

        public static string[] PickListPurpose()
        {
            return new string[]
            {
                "",
                "Core",
                "Non-Core"
            };
        }

        public static string[] PickListValue()
        {
            return new string[]
            {
                "",
                "Low",
                "Medium",
                "High"
            };
        }

        public static string[] PickListCategory(string[] excludedValues)
        {
            var categories = new string[]
            {
                "Actor Names",
                "Airlines",
                "Animals",
                "Brandbucket",
                "First Names",
                "Last Names",
                "Locations",
                "MG's Request",
                "Misc",
                "Model Names",
                "Movie Titles",
                "Names",
                "Numbers",
                "Sitematrix",
                "Typo"
            };


            return excludedValues == null ?
                categories :
                categories.Where(i => !excludedValues.Contains(i)).ToArray();
        }

        #endregion    
    }
}
