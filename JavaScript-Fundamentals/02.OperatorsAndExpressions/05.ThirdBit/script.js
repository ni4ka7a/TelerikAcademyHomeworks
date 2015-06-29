
function chekcThirdBit(number){
    var mask = 1 << 3;
    var result = number & mask;
    return result >> 3;
}

var someNumber = 7, anotherNumber = 10;
console.log('Number ' + someNumber + ': bit at position 3 is ' + chekcThirdBit(someNumber));
console.log('Number ' + anotherNumber + ': bit at position 3 is ' + chekcThirdBit(anotherNumber));