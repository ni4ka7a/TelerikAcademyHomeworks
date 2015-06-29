// Task 1: JavaScript literals
// Assign all the possible JavaScript literals to different variables.

console.log('Assing all possible literals:')
var intLiteral = 5;
var floatLiteral = 5.1;
var stringLiteral = 'pesho';
var boolLiteral = true;

console.log('Integer:' + intLiteral);
console.log('Floating point:' + floatLiteral);
console.log('String:' + stringLiteral);
console.log('Bool:' + boolLiteral);

// Task 2: Quoted text
// Create a string variable with quoted text in it.
// For example: `'How you doin'?', Joey said'.

console.log('\n' + 'Quoted text:');
var quotedText = "`'How you doin'?', Joey said'";
console.log(quotedText);


// Task 3: Typeof variables
// Try typeof on all variables you created.

console.log('\n' + 'Typeof on all literals:');
console.log(typeof intLiteral);
console.log(typeof floatLiteral);
console.log(typeof stringLiteral);
console.log(typeof boolLiteral);

// Task 4: Typeof null
// Create null, undefined variables and try typeof on them.

var nullLiteral = null;
var undefinedLiteral = undefined;
var nanLiteral = NaN;

console.log('\n' + 'Typeof on null, undefined and Nan:');
console.log(typeof nullLiteral);
console.log(typeof undefinedLiteral);
console.log(nanLiteral);