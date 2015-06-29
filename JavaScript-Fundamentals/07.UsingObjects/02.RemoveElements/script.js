
Array.prototype.remove = function(element) {
    var i, len = this.length;
    for(i = 0; i < len; i += 1){
        if(this[i] === element){
            this.splice(i ,1);
            i -= 1;
        }
    }

    return this;

}


var arr = [2, 3, 1, 4, 5, 1];
console.log('The array before remove: ' + arr.join(','));


arr.remove(1);
console.log('The array after remove the number 1: ' + arr.join(','));
