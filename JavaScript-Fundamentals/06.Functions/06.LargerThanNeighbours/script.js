
function largerThanNeighbours(position, inputArray){

    var isLarger = false;

    if(position === 0){
        if(inputArray[position] > inputArray[position + 1]){
            isLarger = true;
        }
    }

    else if(position === inputArray.length - 1){
        if(inputArray[position] > inputArray[position - 1]){
            isLarger = true;
        }
    }

    else if(inputArray[position] > inputArray[position + 1] &&
        inputArray[position] > inputArray[position - 1]){

        isLarger = true;
    }

    if(isLarger){
        console.log('The number in position ' + position + ' is larger than its neighbours');
    }

    else {
        console.log('The number in position ' + position + ' is NOT larger than its neighbours');
    }

}


var inputArray = [26, 32, 32, 44, 5, 1, 3, 4, 32, 3, 41, 45];

largerThanNeighbours(11, inputArray);
largerThanNeighbours(4, inputArray);