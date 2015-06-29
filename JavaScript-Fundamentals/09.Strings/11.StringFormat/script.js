

function stringFormat(){
    var i,
        len = arguments.length;
        placeHolderValues = [],
        text = arguments[0];

    for(i = 1; i < len; i += 1){
        placeHolderValues.push(arguments[i]);
    }

    var placeHolders = text.match(/{[0-9]{1,2}}/g);
    var placeHolderNumbers = placeHolders.join('').match(/[0-9]/g);

    for(i = 0; i < placeHolders.length; i += 1){
        text = text.replace(placeHolders[i], placeHolderValues[placeHolderNumbers[i]]);
    }

    return text;

}

var str1 = stringFormat('Hello {0}!', 'Peter');
console.log(str1);

var frmt = '{0}, {1}, {0} text {2}';
var str2 = stringFormat(frmt, 1, 'Pesho', 'Gosho');
console.log(str2);



