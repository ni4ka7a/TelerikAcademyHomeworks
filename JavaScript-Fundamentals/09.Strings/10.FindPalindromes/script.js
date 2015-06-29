

function palindromes(str){
    var words = str.split(' ');

    var i,
        j,
        index,
        currentWord,
        isPalindrome,
        result = [],
        len = words.length;

    for(index = 0; index < len; index += 1 ) {
        currentWord = words[index].toLowerCase();
        isPalindrome = true;
        for (i = 0, j = currentWord.length - 1; i < currentWord.length / 2; i += 1, j -= 1) {
            if (currentWord[i] !== currentWord[j] || currentWord.length < 2) {
                isPalindrome = false;
            }

        }

        if(isPalindrome){
            result.push(words[index]);
        }
    }

    return result;

}


var text = 'Lorem Ipsum is simply dummy Abba text of the printing deleveled and typesetting ' +
        'lamal industry. Lorem redivider Ipsum has been exe the industry standard dummy text';

console.log('The text is:');
console.log(text);
console.log('-------------------------------------');
console.log('The palindromes are: ')
console.log(palindromes(text).join(', '));



