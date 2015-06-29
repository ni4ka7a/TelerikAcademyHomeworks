

function reverseNumber(){
    var input = document.getElementById('inputValue');
    var reversedNumber = input.value;
    reversedNumber =  reversedNumber.split('').reverse().join('');


    if(isNaN(input.value)){
        document.getElementById('reversed').innerHTML = 'not a number';
    }

    else {
        document.getElementById('reversed').innerHTML = reversedNumber;
    }

}