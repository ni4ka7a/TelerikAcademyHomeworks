

function createPerson(firstName, lastName, age, gender){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender
    }

}

var personArr = [
    createPerson('Pesho', 'Peshov', 20, false),
    createPerson('Ivan', 'ivanov', 25, false),
    createPerson('Maria', 'Petrova', 20, true),
    createPerson('Elena', 'Dimitrova', 30, true),
    createPerson('Stamat', 'Georgiev', 23, false),
    createPerson('Vanq', 'Georgieva', 22, true),
    createPerson('Kalina', 'Simeonova', 29, true),
    createPerson('Nikolay', 'Nenkov', 31, false),
    createPerson('Gergana', 'Radeva', 19, true),
    createPerson('Radoslav', 'Kirov', 29, false)
]


var sortedArr = personArr.sort(function(a, b){
    return a.age - b.age;
})

console.log('The youngest person is:');
console.log(sortedArr[0].firstName + ' ' + sortedArr[0].lastName + ' ' + sortedArr[0].age);

