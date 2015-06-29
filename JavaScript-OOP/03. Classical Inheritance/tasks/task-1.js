/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function () {
        function Person(firstname, lastname, age) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }

        function checkName(name) {
            var i,
                len = name.length;

            if(name.length < 3 || name.length > 20) {
                return false;
            }

            for(i = 0;i < len; i += 1) {
                if((name[i] >= 'A' && name[i] <= 'Z') ||
                    name[i] >= 'a' && name[i] <= 'z') {
                    continue;
                }

                else {
                    return false;
                }
            }

            return true;
        }

        function checkAge(age) {
            if(isNaN(age)) {
                return false;
            }

            if(age < 0 || age > 150) {
                return false;
            }

            return true;
        }

        Object.defineProperty(Person.prototype, 'firstname', {
            get: function() {
                return this._firstname;
            },
            
            set: function (value) {
                if(!checkName(value)) {
                    throw new Error('First name is incorrect!');
                }

                this._firstname = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'lastname', {
            get: function() {
                return this._lastname;
            },

            set: function (value) {
                if(!checkName(value)) {
                    throw new Error('Last name is incorrect!');
                }

                this._lastname = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'age', {
            get: function() {
                return this._age;
            },

            set: function (value) {
                if(!checkAge(value)) {
                    throw new Error('Age is incorrect!');
                }

                this._age = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'fullname', {
            get: function() {
                return this.firstname + ' ' + this.lastname;
            },

            set: function(value) {
                var splitedName = value.split(' ');
                if(!checkName(splitedName[0])) {
                    throw new Error('First name is incorrect!');
                }

                if(!checkName(splitedName[1])) {
                    throw new Error('Last name is incorrect!');
                }

                this.firstname = splitedName[0];
                this.lastname = splitedName[1];
            }
        });

        Person.prototype.introduce = function() {
            return 'Hello! My name is ' + this.firstname + ' ' + this.lastname + ' and I am ' + this.age + '-years-old';
        };

		return Person;
	} ());
    return Person;
}
module.exports = solve;

