
function reverseString(str){
    return str.split('').reverse().join('');
}


var someStr = 'Hello World';
console.log('This is the original string:');
console.log(someStr);

console.log('This is the reversed string:')
console.log(reverseString(someStr));