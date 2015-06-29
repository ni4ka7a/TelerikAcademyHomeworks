
function frequentNumber(inputArray){

    var maxCounter = 0, tempCounter, index, tempNumber, length;
    length = inputArray.length;

    for(var i = 0; i < length; i+=1){
        tempNumber = inputArray[i];
        tempCounter = 1;

        for(var j = i + 1; j < length; j+=1){
            if(tempNumber === inputArray[j]){
                tempCounter += 1;
                index = j;
            }
        }

        if(tempCounter > maxCounter){
            maxCounter = tempCounter;
        }
    }

    console.log('The most frequent number is: ' + inputArray[index] + ' - ' + maxCounter + ' times');
}


var array = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

frequentNumber(array);