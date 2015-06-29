
function occurrencesOfWord(inputText, inputWord, caseSensitive){

    if(caseSensitive === false){
        inputText =  inputText.toLowerCase();
        inputWord =  inputWord.toLowerCase();
    }

    var counter = 0;
    var currentIndex = 0;
    var index = inputText.indexOf(inputWord);
    while(index >= 0) {
        counter += 1;
        currentIndex = index + 1;
        index = inputText.indexOf(inputWord, currentIndex);
    }

    console.log('The word "' + inputWord + '" occurrence ' + counter + ' times');


}

// By default the function is case sensitive
occurrencesOfWord('World Hello world', 'world');
occurrencesOfWord('World Hello world', 'World');

// If you put the third parameter to false the function become case insensitive
occurrencesOfWord('World Hello world', 'World', false);