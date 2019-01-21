function BuildDomainQuery(query) {
    var name = $('[name="Input.Filter.Domain.Name"]').val();
    var bigFootOwned = $('[name="Select.Filter.Domain.BigFootOwned"]').val();
    var websiteCurrent = $('[name="Select.Filter.Domain.WebsiteCurrent"]').val();
    var locked = $('[name="Select.Filter.Domain.Locked"]').val();
    var websiteUse = $('[name="Select.Filter.Domain.WebsiteUse"]').val();
    var BFStrategy = $('[name="Select.Filter.Domain.BFStrategy"]').val();
    var buysideFunnel = $('[name="Select.Filter.Domain.BuysideFunnel"]').val();
    var FMVOrderOfMagnitude = $('[name="Select.Filter.Domain.FMVOrderOfMagnitude"]').val();
    var companyWebsite = $('[name="Select.Filter.Domain.CompanyWebsite"]').val();
    var status = $('[name="Select.Filter.Domain.Status"]').val();
    var autoRenew = $('[name="Select.Filter.Domain.AutoRenew"]').val();
    var version = $('[name="Input.Filter.Domain.Version"]').val();
    var WHOIS = $('[name="Input.Filter.Domain.WHOIS"]').val();
    var category = $('[name="Input.Filter.Domain.Category"]').val();

    if (name != null && name != undefined && name.length > 0) {
        query += '&name=' + name;
    }

    if (bigFootOwned != 'NotSet') {
        query += '&bigFootOwned=' + bigFootOwned;
    }

    if (websiteCurrent != 'NotSet') {
        query += '&websiteCurrent=' + websiteCurrent;
    }

    if (locked != 'NotSet') {
        query += '&locked=' + locked;
    }

    if (websiteUse != '') {
        query += '&websiteUse=' + websiteUse;
    }

    if (BFStrategy != '') {
        query += '&BFStrategy=' + BFStrategy;
    }

    if (buysideFunnel != '') {
        query += '&buysideFunnel=' + buysideFunnel;
    }

    if (FMVOrderOfMagnitude != '') {
        query += '&FMVOrderOfMagnitude=' + FMVOrderOfMagnitude;
    }

    if (companyWebsite != 'NotSet') {
        query += '&companyWebsite=' + companyWebsite;
    }

    if (status != '') {
        query += '&status=' + status;
    }

    if (autoRenew != 'NotSet') {
        query += '&autoRenew=' + autoRenew;
    }

    if (version != null && version != undefined && version.length > 0) {
        query += '&version=' + version;
    }

    if (WHOIS != null && WHOIS != undefined && WHOIS.length > 0) {
        query += '&WHOIS=' + WHOIS;
    }

    if (category != null && category != undefined && category.length > 0) {
        query += '&category=' + category;
    }

    return query;
}