
function binarySearch(inputArray, inputNumber){

    var maxIndex, minIndex, middleIndex, length;
    length = inputArray.length;
    maxIndex = length - 1;
    minIndex = 0;

    while(true){
        middleIndex = ((maxIndex + minIndex) / 2) | 0;

        if(inputNumber === inputArray[middleIndex]){
            console.log('The number is on index ' + middleIndex);
            break;
        }

        else if(inputNumber > inputArray[middleIndex]){
            minIndex = middleIndex + 1;
        }

        else if(inputNumber < inputArray[middleIndex]){
            maxIndex = middleIndex - 1;
        }

        if(maxIndex < minIndex){
            console.log('The number was not found');
            break;
        }
    }
}


var inputArray = [1, 2, 3, 4, 5, 6];
inputArray.sort();
binarySearch(inputArray, 3);