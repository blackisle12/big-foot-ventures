namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMAssociation
    {
        #region "Properties"

        public string ParentName { get; set; }

        public string ChildName { get; set; }
        public string ChildNameContainer { get; set; }
        public string ChildIDContainer { get; set; }
        public string ChildProperty { get; set; } = "Name";

        #endregion
    }
}