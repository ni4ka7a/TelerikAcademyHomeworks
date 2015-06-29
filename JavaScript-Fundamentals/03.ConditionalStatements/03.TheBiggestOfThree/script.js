
function biggestNumber(a, b, c){
    if(a > b){

        if(a > c){
            return a;
        }

        else{
            return c;
        }
    }

    else if(b > c){
        return b;
    }

    else{
        return c;
    }
}

var a1 = 5, b1 = 2, c1 = 2;
var a2 = -2, b2 = -2, c2 = 1;
var a3 = -2, b3 = 4, c3 = 3;
var a4 = 0, b4 = -2.5, c4 = 5;
var a5 = -0.1, b5 = -0.5, c5 = -1.1;

console.log('The numbers are: ' + a1 + ' ' + b1 + ' ' + c1 + ' ==> ' + biggestNumber(a1, b1, c1));
console.log('The numbers are: ' + a2 + ' ' + b2 + ' ' + c2 + ' ==> ' + biggestNumber(a2, b2, c2));
console.log('The numbers are: ' + a3 + ' ' + b3 + ' ' + c3 + ' ==> ' + biggestNumber(a3, b3, c3));
console.log('The numbers are: ' + a4 + ' ' + b4 + ' ' + c4 + ' ==> ' + biggestNumber(a4, b4, c4));
console.log('The numbers are: ' + a5 + ' ' + b5 + ' ' + c5 + ' ==> ' + biggestNumber(a5, b5, c5));
