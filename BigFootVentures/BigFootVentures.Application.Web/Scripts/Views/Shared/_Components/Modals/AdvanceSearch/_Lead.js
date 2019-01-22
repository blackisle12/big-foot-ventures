function BuildLeadQuery(query) {
    var status = $('[name="Select.Filter.Lead.Status"]').val();
    var firstName = $('[name="Input.Filter.Lead.FirstName"]').val();
    var middleName = $('[name="Input.Filter.Lead.MiddleName"]').val();
    var lastName = $('[name="Input.Filter.Lead.LastName"]').val();
    var company = $('[name="Input.Filter.Lead.Company"]').val();
    var email = $('[name="Input.Filter.Lead.Email"]').val();
    var phone = $('[name="Input.Filter.Lead.Phone"]').val();
    var industry = $('[name="Select.Filter.Lead.Industry"]').val();
    var source = $('[name="Select.Filter.Lead.Source"]').val();

    if (status != '') {
        query += '&status=' + status;
    }

    if (firstName != null && firstName != undefined && firstName.length > 0) {
        query += '&firstName=' + firstName;
    }

    if (middleName != null && middleName != undefined && middleName.length > 0) {
        query += '&middleName=' + middleName;
    }

    if (lastName != null && lastName != undefined && lastName.length > 0) {
        query += '&lastName=' + lastName;
    }

    if (company != null && company != undefined && company.length > 0) {
        query += '&company=' + company;
    }

    if (email != null && email != undefined && email.length > 0) {
        query += '&email=' + email;
    }

    if (phone != null && phone != undefined && phone.length > 0) {
        query += '&phone=' + phone;
    }

    return query;
}