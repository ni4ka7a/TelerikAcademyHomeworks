/* Task Description */
/*
     Write a function that sums an array of numbers:
     numbers must be always of type Number
     returns `null` if the array is empty
     throws Error if the parameter is not passed (undefined)
     throws if any of the elements is not convertible to Number

 */

function sum(arr) {

    if (arr.length === 0) {
        return null;
    }

    else if (arr === undefined) {
        throw new Error();
    }

    return arr.map(Number)
        .reduce(function (s, num) {
            if (isNaN(num)) {
                throw new Error();
            }
            else {
                return s + num;
            }
        }, 0)
}

module.exports = sum;