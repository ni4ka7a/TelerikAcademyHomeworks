

function deepCopy(obj){
    if (typeof obj !== 'object') {
        return obj;
    }

    var cloned = {};
    for (var prop in obj) {
        cloned[prop] = deepCopy(obj[prop]);
    }

    return cloned;
}


var obj1 = {
    name: 'Pesho',
    age: 30,
    marks: [2, 3, 4, 5, 6],
    address: {
        country: 'Bulgaria',
        town: 'Sofia',
        street: 'firstStreet'
    }
}

console.log('The original object:');
console.log(obj1);

var obj2 = deepCopy(obj1);

//change somthing in obj1
obj1.name = 'Gosho';

console.log('The original object changed:');
console.log(obj1);

console.log('The copy remain the same');
console.log(obj2);