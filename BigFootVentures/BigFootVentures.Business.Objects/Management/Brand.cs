using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Brand : BusinessBase
    {
        #region "Private Members"

        private string _category;
        private string _hvt;
        private string _deletionRequest;

        #endregion

        #region "Properties"
        
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Value { get; set; }
        public string HVT { get { return this._hvt; } set { this._hvt = value; this.HVTChk = string.Equals(value, true.ToString(), StringComparison.InvariantCultureIgnoreCase); } }
        public string EMV { get; set; }

        public string DeletionRequest { get { return this._deletionRequest; } set { this._deletionRequest = value; this.DeletionRequestChk = string.Equals(value, true.ToString(), StringComparison.InvariantCultureIgnoreCase); } }
        public string DeletionRequestReason { get; set; }

        public string Category { get { return this._category; } set { this._category = value; if (!string.IsNullOrWhiteSpace(value)) { this.Categories = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
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
    }
}
