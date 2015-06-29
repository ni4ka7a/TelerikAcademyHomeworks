
function isPrime(number){

    if(number <= 1){
        return false;
    }

    for(var i = 2; i < number; i+=1){

        if(number % i === 0){
            return false;
        }
    }

    return true;
}

var number1 = 1, number2 = 2, number3 = 3, number4 = 4, number5 = 9, number6 = 37, number7 = 97, number8 = -3, number9 = 0;

console.log('The number ' + number1 + ' is prime ? ' + isPrime(number1));
console.log('The number ' + number2 + ' is prime ? ' + isPrime(number2));
console.log('The number ' + number3 + ' is prime ? ' + isPrime(number3));
console.log('The number ' + number4 + ' is prime ? ' + isPrime(number4));
console.log('The number ' + number5 + ' is prime ? ' + isPrime(number5));
console.log('The number ' + number6 + ' is prime ? ' + isPrime(number6));
console.log('The number ' + number7 + ' is prime ? ' + isPrime(number7));
console.log('The number ' + number8 + ' is prime ? ' + isPrime(number8));
console.log('The number ' + number9 + ' is prime ? ' + isPrime(number9));


