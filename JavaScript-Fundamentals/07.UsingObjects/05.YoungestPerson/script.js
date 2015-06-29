
function youngestPerson(arr){

    var sorted = arr.sort(function(x, y){
        return x.age - y.age;
    });

    console.log('Youngest person: ' + sorted[0].firstname + ' ' + sorted[0].lastname);

}

var people = [
    { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname : 'Bay', lastname: 'Ivan', age: 81},
    { firstname : 'Pesho', lastname: 'Samokovski', age: 8},
    { firstname : 'Stamat', lastname: 'Kamenov', age: 9},
    { firstname : 'Dimcho', lastname: 'Dimov', age: 45}
    ];

youngestPerson(people);