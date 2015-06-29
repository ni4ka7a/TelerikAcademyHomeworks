
function compareArrays(firstArray, secondArray){

    var minLength = Math.max(firstArray.length, secondArray.length);

    if(firstArray.length < secondArray.length){
        return 'The first array comes firs lexicographically';
    }

    else if(secondArray.length < firstArray.length){
        return 'The second array comes firs lexicographically';
    }

    else{
        for(var i = 0; i < minLength; i+=1){
            if(firstArray[i] < secondArray[i]){
                return 'The first array comes firs lexicographically';
            }

            else if(secondArray[i] < firstArray[i]){
                return 'The second array comes firs lexicographically';
            }
        }
        return 'The arrays are equal';
    }
}

var firstArray1 = ['a', 'b', 'c'], secondArray1 = ['a', 'b', 'c'];
var firstArray2 = ['a', 'b', 'c'], secondArray2 = ['a', 'b'];
var firstArray3 = ['a', 'b', 'c'], secondArray3 = ['d', 'a', 'b'];

console.log(compareArrays(firstArray1, secondArray1));
console.log(compareArrays(firstArray2, secondArray2));
console.log(compareArrays(firstArray3, secondArray3));