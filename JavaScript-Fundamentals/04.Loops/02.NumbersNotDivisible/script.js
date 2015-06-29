
function printNumbers(N){
    for(var i = 1; i <= N; i+=1){
        if((i % 3 != 0) || (i % 7 != 0)){
            console.log(i);
        }
    }
}

printNumbers(21);
