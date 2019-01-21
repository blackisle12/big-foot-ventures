function BuildCompanyQuery(query) {
    var name = $('[name="Input.Filter.Company.Name"]').val();
    var accountRecordType = $('[name="Select.Filter.Company.AccountRecordType"]').val();
    var formerName = $('[name="Input.Filter.Company.FormerName"]').val();
    var type = $('[name="Select.Filter.Company.Type"]').val();
    var parentAccount = $('[name="Input.Filter.Company.ParentAccount"]').val();
    var phone = $('[name="Input.Filter.Company.Phone"]').val();
    var fax = $('[name="Input.Filter.Company.Fax"]').val();
    var email = $('[name="Input.Filter.Company.Email"]').val();
    var companySize = $('[name="Select.Filter.Company.CompanySize"]').val();
    var industry = $('[name="Select.Filter.Company.Industry"]').val();
    var nameID = $('[name="Input.Filter.Company.Employees"]').val();
    var employees = $('[name="Input.Filter.Company.NameID"]').val();
    var officeIDGB = $('[name="Input.Filter.Company.OfficeIDGB"]').val();
    var OHIMNumOppositions = $('[name="Input.Filter.Company.OHIMNumOppositions"]').val();
    var escrowAgent = $('[name="Select.Filter.Company.EscrowAgent"]').val();
    var broker = $('[name="Select.Filter.Company.Broker"]').val();
    var companyRegistrationNumber = $('[name="Input.Filter.Company.CompanyRegistrationNumber"]').val();
    var countryOfIncorporation = $('[name="Select.Filter.Company.CountryOfIncorporation"]').val();
    var officers = $('[name="Input.Filter.Company.Officers"]').val();
    var taxNumber = $('[name="Input.Filter.Company.TaxNumber"]').val();
    var bigFootAccredited = $('[name="Select.Filter.Company.BigFootAccredited"]').val();
    var shippingCountry = $('[name="Select.Filter.Company.ShippingCountry"]').val();

    if (name != null && name != undefined && name.length > 0) {
        query += '&name=' + name;
    }

    if (accountRecordType != '') {
        query += '&accountRecordType=' + accountRecordType;
    }

    if (formerName != null && formerName != undefined && formerName.length > 0) {
        query += '&formerName=' + formerName;
    }

    if (type != '') {
        query += '&type=' + type;
    }

    if (parentAccount != null && parentAccount != undefined && parentAccount.length > 0) {
        query += '&parentAccount=' + parentAccount;
    }

    if (phone != null && phone != undefined && phone.length > 0) {
        query += '&phone=' + phone;
    }

    if (fax != null && fax != undefined && fax.length > 0) {
        query += '&fax=' + fax;
    }

    if (email != null && email != undefined && email.length > 0) {
        query += '&email=' + email;
    }

    if (companySize != '') {
        query += '&companySize=' + companySize;
    }

    if (industry != '') {
        query += '&industry=' + industry;
    }

    if (nameID != null && nameID != undefined && nameID.length > 0) {
        query += '&nameID=' + nameID;
    }

    if (employees != null && employees != undefined && employees.length > 0) {
        query += '&employees=' + employees;
    }

    if (officeIDGB != null && officeIDGB != undefined && officeIDGB.length > 0) {
        query += '&officeIDGB=' + officeIDGB;
    }

    if (OHIMNumOppositions != null && OHIMNumOppositions != undefined && OHIMNumOppositions.length > 0) {
        query += '&OHIMNumOppositions=' + OHIMNumOppositions;
    }

    if (escrowAgent != 'NotSet') {
        query += '&escrowAgent=' + escrowAgent;
    }

    if (broker != 'NotSet') {
        query += '&broker=' + broker;
    }

    if (companyRegistrationNumber != null && companyRegistrationNumber != undefined && companyRegistrationNumber.length > 0) {
        query += '&companyRegistrationNumber=' + companyRegistrationNumber;
    }

    if (countryOfIncorporation != '') {
        query += '&countryOfIncorporation=' + countryOfIncorporation;
    }

    if (officers != null && officers != undefined && officers.length > 0) {
        query += '&officers=' + officers;
    }

    if (taxNumber != null && taxNumber != undefined && taxNumber.length > 0) {
        query += '&taxNumber=' + taxNumber;
    }

    if (bigFootAccredited != 'NotSet') {
        query += '&bigFootAccredited=' + bigFootAccredited;
    }

    if (shippingCountry != '') {
        query += '&shippingCountry=' + shippingCountry;
    }

    return query;
}