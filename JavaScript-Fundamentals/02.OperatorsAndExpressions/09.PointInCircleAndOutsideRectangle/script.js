function inCircle(x, y){
    if(Math.pow(x - 1, 2) + Math.pow(y - 1, 2) <= 9){
        return true;
    }

    else{
        return false;
    }
}

function outRect(x, y){
    var maxX = 5, minX = -1, maxY = 1, minY = -1;

    if((x > maxX || x < minX) || y > maxY || y < minY){
        return true;
    }

    return false;
}

var x1 = 1, y1 = 2;
var x2 = 0, y2 = 1;
var x3 = 2.5, y3 = 1;
var x4 = 2, y4 = 0;
var x5 = 4, y5 = 0;
var x6 = 2, y6 = 1.5;
var x7 = 1, y7 = 2.5;
var x8 = -100, y8 = -100;

console.log(x1 + ' ' + y1 + ' ' + (inCircle(x1, y1) && outRect(x1, y1)));
console.log(x2 + ' ' + y2 + ' ' + (inCircle(x2, y2) && outRect(x2, y2)));
console.log(x3 + ' ' + y3 + ' ' + (inCircle(x3, y3) && outRect(x3, y3)));
console.log(x4 + ' ' + y4 + ' ' + (inCircle(x4, y4) && outRect(x4, y4)));
console.log(x5 + ' ' + y5 + ' ' + (inCircle(x5, y5) && outRect(x5, y5)));
console.log(x6 + ' ' + y6 + ' ' + (inCircle(x6, y6) && outRect(x6, y6)));
console.log(x7 + ' ' + y7 + ' ' + (inCircle(x7, y7) && outRect(x7, y7)));
console.log(x8 + ' ' + y8 + ' ' + (inCircle(x8, y8) && outRect(x8, y8)));

