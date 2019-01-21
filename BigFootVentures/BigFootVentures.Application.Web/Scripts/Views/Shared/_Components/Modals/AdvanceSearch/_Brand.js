function BuildBrandQuery(query) {
    var name = $('[name="Input.Filter.Brand.Name"]').val();
    var purpose = $('[name="Select.Filter.Brand.Purpose"]').val();
    var value = $('[name="Select.Filter.Brand.Value"]').val();
    var category = $('[name="Select.Filter.Brand.Category"]').val();
    var HVT = $('[name="Select.Filter.Brand.HVT"]').val();

    if (name != null && name != undefined && name.length > 0) {
        query += '&name=' + name;
    }

    if (purpose != '') {
        query += '&purpose=' + purpose;
    }

    if (value != '') {
        query += '&value=' + value;
    }

    if (category != '') {
        query += '&category=' + category;
    }

    if (HVT != 'NotSet') {
        query += '&HVT=' + HVT;
    }

    return query;
}