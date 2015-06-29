
function createPeople(firstName, lastName, age){
    return{
        firstName: firstName,
        lastName: lastName,
        age: age
    }
}


var pesho = createPeople('Pesho', 'Petrov', 25);
var gosho = createPeople('Gosho', 'Petrov' , 30);
var ivan = createPeople('Ivan', 'Ivanov', 25);
var stamat = createPeople('Stamat', 'Bogdanov', 24);
var stamat2 = createPeople('Stamat', 'Dimitrov', 24);


var peopleArray = [pesho, gosho, ivan, stamat, stamat2];


function groupPeople(peopleArray, key){

    var groupedPeople = {},
        i;
    for (i in peopleArray) {
        var groupProperty = peopleArray[i][key];

        if (!groupedPeople.hasOwnProperty(groupProperty)) {
            groupedPeople[groupProperty] = [];
        }
        groupedPeople[groupProperty].push(peopleArray[i]);
    }

    return groupedPeople;
}


var groupedByAge = groupPeople(peopleArray, 'age');
console.log('Grouped by age:')
console.log(groupedByAge);
console.log('------------------------');

var groupedByFirstName = groupPeople(peopleArray, 'firstName');
console.log('Grouped by first name:')
console.log(groupedByFirstName);
console.log('------------------------');

var groupedByLastName = groupPeople(peopleArray, 'lastName');
console.log('Grouped by last name:')
console.log(groupedByLastName);
console.log('------------------------');
