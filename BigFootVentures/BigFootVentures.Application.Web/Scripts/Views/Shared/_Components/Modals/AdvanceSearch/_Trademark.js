function BuildTrademarkQuery(query) {
    var name = $('[name="Input.Filter.Trademark.Name"]').val();
    var office = $('[name="Input.Filter.Trademark.Office"]').val();
    var officeStatus = $('[name="Select.Filter.Trademark.OfficeStatus"]').val();

    var trademarkNumber = $('[name="Input.Filter.Trademark.TrademarkNumber"]').val();
    var TMURL = $('[name="Input.Filter.Trademark.TMURL"]').val();
    var figurative = $('[name="Select.Filter.Trademark.Figurative"]').val();
    var brand = $('[name="Input.Filter.Trademark.Brand"]').val();
    var figurativeURL = $('[name="Input.Filter.Trademark.FigurativeURL"]').val();
    var originalOffice = $('[name="Input.Filter.Trademark.OriginalOffice"]').val();
    var languageFiling = $('[name="Select.Filter.Trademark.LanguageFiling"]').val();
    var languageSecond = $('[name="Select.Filter.Trademark.LanguageSecond"]').val();
    var geography = $('[name="Select.Filter.Trademark.Geography"]').val();
    var involvedInRevocation = $('[name="Select.Filter.Trademark.InvolvedInRevocation"]').val();
    var bigFootGroupOwned = $('[name="Select.Filter.Trademark.BigFootGroupOwned"]').val();
    var seniorityUsed = $('[name="Select.Filter.Trademark.SeniorityUsed"]').val();
    var revocationTarget = $('[name="Select.Filter.Trademark.RevocationTarget"]').val();

    var openSimilarityResearchTask = $('[name="Select.Filter.Trademark.OpenSimilarityResearchTask"]').val();
    var oppositionResearch = $('[name="Select.Filter.Trademark.OppositionResearch"]').val();

    var researcherName = $('[name="Input.Filter.Trademark.ResearcherName"]').val();
    var markUse = $('[name="Select.Filter.Trademark.MarkUse"]').val();
    var TMWebsite = $('[name="Input.Filter.Trademark.TMWebsite"]').val();
    var competingMarks = $('[name="Select.Filter.Trademark.CompetingMarks"]').val();
    var ownerWebsite = $('[name="Input.Filter.Trademark.ownerWebsite"]').val();
    var cancellationStrategy = $('[name="Select.Filter.Trademark.CancellationStrategy"]').val();
    var comWebsite = $('[name="Input.Filter.Trademark.ComWebsite"]').val();
    var ownerDefense = $('[name="Select.Filter.Trademark.OwnerDefense"]').val();

    var BFStrategy = $('[name="Select.Filter.Trademark.BFStrategy"]').val();
    var nameValue = $('[name="Select.Filter.Trademark.NameValue"]').val();

    var invalidityNumber = $('[name="Input.Filter.Trademark.InvalidityNumber"]').val();
    var invalidityApplicant = $('[name="Input.Filter.Trademark.InvalidityApplicant"]').val();
    var invalidityActionOutcome = $('[name="Select.Filter.Trademark.InvalidityActionOutcome"]').val();

    var letterReference = $('[name="Input.Filter.Trademark.LetterReference"]').val();
    var letterOrigin = $('[name="Select.Filter.Trademark.LetterOrigin"]').val();
    var letterSendingMethod = $('[name="Select.Filter.Trademark.LetterSendingMethod"]').val();
    var letterOutcome = $('[name="Select.Filter.Trademark.LetterOutcome"]').val();

    if (name != null && name != undefined && name.length > 0)
        query += '&name=' + name;
    if (office != null && office != undefined && office.length > 0)
        query += '&office=' + office;
    if (officeStatus != '')
        query += '&officeStatus=' + officeStatus;

    if (trademarkNumber != null && trademarkNumber != undefined && trademarkNumber.length > 0)
        query += '&trademarkNumber=' + trademarkNumber;
    if (TMURL != null && TMURL != undefined && TMURL.length > 0)
        query += '&TMURL=' + TMURL;
    if (figurative != 'NotSet')
        query += '&figurative=' + figurative;
    if (brand != null && brand != undefined && brand.length > 0)
        query += '&brand=' + brand;
    if (figurativeURL != null && figurativeURL != undefined && figurativeURL.length > 0)
        query += '&figurativeURL=' + figurativeURL;
    if (originalOffice != null && originalOffice != undefined && originalOffice.length > 0)
        query += '&originalOffice=' + originalOffice;
    if (languageFiling != '')
        query += '&languageFiling=' + languageFiling;
    if (languageSecond != '')
        query += '&languageSecond=' + languageSecond;
    if (geography != '')
        query += '&geography=' + geography;
    if (involvedInRevocation != 'NotSet')
        query += '&involvedInRevocation=' + involvedInRevocation;
    if (bigFootGroupOwned != '')
        query += '&bigFootGroupOwned=' + bigFootGroupOwned;
    if (seniorityUsed != 'NotSet')
        query += '&seniorityUsed=' + seniorityUsed;
    if (revocationTarget != 'NotSet')
        query += '&revocationTarget=' + revocationTarget;

    if (openSimilarityResearchTask != '')
        query += '&openSimilarityResearchTask=' + openSimilarityResearchTask;
    if (oppositionResearch != '')
        query += '&oppositionResearch=' + oppositionResearch;

    if (researcherName != null && researcherName != undefined && researcherName.length > 0)
        query += '&researcherName=' + researcherName;
    if (markUse != '')
        query += '&markUse=' + markUse;
    if (TMWebsite != null && TMWebsite != undefined && TMWebsite.length > 0)
        query += '&TMWebsite=' + TMWebsite;
    if (competingMarks != 'NotSet')
        query += '&competingMarks=' + competingMarks;
    if (ownerWebsite != null && ownerWebsite != undefined && ownerWebsite.length > 0)
        query += '&ownerWebsite=' + ownerWebsite;
    if (cancellationStrategy != '')
        query += '&cancellationStrategy=' + cancellationStrategy;
    if (comWebsite != null && comWebsite != undefined && comWebsite.length > 0)
        query += '&comWebsite=' + comWebsite;
    if (ownerDefense != '')
        query += '&ownerDefense=' + ownerDefense;

    if (BFStrategy != '')
        query += '&BFStrategy=' + BFStrategy;
    if (nameValue != '')
        query += '&nameValue=' + nameValue;

    if (invalidityNumber != null && invalidityNumber != undefined && invalidityNumber.length > 0)
        query += '&invalidityNumber=' + invalidityNumber;
    if (invalidityApplicant != null && invalidityApplicant != undefined && invalidityApplicant.length > 0)
        query += '&invalidityApplicant=' + invalidityApplicant;
    if (invalidityActionOutcome != '')
        query += '&invalidityActionOutcome=' + invalidityActionOutcome;

    if (letterReference != null && letterReference != undefined && letterReference.length > 0)
        query += '&letterReference=' + letterReference;
    if (letterOrigin != '')
        query += '&letterOrigin=' + letterOrigin;
    if (letterSendingMethod != '')
        query += '&letterSendingMethod=' + letterSendingMethod;
    if (letterOutcome != '')
        query += '&letterOutcome=' + letterOutcome;

    return query;
}