
function checkThirdDigit(number){

    var lastDigit = number % 10;

    while(number > 10){
        number = Math.floor(number/10);
        lastDigit = number % 10;
    }

    if(lastDigit === 7){
        return true;
    }

    else{
        return false;
    }
}

var someNumber =850, anotherNumber = 750;
console.log(checkThirdDigit(someNumber));
console.log(checkThirdDigit(anotherNumber));