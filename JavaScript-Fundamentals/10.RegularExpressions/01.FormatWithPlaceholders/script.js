
if (!String.prototype.format) {
    String.prototype.format = function(callback){

        return this.replace(/(?:#{(\w+)})/g, function ($0, $1) {
            return callback[$1];
        });
    }
}


var options = {name: 'John'};
console.log('Hello, there! Are you #{name}?'.format(options));

var options = {name: 'John', age: 13};
console.log('My name is #{name} and I am #{age}-years-old'.format(options));



