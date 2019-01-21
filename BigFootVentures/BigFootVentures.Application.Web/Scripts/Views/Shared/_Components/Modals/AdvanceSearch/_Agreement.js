function BuildAgreementQuery(query) {
    var name = $('[name="Select.Filter.Agreement.Name"]').val();
    var BFCompany = $('[name="Select.Filter.Agreement.BFCompany"]').val();
    var counterpart = $('[name="Select.Filter.Agreement.Counterpart"]').val();
    var objectOfAgreement = $('[name="Select.Filter.Agreement.ObjectOfAgreement"]').val();
    var type = $('[name="Select.Filter.Agreement.Type"]').val();

    if (name != null && name != undefined && name.length > 0) {
        query += '&name=' + name;
    }

    if (BFCompany != null && BFCompany != undefined && BFCompany.length > 0) {
        query += '&BFCompany=' + BFCompany;
    }

    if (counterpart != null && counterpart != undefined && counterpart.length > 0) {
        query += '&counterpart=' + counterpart;
    }

    if (objectOfAgreement != '') {
        query += '&objectOfAgreement=' + objectOfAgreement;
    }

    if (type != '') {
        query += '&type=' + type;
    }

    return query;
}