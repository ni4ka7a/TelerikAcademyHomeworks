
function numberAsWord(){
    var initialDigits = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten',
        'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];

    var tenths = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

    var result;

    var number = parseInt(document.getElementById('inputValue').value);

    if(isNaN(number) || number > 999 || number < 0){
        result = 'not a valid number';
    }

    else if(number < 20){
        result = initialDigits[number];
    }

    else if(number < 100){
        result = initialDigits[number%10];
        number = (number / 10) | 0;  // parse the number from float to int
        if(result != 'zero') {
            result = tenths[number - 2] + ' ' + result;
        }
        else{
            result = tenths[(number | 0) - 2];
        }
    }

    else if(number < 1000){
        var lastDigit = (number % 10).toString();
        number = (number / 10) | 0;
        var middleDigit = (number % 10).toString();
        number = (number / 10) | 0;

        result = initialDigits[number] + ' ' + 'hundred';

        if(parseInt(middleDigit + lastDigit) < 20 && parseInt(middleDigit + lastDigit) != 0)
        {
            result += ' and' + ' ' + initialDigits[parseInt(middleDigit + lastDigit)]
        }

        else if(parseInt(middleDigit + lastDigit) != 0){
            result += ' and' + ' ' + tenths[parseInt(middleDigit) - 2];

            if(lastDigit != '0'){
                result += ' ' + initialDigits[parseInt(lastDigit)];
            }
        }

    }

    document.getElementById('digitAsWord').innerHTML = capitalizeFirstLetter(result);
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

