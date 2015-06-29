
function getSign(a, b, c){
    if(a === 0 || b === 0 || c === 0){
        return 0;
    }

    if(a < 0){

        if(b < 0){

            if(c < 0){
                return '-';
            }

            return '+';
        }

        else if(c < 0){
            return '+';
        }

        return '-';
    }

    else if(b < 0){

        if(c < 0){
            return '+';
        }

        return '-';
    }

    else if(c < 0){
        return '-';
    }

    return '+';
}

var a1 = 5, b1 = 2, c1 = 2;
var a2 = -2, b2 = -2, c2 = 1;
var a3 = -2, b3 = 4, c3 = 3;
var a4 = 0, b4 = -2.5, c4 = 4;
var a5 = -1, b5 = -0.5, c5 = -5.1;


console.log('The numbers are: ' + a1 + ' ' + b1 + ' ' + c1 +' The sign is: ' + getSign(a1, b1, c1));
console.log('The numbers are: ' + a2 + ' ' + b2 + ' ' + c2 +' The sign is: ' + getSign(a2, b2, c2));
console.log('The numbers are: ' + a3 + ' ' + b3 + ' ' + c3 +' The sign is: ' + getSign(a3, b3, c3));
console.log('The numbers are: ' + a4 + ' ' + b4 + ' ' + c4 +' The sign is: ' + getSign(a4, b4, c4));
console.log('The numbers are: ' + a5 + ' ' + b5 + ' ' + c5 +' The sign is: ' + getSign(a5, b5, c5));
