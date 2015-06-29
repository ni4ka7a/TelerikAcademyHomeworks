var firstNumber = 35;
var secondNumber = 45;

function isDivisible(number){
    if(number%7 ===0 && number%5 === 0){
        return ' Is Divisible by 7 and 5';
    }

    else{
        return ' Is NOT Divisible by 7 and 5';
    }
}

console.log('The number ' + firstNumber + isDivisible(firstNumber));
console.log('The number ' + secondNumber +isDivisible(secondNumber));