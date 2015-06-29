
function correctBrackets(expression){
    var openBracketCounter = 0,
        closeBracketCounter = 0,
        openBracket = expression.indexOf('('),
        closeBracket = expression.indexOf(')'),
        isCorrect = true;

    for(var i = 0; i < expression.length; i += 1){
        if(expression[i] === '('){
            openBracketCounter += 1;
        }

        else if(expression[i] === ')'){
            closeBracketCounter += 1;
        }
    }

    if(openBracketCounter !== closeBracketCounter){
        return false;
    }

    while(openBracket !== -1){
        if(openBracket > closeBracket){
            isCorrect = false;
        }

        openBracket = expression.indexOf('(', openBracket + 1);
        closeBracket = expression.indexOf(')', closeBracket + 1);
    }

    return isCorrect;
}


var expression1 = '((a+b))';
var expression2 = '(a+b))';
var expression3 = ')(a+b))';

console.log('The expression is: ' + expression1);
console.log(correctBrackets('The expression is correct ? ' + expression1));
console.log('--------------------------');

console.log('The expression is: ' + expression2);
console.log(correctBrackets('The expression is correct ? ' + expression2));
console.log('--------------------------');

console.log('The expression is: ' + expression3);
console.log(correctBrackets('The expression is correct ? ' + expression3));
console.log('--------------------------');