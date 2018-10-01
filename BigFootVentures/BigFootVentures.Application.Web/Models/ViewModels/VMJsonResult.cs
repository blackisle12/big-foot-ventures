namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMJsonResult
    {
        #region "Properties"

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }

        #endregion
    }
}