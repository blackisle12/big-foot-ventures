namespace BigFootVentures.Business.Objects.Management
{
    public sealed class OfficeStatus : BusinessBase
    {
        public string OwnerName { get; set; }
        
        public string Name { get; set; }
        public string StatusDescription { get; set; }
        public string StatusGrouping { get; set; }
        public Office Office { get; set; }
    }
}
