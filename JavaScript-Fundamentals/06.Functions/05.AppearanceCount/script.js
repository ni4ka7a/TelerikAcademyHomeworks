
function numberInArray(inputNumber, inputArray){

    var counter = 0, length = inputArray.length;

    for(var i = 0; i < length; i += 1){
        if(inputArray[i] === inputNumber){
            counter += 1;
        }
    }

    console.log('The number ' + inputNumber + ' appearance ' + counter + ' times in the array');
}


var inputArray = [2, 32, 32, 44, 5, 1, 3, 4, 32, 3, 41, 4];

numberInArray(32, inputArray);