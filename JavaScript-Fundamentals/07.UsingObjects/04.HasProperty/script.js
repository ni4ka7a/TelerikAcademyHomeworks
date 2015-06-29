
function hasProperty(obj, name){

    for(var prop in obj){
        if(prop === name){
            return true;
        }
    }

    return false;
}


var someObj = {
    x: 5,
    y: 10,
    name: 'pesho'
}


console.log('The object is:');
console.log(someObj);

console.log('Is there a propery "name" in the object ? ' + hasProperty(someObj, 'name'));
console.log('Is there a propery "age" in the object ? ' + hasProperty(someObj, 'age'));

