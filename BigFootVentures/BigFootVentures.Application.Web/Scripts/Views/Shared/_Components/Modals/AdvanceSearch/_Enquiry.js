function BuildEnquiryQuery(query) {
    var caseNumber = $('[name="Input.Filter.Enquiry.CaseNumber"]').val();
    var status = $('[name="Select.Filter.Enquiry.Status"]').val();
    var caseAssign = $('[name="Select.Filter.Enquiry.CaseAssign"]').val();
    var priority = $('[name="Select.Filter.Enquiry.Priority"]').val();
    var subject = $('[name="Input.Filter.Enquiry.Subject"]').val();

    if (caseNumber != null && caseNumber != undefined && caseNumber.length > 0) {
        query += '&caseNumber=' + caseNumber;
    }

    if (status != '') {
        query += '&status=' + status;
    }

    if (caseAssign != '') {
        query += '&caseAssign=' + caseAssign;
    }

    if (priority != '') {
        query += '&priority=' + priority;
    }

    if (subject != null && subject != undefined && subject.length > 0) {
        query += '&subject=' + subject;
    }

    return query;
}