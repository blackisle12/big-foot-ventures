function FormatResult(separator, value, replacement) {
    if (value) {
        return value.replace(new RegExp(separator, 'g'), replacement);
    }
    return '';
}