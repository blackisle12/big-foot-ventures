using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class TaskValidator
    {
        #region "Public Methods"

        public static bool IsValid(Task task, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(task.Subject))
            {
                validationResult.Add("Record.Subject", ValidationMessages.REQUIRED);
            }

            if (task.AssignedTo == null || task.AssignedTo.ID == 0)
            {
                validationResult.Add("Record.AssignedToName", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
