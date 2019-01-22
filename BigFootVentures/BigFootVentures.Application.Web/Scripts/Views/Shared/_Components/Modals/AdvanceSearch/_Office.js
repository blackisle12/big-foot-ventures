function BuildOfficeQuery(query) {
    var officeName = $('[name="Input.Filter.Office.OfficeName"]').val();
    var geographyType = $('[name="Select.Filter.Office.GeographyType"]').val();
    var state = $('[name="Input.Filter.Office.State"]').val();
    var office = $('[name="Input.Filter.Office.Office"]').val();
    var officeURL = $('[name="Input.Filter.Office.OfficeURL"]').val();
    var officeValueCategory = $('[name="Select.Filter.Office.OfficeValueCategory"]').val();
    var online = $('[name="Select.Filter.Office.Online"]').val();
    var searchURL = $('[name="Input.Filter.Office.SearchURL"]').val();
    var officeNameArchive = $('[name="Input.Filter.Office.OfficeNameArchive"]').val();
    var nationalNumberAssigned = $('[name="Select.Filter.Office.Online"]').val();
    var PCT = $('[name="Select.Filter.Office.PCT"]').val();
    var paris = $('[name="Select.Filter.Office.Paris"]').val();
    var WTO = $('[name="Select.Filter.Office.WTO"]').val();

    if (officeName != null && officeName != undefined && officeName.length > 0) {
        query += '&officeName=' + officeName;
    }

    if (geographyType != '') {
        query += '&geographyType=' + geographyType;
    }

    if (state != null && state != undefined && state.length > 0) {
        query += '&state=' + state;
    }

    if (office != null && office != undefined && office.length > 0) {
        query += '&office=' + office;
    }

    if (officeURL != null && officeURL != undefined && officeURL.length > 0) {
        query += '&officeURL=' + officeURL;
    }

    if (officeName != null && officeName != undefined && officeName.length > 0) {
        query += '&officeName=' + officeName;
    }

    if (officeValueCategory != '') {
        query += '&officeValueCategory=' + officeValueCategory;
    }

    if (online != 'NotSet') {
        query += '&online=' + online;
    }

    if (searchURL != null && searchURL != undefined && searchURL.length > 0) {
        query += '&searchURL=' + searchURL;
    }

    if (officeNameArchive != null && officeNameArchive != undefined && officeNameArchive.length > 0) {
        query += '&officeNameArchive=' + officeNameArchive;
    }

    if (nationalNumberAssigned != 'NotSet') {
        query += '&nationalNumberAssigned=' + nationalNumberAssigned;
    }

    if (PCT != 'NotSet') {
        query += '&PCT=' + PCT;
    }

    if (paris != 'NotSet') {
        query += '&paris=' + paris;
    }

    if (WTO != 'NotSet') {
        query += '&WTO=' + WTO;
    }

    return query;
}