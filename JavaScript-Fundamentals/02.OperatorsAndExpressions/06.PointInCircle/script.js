

function inCircle(x, y){
    if(x*x + y*y <= 25){
        return true;
    }

    else{
        return false;
    }
}


var x1 = 0, y1 = 1;
var x2 = -5, y2 = 0;
var x3 = -4, y3 = -3.5;
var x4 = 0, y4 = 0;
var x5 = 0.2, y5 = -0.8;
var x6 = 0.9, y6 = -4.93;
var x7 = 2, y7 = 2.665;


console.log(x1 + ' ' + y1 + ' ' + inCircle(x1, y1));
console.log(x2 + ' ' + y2 + ' ' + inCircle(x2, y2));
console.log(x3 + ' ' + y3 + ' ' + inCircle(x3, y3));
console.log(x4 + ' ' + y4 + ' ' + inCircle(x4, y4));
console.log(x5 + ' ' + y5 + ' ' + inCircle(x5, y5));
console.log(x6 + ' ' + y6 + ' ' + inCircle(x6, y6));
console.log(x7 + ' ' + y7 + ' ' + inCircle(x7, y7));