
function biggestNumber(a, b, c, d, e){
    if(a > b){
        if(a > c){
            if(a > d){
                if(a > e){
                    return a;
                }
            }
            else if(d > e){
                return d;
            }
            else{
                return e;
            }
        }
        else if(c > d){
            if(c > e){
                return c;
            }
            else{
                return e;
            }
        }
    }

    else if(b > c){
        if(b > d){
            if(b > e){
                return b;
            }
            else{
                return e;
            }
        }
        else if(d > e){
            return d;
        }

        else{
            return e;
        }
    }

    else if(c > d){
        if(c > e){
            return c;
        }
        else{
            return e;
        }
    }
    else if(d > e){
        return d;
    }
    else{
        return e;
    }
}

var a1 = 5, b1 = 2, c1 = 2, d1 = 4, e1 = 1;
var a2 = -2, b2 = -22, c2 = 1, d2 = 0, e2 = 0;
var a3 = -2, b3 = 4, c3 = 3, d3 = 2, e3 = 0;

console.log('The biggest number is: ' + biggestNumber(a1, b1, c1, d1, e1));
console.log('The biggest number is: ' + biggestNumber(a2, b2, c2, d2, e2));
console.log('The biggest number is: ' + biggestNumber(a3, b3, c3, d3, e3));