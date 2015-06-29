
function parseURL(str){
    var i,
        protocol = '',
        server = '',
        resource = '',
        len = str.length;

    var indexOfProtocol = str.indexOf('://'),
        indexOfServer = str.indexOf('/', indexOfProtocol + 4);



    for(i = 0; i < len; i += 1){
        if(i < indexOfProtocol){
            protocol += str[i];
        }

        else if(i < indexOfServer){
            if(server === ''){
                i += 3;
            }
            server += str[i];
        }

        else {
            resource += str[i];
        }
    }

    console.log('The url is: ' + str);
    console.log('Protocol: ' +protocol);
    console.log('Server: ' +server);
    console.log('Resource: ' +resource);
}


var url1 = 'http://telerikacademy.com/Courses/Courses/Details/239';
var url2 = 'https://github.com/TelerikAcademy/JavaScript-Fundamentals/blob/master/11.%20Strings/README.md';
parseURL(url1);
parseURL(url2);