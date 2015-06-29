
function selectionSort(arrayOfNumbers){

    var length = arrayOfNumbers.length, smallestNumber, tempIndex = 0, tempNumber, smallerNumberFound;

    for(var i = 0; i < length; i+=1){
        smallestNumber = arrayOfNumbers[i];
        smallerNumberFound = false;

        for(var j = i; j < length; j += 1){
            if(arrayOfNumbers[j] < smallestNumber){
                smallestNumber = arrayOfNumbers[j];
                tempIndex = j;
                smallerNumberFound = true;
            }
        }

        if(smallerNumberFound) {
            tempNumber = arrayOfNumbers[i];
            arrayOfNumbers[i] = smallestNumber;
            arrayOfNumbers[tempIndex] = tempNumber;
        }
    }

    console.log(arrayOfNumbers.join(', '));

}

var numbers = [31 ,32.3, -5, 42, 1];

selectionSort(numbers);