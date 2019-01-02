using BigFootVentures.Business.Objects.Management;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMDashboard
    {
        public VMPageResult<Task> Tasks { get; set; }
    }
}