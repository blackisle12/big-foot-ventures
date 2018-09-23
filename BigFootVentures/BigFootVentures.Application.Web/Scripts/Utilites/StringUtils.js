function FormatResult(separator, value, replacement) {
    return value.replace(new RegExp(separator, 'g'), replacement);
}