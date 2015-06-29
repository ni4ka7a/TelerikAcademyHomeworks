

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
    createPerson('Nikolay', 'Nenkov', 21, false),
    createPerson('Gergana', 'Radeva', 33, true),
    createPerson('Radoslav', 'Kirov', 29, false)
]

personArr.forEach(function(person){
    var gender = person.gender;
    gender === true ? gender = 'female' : gender = 'male';
    console.log('Name: ' + person.firstName + ' ' + person.lastName + ' Age: ' + person.age + ' gender: ' + gender);
})