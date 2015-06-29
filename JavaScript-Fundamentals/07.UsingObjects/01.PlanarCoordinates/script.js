
function Point(x, y){
    return {
        x: x,
        y: y,
        toString: function(){return '[' + this.x + ', ' + this.y + ']';}
    }
}


function Line(p1, p2){
    return{
        p1: p1,
        p2: p2,
        toString: function(){return '[' + this.p1 + ', ' + this.p2 + ']';}
    }
}


function calcDistance(point1, point2){
    var distance = Math.pow(point2.x - point1.x , 2) + Math.pow(point2.y - point1.y, 2);
    return Math.sqrt(distance);
}


function canBeTriangle(a, b, c){

    if ((a + b > c) && (b + c > a) && (a + c > b)){
        return true;
    }

    return false;
}

var point1 = new Point(2, 3),
    point2 = new Point(5, 7),
    point3 = new Point(5, 8),
    point4 = new Point(4, 3),
    point5 = new Point(1, 6),
    point6 = new Point(23, 5);

var line1 = new Line(point1, point2),
    line2 = new Line(point3, point4),
    line3 = new Line(point5, point6);

var length1 = calcDistance(line1.p1, line1.p2);
var length2 = calcDistance(line2.p1, line2.p2);
var length3 = calcDistance(line3.p1, line3.p2);

console.log('The lines are:');
console.log('Line 1: ' + line1.toString());
console.log('Line 2: ' + line2.toString());
console.log('Line 3: ' + line3.toString());

console.log('Can the three lines form a triangle ? : ' + canBeTriangle(length1, length2, length3));
