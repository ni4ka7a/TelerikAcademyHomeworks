

function createPerson(firstName, lastName, age, gender){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender
    }

}

var personArr1 = [
    createPerson('Pesho', 'Peshov', 20, false),
    createPerson('Ivan', 'ivanov', 25, false),
    createPerson('Maria', 'Petrova', 20, true),
    createPerson('Elena', 'Dimitrova', 30, true),
    createPerson('Stamat', 'Georgiev', 23, false)

]

var personArr2 = [
    createPerson('Vanq', 'Georgieva', 22, true),
    createPerson('Kalina', 'Simeonova', 29, true),
    createPerson('Nikolay', 'Nenkov', 21, false),
    createPerson('Gergana', 'Radeva', 33, true),
    createPerson('Radoslav', 'Kirov', 16, false)
]

console.log('Is there only people of age in the first array ?');
console.log(personArr1.every(function(item){
    return item.age >= 18;
}));

console.log('---------------------------------------------');

console.log('Is there only people of age in the second array ?');
console.log(personArr2.every(function(item){
    return item.age >= 18;
}));
