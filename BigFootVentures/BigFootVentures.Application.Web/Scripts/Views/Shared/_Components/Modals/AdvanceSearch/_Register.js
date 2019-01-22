function BuildRegisterQuery(query) {
    var name = $('[name="Input.Filter.Register.Name"]').val();
    var RAAYear = $('[name="Input.Filter.Register.RAAYear"]').val();
    var country = $('[name="Select.Filter.Register.Country"]').val();
    var accreditedTLDs = $('[name="Input.Filter.Register.AccreditedTLDs"]').val();

    if (name != null && name != undefined && name.length > 0) {
        query += '&name=' + name;
    }

    if (RAAYear != null && RAAYear != undefined && RAAYear.length > 0) {
        query += '&RAAYear=' + RAAYear;
    }

    if (country != '') {
        query += '&country=' + country;
    }

    if (accreditedTLDs != null && accreditedTLDs != undefined && accreditedTLDs.length > 0) {
        query += '&accreditedTLDs=' + accreditedTLDs;
    }

    return query;
}