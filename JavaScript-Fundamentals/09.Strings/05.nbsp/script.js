
function nbspReplace(str){
    var i,
        len = str.length,
        nbsp = '&nbsp';

    for(i = 0; i < len; i += 1){
        if(str.indexOf(' ') !== 0){
            str = str.replace(' ', nbsp);
        }
    }

    return str;
}

var str = 'Lorem Ipsum is simply dummy text of the printing and typesetting';
console.log(nbspReplace(str));