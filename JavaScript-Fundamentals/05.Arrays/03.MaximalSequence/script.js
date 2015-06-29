
function maxSequence(sequence){

    var length = sequence.length, tempCounter = 1, currentDigit, maxCounter = 0;

    for(var i = 0; i < length; i+=1){
        if(sequence[i] === sequence[i + 1]){
            tempCounter += 1;
        }

        else{
            if(tempCounter > maxCounter){
                maxCounter = tempCounter;
                currentDigit = sequence[i];
            }

            tempCounter = 1;
        }
    }

    if(maxCounter < 2){
        console.log('There is no sequence');
    }

    else{
        console.log(maxCounter);
        console.log('The sequence is: ' + Array(maxCounter + 1).join(currentDigit + ' '));
    }
}

var seq = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
maxSequence(seq);
