
function initializeArray(){
    var array = [];

    for(var i = 0; i < 20; i+=1){
        array[i] = i*5;
    }

    console.log(array.join(', '));
}


initializeArray();