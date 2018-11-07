using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class PreFilingSimilarityResearchValidator
    {
        #region "Public Methods"

        public static bool IsValid(PreFilingSimilarityResearch preFilingSimilarityResearch, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (preFilingSimilarityResearch.ResearchedBrand == null || string.IsNullOrWhiteSpace(preFilingSimilarityResearch.ResearchedBrand.Name))
            {
                validationResult.Add("Record.ResearchedBrand.Name", ValidationMessages.REQUIRED);
            }

            if (preFilingSimilarityResearch.Office == null || string.IsNullOrWhiteSpace(preFilingSimilarityResearch.Office.OfficeName))
            {
                validationResult.Add("Record.Office.OfficeName", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(preFilingSimilarityResearch.SimilarityLevel))
            {
                validationResult.Add("Record.SimilarityLevel", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
