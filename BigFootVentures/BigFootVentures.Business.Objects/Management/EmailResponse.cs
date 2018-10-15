namespace BigFootVentures.Business.Objects.Management
{
    public sealed class EmailResponse: BusinessBase
    {
        public string Name { get; set; }
        public string Enquiries { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string MessageDate { get; set; }

    }
}
