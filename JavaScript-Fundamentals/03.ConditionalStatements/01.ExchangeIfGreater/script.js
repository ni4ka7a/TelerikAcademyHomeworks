
function exchangeIfGreather(a, b){

    console.log('The values are: ' + a + ' ' + b);

    if(a > b){
        var temp = a;
        a = b;
        b = temp;
    }

    console.log('The result is: ' + a + ' ' + b);
}

exchangeIfGreather(12, 5);
exchangeIfGreather(152, 5323255);
exchangeIfGreather(132, 25);
