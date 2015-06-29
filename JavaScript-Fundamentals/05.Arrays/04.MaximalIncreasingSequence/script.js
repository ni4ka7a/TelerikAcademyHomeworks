
function increasingSequence(sequence){

    var startSequence = 0, length = sequence.length, tempCounter = 1, maxCounter = 1;

    for(var i = 0; i < length; i+=1){
        if(sequence[i] < sequence[i + 1]){
            tempCounter += 1;
        }
        else{
            if(tempCounter > maxCounter){
                maxCounter = tempCounter;
                startSequence = i - maxCounter;
            }

            tempCounter = 1;
        }

    }

    if(maxCounter < 2){
        console.log('There is no increasing sequence');
    }

    else{
        console.log('The max increasing sequence is: ');
        console.log(sequence.slice(startSequence + 1, maxCounter + startSequence + 1));
    }
}

var sequence = [3, 2, 3, 4, 2, 2, 4];

increasingSequence(sequence);