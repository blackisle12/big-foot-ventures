using BigFootVentures.Business.Objects;
using static BigFootVentures.Application.Web.Models.VMEnums;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMModel<TModel> where TModel : BusinessBase
    {
        #region "Properties"

        public TModel Record { get; set; }
        public PageMode PageMode { get; set; }
        public string SuccessMessage { get { return $"<strong>Nicely done!</strong> {typeof(TModel).Name} has been saved successfully."; } }
        public string ErrorMessage { get { return "<strong>Oh no!</strong> An error has occured while processing your request. Please try again later."; } }

        public string Name { get { return typeof(TModel).Name; } }

        #endregion
    }
}