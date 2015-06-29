
function replaceTag(str){
    var i,
        url,
        len = str.length;

    for(i = 0; i < len; i += 1){
        //url = str.substring(str.indexOf('<a href='), str.indexOf('</a>'));

        str = str.replace('<a href="', '[URL=');
        str = str.replace('">', ']');
        str = str.replace('</a>', '[/URL]');
    }

    return str;
}


var htmlText = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. ' +
    'Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';


console.log('The original text:');
console.log(htmlText);
console.log('---------------------------------------------------------------');
console.log('The result:');
console.log(replaceTag(htmlText));