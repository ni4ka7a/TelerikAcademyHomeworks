

function createPerson(firstName, lastName, age, gender){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender
    }

}

var personArr1 = [
    createPerson('Pesho', 'Peshov', 15, false),
    createPerson('Ivan', 'ivanov', 25, false),
    createPerson('Maria', 'Petrova', 16, true),
    createPerson('Elena', 'Dimitrova', 17, true),
    createPerson('Stamat', 'Georgiev', 23, false)

]

var underageArr = personArr1.filter(function (person) {
    return person.age < 18;
})

console.log('The underaged persons are:');

underageArr.forEach(function (person) {
    var gender = person.gender;
    gender === true ? gender = 'female' : gender = 'male';
    console.log('Name: ' + person.firstName + ' ' + person.lastName + ' Age: ' + person.age + ' gender: ' + gender);
});