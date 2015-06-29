
function findProperty(){

    var smallest = 'something', largest  = 'something';
    for(var prop in document){
        if(prop < smallest){
            smallest = prop;
        }

        if(prop > largest ){
            largest  = prop;
        }
    }

    console.log('The smallest property in document is: ' + smallest);
    console.log('The largest property in document is: ' + largest );


    smallest = 'something';
    largest = 'something';
    for(var prop in window){
        if(prop < smallest){
            smallest = prop;
        }

        if(prop > largest ){
            largest  = prop;
        }
    }

    console.log('The smallest property in window is: ' + smallest);
    console.log('The largest property in window is: ' + largest );

    smallest = 'something';
    largest = 'something';
    for(var prop in navigator){
        if(prop < smallest){
            smallest = prop;
        }

        if(prop > largest ){
            largest  = prop;
        }
    }

    console.log('The smallest property in navigator is: ' + smallest);
    console.log('The largest property in navigator is: ' + largest );

}

findProperty();