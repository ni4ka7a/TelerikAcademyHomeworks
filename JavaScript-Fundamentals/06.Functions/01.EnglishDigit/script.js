
function digitAsWord(){
    var input = document.getElementById('inputValue');

    var digits = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    var currentDigit, inputDigit = parseInt(input.value);

    switch(inputDigit % 10){
        case 0: currentDigit = digits[0]; break;
        case 1: currentDigit = digits[1]; break;
        case 2: currentDigit = digits[2]; break;
        case 3: currentDigit = digits[3]; break;
        case 4: currentDigit = digits[4]; break;
        case 5: currentDigit = digits[5]; break;
        case 6: currentDigit = digits[6]; break;
        case 7: currentDigit = digits[7]; break;
        case 8: currentDigit = digits[8]; break;
        case 9: currentDigit = digits[9]; break;
        default: currentDigit = 'not a digit';
    }

    document.getElementById('digitAsWord').innerHTML = currentDigit;
}