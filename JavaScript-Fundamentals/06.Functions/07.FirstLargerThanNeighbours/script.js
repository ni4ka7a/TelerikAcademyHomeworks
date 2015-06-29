
function firtsLargetThanNeighbours(inputArray){
    var length = inputArray.length;

    for(var i = 1; i < length - 1; i += 1){
        if(inputArray[i] > inputArray[i + 1] && inputArray[i] > inputArray[i - 1]){
            return i;
        }
    }

    return -1;
}


// This function doesn't check the first and the last element from the array because its doesn't have 2 neighbours

var inputArray = [1, 22, 3, 4, 6, 23, 33];

console.log(firtsLargetThanNeighbours(inputArray));