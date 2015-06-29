
function minAndMaxOfSequence(sequence){
    var min = sequence[0], max = sequence[0];

    for(var i = 1; i < sequence.length; i+=1){
        if(sequence[i] > max){
            max = sequence[i];
        }

        if(sequence[i] < min){
            min = sequence[i];
        }
    }

    console.log('The sequence is: ', sequence.join(', '));
    console.log('The max number is: ' + max);
    console.log('The min number is: ' + min);
}


var firstSequence = [1, 2, 30, 42, 3223, 32, 1, 34];
var secondSequence = [5, 1, 0.5, -31, 13];

minAndMaxOfSequence(firstSequence);
minAndMaxOfSequence(secondSequence);
