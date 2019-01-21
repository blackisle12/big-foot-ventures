function BuildCancellationQuery(query) {
    var referenceInternal = $('[name="Input.Filter.Cancellation.ReferenceInternal"]').val();
    var referenceExternal = $('[name="Input.Filter.Cancellation.ReferenceExternal"]').val();
    var sentOrigin = $('[name="Input.Filter.Cancellation.SentOrigin"]').val();
    var internalCaseNumber = $('[name="Input.Filter.Cancellation.InternalCaseNumber"]').val();
    var submissionMethod = $('[name="Select.Filter.Cancellation.SubmissionMethod"]').val();
    var applicant = $('[name="Input.Filter.Cancellation.Applicant"]').val();
    var trademark = $('[name="Input.Filter.Cancellation.Trademark"]').val();
    var researchPerformance = $('[name="Select.Filter.Cancellation.ResearchPerformance"]').val();
    var status = $('[name="Select.Filter.Cancellation.Status"]').val();
    var acquisitionLetterSentOrigin = $('[name="Select.Filter.Cancellation.AcquisitionLetterSentOrigin"]').val();
    var acquisitionLetterSentMethod = $('[name="Select.Filter.Cancellation.AcquisitionLetterSentMethod"]').val();
    var UDRPStrategy = $('[name="Select.Filter.Cancellation.UDRPStrategy"]').val();
    var ownerResponseAcquisitionLetter = $('[name="Select.Filter.Cancellation.OwnerResponseAcquisitionLetter"]').val();
    var domainEnquiry = $('[name="Select.Filter.Cancellation.DomainEnquiry"]').val();
    var outcome = $('[name="Select.Filter.Cancellation.Outcome"]').val();

    if (referenceInternal != null && referenceInternal != undefined && referenceInternal.length > 0) {
        query += '&referenceInternal=' + referenceInternal;
    }

    if (referenceExternal != null && referenceExternal != undefined && referenceExternal.length > 0) {
        query += '&referenceExternal=' + referenceExternal;
    }

    if (sentOrigin != null && sentOrigin != undefined && sentOrigin.length > 0) {
        query += '&sentOrigin=' + sentOrigin;
    }

    if (internalCaseNumber != null && internalCaseNumber != undefined && internalCaseNumber.length > 0) {
        query += '&internalCaseNumber=' + internalCaseNumber;
    }

    if (submissionMethod != '') {
        query += '&submissionMethod=' + submissionMethod;
    }

    if (applicant != null && applicant != undefined && applicant.length > 0) {
        query += '&applicant=' + applicant;
    }

    if (trademark != null && trademark != undefined && trademark.length > 0) {
        query += '&trademark=' + trademark;
    }

    if (researchPerformance != '') {
        query += '&researchPerformance=' + researchPerformance;
    }

    if (status != '') {
        query += '&status=' + status;
    }

    if (acquisitionLetterSentOrigin != '') {
        query += '&acquisitionLetterSentOrigin=' + acquisitionLetterSentOrigin;
    }

    if (acquisitionLetterSentMethod != '') {
        query += '&acquisitionLetterSentMethod=' + acquisitionLetterSentMethod;
    }

    if (UDRPStrategy != '') {
        query += '&UDRPStrategy=' + UDRPStrategy;
    }

    if (ownerResponseAcquisitionLetter != '') {
        query += '&ownerResponseAcquisitionLetter=' + ownerResponseAcquisitionLetter;
    }

    if (domainEnquiry != 'NotSet') {
        query += '&domainEnquiry=' + domainEnquiry;
    }

    if (outcome != '') {
        query += '&outcome=' + outcome;
    }

    return query;
}