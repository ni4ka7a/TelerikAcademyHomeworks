
function extractText(str){
    var i,
        startIndex,
        endIndex,
        tag,
        len = str.length;

    for(i = 0; i < len; i += 1){
        startIndex = str.indexOf('<');
        endIndex = str.indexOf('>');
        tag = str.substring(startIndex, endIndex + 1);
        str = str.replace(tag, '');
    }

    return str;
}


var htmlText = '<html>' +
    '<head>' +
    '<title>Sample site</title>' +
'</head>' +
'<body>' +
'<div>text' +
'<div>more text</div>' +
'and more...' +
'</div>' +
'in body' +
'</body>' +
'</html>';

console.log('The original text is: ');
console.log(htmlText);

console.log('The result is:');
console.log(extractText(htmlText));