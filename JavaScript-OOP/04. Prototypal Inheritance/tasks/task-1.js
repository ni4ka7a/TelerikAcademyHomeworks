/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
      * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * method removeAttribute(attribute)
    * throw Error if attribute does not exist in the domElement
*/


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/

//Solved with the new tests!

function solve() {
	var domElement = (function () {
		var domElement = {

			init: function(type) {

				this.type = type;
				this.children = [];
				this.attributesCollection = [];
				return this;
			},

			appendChild: function(child) {

				child.parent = this;
				this.children.push(child);
				return this;
			},

			addAttribute: function(name, value) {
				var isAttributeExist = this.attributesCollection.some(function(item) {
					return item.name === name;
				});

				if(!validateAttribute(name)) {
					throw new Error('Attribute name is not valid');
				}

				if(isAttributeExist) {
					replaceRepeatingAttribute(name, value, this.attributesCollection);
				}

				else {
					this.attributesCollection.push({
						name: name,
						value: value
					});
				}

				return this;
			},

            removeAttribute: function(attribute) {
                removeAttribute(attribute, this.attributes);

                return this;
            },

			get type() {
                return this._type;
            },

            set type(value) {
                if(!validateType(value)) {
                    throw new Error('The type is not valid!');
                };

                this._type = value;
            },

            get content() {
                return this._content;
            },

            set content(value) {
              if(this.children.length === 0) {
                  this._content = value;
              }
            },

			get innerHTML(){
				return renderHTML(this);
			},

			get attributes() {
				return this.attributesCollection.sort(function(a, b) {
					return a.name > b.name;
				})
			}

		};

		function validateType(str) {
			var i,
				len = str.length;

			if(len === 0 || typeof(str) !== 'string') {
				return false;
			}

			for(i = 0; i < len; i += 1) {
				if((str[i] >= 'A' && str[i] <= 'Z') ||
					(str[i] >= 'a' && str[i] <= 'z') ||
					(!isNaN(str[i]))) {
					continue;
				}

				else {
					return false;
				}
			}

			return true;
		}

		function validateAttribute(str) {
			var i,
				len = str.length;

			if(str.length === 0) {
				return false;
			}

			for(i = 0; i < len; i += 1) {
				if(str[i] === ' ') {
					return false;
				}

				else if((str[i] >= 'A' && str[i] <= 'Z') ||
					(str[i] >= 'a' && str[i] <= 'z') ||
					(!isNaN(str[i])) || str[i] === '-') {
					continue;
				}

				else {
					return false;
				}
			}

			return true;
		}

		function attributesAsString(attributes) {
			var i,
				len = attributes.length,
				result = ' ';

			for(i = 0; i < len; i += 1) {
				result += attributes[i].name + '="' + attributes[i].value + '"';

				if(i !== len - 1) {
					result += ' ';

				}
			}

			return result;
		}

		function renderHTML(currentElement) {
			var result = '<';

			if(currentElement.attributes.length > 0) {
				result += currentElement.type + attributesAsString(currentElement.attributes) + '>';
			}

			else {
				result += currentElement.type + '>';
			}


			if(currentElement.children.length > 0) {
				currentElement.content = undefined;
			}

			var i,
				len = currentElement.children.length;

			for(i = 0; i < len; i += 1) {
				var child = currentElement.children[i];

				if(typeof(child) === 'string') {
					result += child;
				}

				else {
					result += renderHTML(child);
				}
			}

			if(currentElement.content !== undefined) {
				result += currentElement.content;
			}

			result += '</' + currentElement.type + '>';

			return result;
		}

		function replaceRepeatingAttribute(name, value, collection) {

			var i,
				len = collection.length,
				currentObj = {
					name: name,
					value: value
				};

			for (i = 0; i < len; i += 1) {
				if (collection[i].name === currentObj.name) {
					collection[i] = currentObj;
				}
			}

			return collection;
		}

        function removeAttribute(item, collection) {
            var i,
                isAttributeExist,
                len = collection.length;

            isAttributeExist = collection.some(function(att) {
                return att.name === item;
            });

            if(!isAttributeExist) {
                throw  new Error('Invalid attribute!');
            }

            for(i = 0; i < len; i += 1) {
                if(collection[i] === undefined) {
                    continue;
                }

                if(collection[i].name === item) {
                    collection = collection.splice(i , 1);
                }
            }
        }

		return domElement;
	} ());
	return domElement;
}

module.exports = solve;



