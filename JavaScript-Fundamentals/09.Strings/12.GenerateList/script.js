


function generateList(people, template){
    var i,
        result = '',
        len = people.length;

    result  += '<ul>';

    for(i = 0; i < len; i += 1){
        result += '<li>';
        result += template;
        result = result.replace('-{name}-', people[i]['name']);
        result = result.replace('-{age}-', people[i]['age']);
        result += '</li>';
    }

    result += '</ul>';

    return result;
}


var people = [
    { name: 'Pehso', age: 20},
    { name: 'Gosho', age: 30},
    { name: 'Stamat', age: 25}
];

var template = document.getElementById('list-item').innerHTML;

document.getElementById('list-item').innerHTML = generateList(people, template);
