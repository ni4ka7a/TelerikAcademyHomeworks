
function sortNumbers(a, b, c){
    console.log('The numbers are: ' + a + ' ' + b + ' ' + c + ' =>>')

    if(a > b){

        if(b > c){
            console.log(a, b, c);
        }

        else if(c > a){
            console.log(c, a, b);
        }

        else{
            console.log(a, c, b);
        }
    }

    else if(b > c){

        if(c > a){
            console.log(b, c, a);
        }

        else{
            console.log(b, a, c);
        }
    }

    else if(c > a){
        console.log(c, b, a);
    }

    else{
        console.log(a, b, c);
    }
}

var a1 = 5, b1 = 1, c1 = 2;
var a2 = -2, b2 = -2, c2 = 1;
var a3 = -2, b3 = 4, c3 = 3;
var a4 = 0, b4 = -2.5, c4 = 5;
var a5 = -1.1, b5 = -0.5, c5 = -0.1;
var a6 = 10, b6 = 20, c6 = 30;
var a7 = 1, b7 = 1, c7 = 1;

sortNumbers(a1, b1, c1);
sortNumbers(a2, b2, c2);
sortNumbers(a3, b3, c3);
sortNumbers(a4, b4, c4);
sortNumbers(a5, b5, c5);
sortNumbers(a6, b6, c6);
sortNumbers(a7, b7, c7);
