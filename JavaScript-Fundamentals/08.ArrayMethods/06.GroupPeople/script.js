

function createPerson(firstName, lastName, age, gender){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender
    }

}

var personArr = [
    createPerson('Gosho', 'Peshov', 20, false),
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

var result = personArr.reduce(function(obj, person){
    if(obj.hasOwnProperty(person.firstName[0]) === false){
        obj[person.firstName[0]] = [];
    }
    obj[person.firstName[0]].push(person);

    return obj;
},{});

console.log(result)



