using System.ComponentModel.DataAnnotations;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class OfficeStatus : BusinessBase
    {
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        public string StatusDescription { get; set; }
        public string StatusGrouping { get; set; }
    }
}
