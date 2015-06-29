
function subStringInText(text, subString){
    var indexOfSubString = text.indexOf(subString),
        counter = 0;

    text = text.toLowerCase();
    subString = subString.toLowerCase();

    while(indexOfSubString !== -1){

        counter += 1;
        indexOfSubString = text.indexOf(subString, indexOfSubString + 1);
    }

    return counter;

}


var str = "We are living in an yellow submarine. " +
          "We don't have anything else. inside the submarine is very tight. " +
          "So we are drinking all the day. We will move out of it In 5 days.";

var subString = 'in';


console.log('The text is:');
console.log(str);
console.log('The word: ' + subString + ' is contained ' + subStringInText(str, subString) + ' times');