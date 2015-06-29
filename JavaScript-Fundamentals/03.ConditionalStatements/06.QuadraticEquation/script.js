
function quadraticEquation(a, b, c){

    var disc = (b*b)  - (4 * a * c);

    if(disc < 0)
    {
        console.log('no real roots');
    }

    else {
        var x1 = ((-b) + Math.sqrt(disc)) / (2 * a);
        var x2 = ((-b) - Math.sqrt(disc)) / (2 * a);

        console.log('roots: ' + x1 + ' ' + x2);
    }
}

var a1 =2, b1 = 5, c1 =-3;
var a2 =-1, b2 = 3, c2 =0;
var a3 =-0.5, b3 = 4, c3 =-8;
var a4 =5, b4 = 2, c4 =8;

quadraticEquation(a1, b1, c1);
quadraticEquation(a2, b2, c2);
quadraticEquation(a3, b3, c3);
quadraticEquation(a4, b4, c4);
