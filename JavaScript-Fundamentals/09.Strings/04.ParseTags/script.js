
function parseTags(str){
    var i,
        len = str.length;

    for(i = 0; i < len; i += 1){
        if(str[i] === '<'){
            handleTags(i);
        }
    }


    function handleTags(index){
        var currentTag = str.substring(index + 1, str.indexOf('>', index));
        var transformText = str.substring(str.indexOf('>', index + 1), str.indexOf('<', index + 1));
        switch(currentTag){
            case 'upcase':

                str = str.replace(transformText, transformText.toUpperCase());
                break;
            case 'lowcase':
                str = str.replace(transformText, transformText.toLowerCase());
                break;
            case 'mixcase':
                var currentText = '';
                for(var j = 0; j < transformText.length; j += 1){
                    if(j % 2 === 0) {
                        currentText +=  transformText[j].toLowerCase();
                    }

                    else {
                        currentText += transformText[j].toUpperCase();
                    }
                }

                str = str.replace(transformText, currentText);
                break;
        }
    }

        // Remove the tags
        var startTag,
            endTag,
            tag;

        for(i = 0; i < len; i += 1){
            startTag = str.indexOf('<');
            endTag = str.indexOf('>');
            tag = str.substring(startTag, endTag + 1);
            str = str.replace(tag, '');
        }

    return str;
}


var str1 = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase>" +
        "have <lowcase>anything</lowcase> else.";


console.log(parseTags(str1));

