

//The function returns all sub-strings that match the format @…
// So it will return stuff like @a , @d , @dada
// But it will not return stuff like daad@ or @

function extractMails(str){
    var words = str.split(' ');
    var i,
        result = [];
        len = words.length;

    for(i = 0; i < len; i += 1){
        if(words[i].indexOf('@') !== -1){
            if(words[i][words[i].indexOf('@') + 1] !== undefined){
                result.push(words[i]);
            }
        }
    }

    return result;
}



var str = 'Lorem @ Ipsum is simply pesho@yahoo.com dummy text of the printing ld@ and typesetting ' +
        'industry. Lorem Ipsum has academy@telerik.com been the industry standard dummy text';

console.log('The text is:');
console.log(str);

console.log('The emails are:');
console.log(extractMails(str).join(', '));