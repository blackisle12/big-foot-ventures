function BuildContactQuery(query) {
    var firstName = $('[name="Input.Filter.Contact.FirstName"]').val();
    var middleName = $('[name="Input.Filter.Contact.MiddleName"]').val();
    var lastName = $('[name="Input.Filter.Contact.LastName"]').val();
    var department = $('[name="Input.Filter.Contact.Department"]').val();
    var fax = $('[name="Input.Filter.Contact.Fax"]').val();
    var email = $('[name="Input.Filter.Contact.Email"]').val();
    var phone = $('[name="Input.Filter.Contact.Phone"]').val();
    var mobile = $('[name="Input.Filter.Contact.Mobile"]').val();
    var OHIMOwnerID = $('[name="Input.Filter.Contact.OHIMOwnerID"]').val();
    var OHIMNumTrademarks = $('[name="Input.Filter.Contact.OHIMNumTrademarks"]').val();

    if (firstName != null && firstName != undefined && firstName.length > 0) {
        query += '&firstName=' + firstName;
    }

    if (middleName != null && middleName != undefined && middleName.length > 0) {
        query += '&middleName=' + middleName;
    }

    if (lastName != null && lastName != undefined && lastName.length > 0) {
        query += '&lastName=' + lastName;
    }

    if (department != null && department != undefined && department.length > 0) {
        query += '&department=' + department;
    }

    if (fax != null && fax != undefined && fax.length > 0) {
        query += '&fax=' + fax;
    }

    if (email != null && email != undefined && email.length > 0) {
        query += '&email=' + email;
    }

    if (phone != null && phone != undefined && phone.length > 0) {
        query += '&phone=' + phone;
    }

    if (mobile != null && mobile != undefined && mobile.length > 0) {
        query += '&mobile=' + mobile;
    }

    if (OHIMOwnerID != null && OHIMOwnerID != undefined && OHIMOwnerID.length > 0) {
        query += '&OHIMOwnerID=' + OHIMOwnerID;
    }

    if (OHIMNumTrademarks != null && OHIMNumTrademarks != undefined && OHIMNumTrademarks.length > 0) {
        query += '&OHIMNumTrademarks=' + OHIMNumTrademarks;
    }

    return query;
}