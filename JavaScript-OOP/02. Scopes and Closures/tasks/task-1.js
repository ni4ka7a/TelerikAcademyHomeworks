/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function listBooks() {
            var parameter = arguments[0];

            if(parameter !== undefined) {
                if(parameter.category !== undefined) {
                    return books.filter(function(book) {
                        return book.category === parameter.category;
                    })
                }

                else if(parameter.author !== undefined) {
                    return books.filter(function(book) {
                        return book.author === parameter.author;
                    })
                }
            }

            else {
                return books.sort(function (a, b) {
                    return a - b;
                })
            }
		}

        function listCategories() {
            return categories.sort(function(a, b) {
                return a - b;
            }).map(function(item) {
                return item.category;
            })
        }

		function checkIfTitleIsUnique(currentTitle) {
            return books.some(function(book) {
                return book.title === currentTitle;
            })
        }

        function checkIfISDNIsUnique(currentISDN) {
            return books.some(function(book) {
                return book.isbn === currentISDN;
            })
        }

        function checkIfCategoryExist(currentCategory) {
            return categories.some(function(item) {
                return item.category === currentCategory;
            })
        }

        function validateTitleAndCategory(str) {
            return str.length > 2 && str.length < 100;
        }

        function validateAuthor(str) {
            return str.length > 0;
        }

        function validateISBN(currentISBN) {
            var i,
                len = currentISBN.length;

            if(len !== 10 && len !== 13) {
                return false;
            }

            for(i = 0; i < len; i += 1) {
                if(isNaN(currentISBN[i])) {
                    return false;
                }
            }

            return true;
        }

		function addBook(book) {

            if(checkIfISDNIsUnique(book.isbn)) {
                throw new Error('invalid isbn');
            }

            if(checkIfTitleIsUnique(book.title)) {
                throw new Error('invalid title');
            }

            if(!validateTitleAndCategory(book.category)) {
                throw new Error('The category must be between 2 and 100 characters');
            }

            if(!validateTitleAndCategory(book.title)) {
                throw new Error('The title must be between 2 and 100 characters');
            }

            if(!validateAuthor(book.author)) {
                throw new Error('The author name cannot be empty');
            }

            if(!validateISBN(book.isbn)) {
                throw  new Error('The ISBN should contains either 10 or 13 digits')
            }

            if(!checkIfCategoryExist(book.category)) {
                categories.push( {
                    category: book.category,
                    ID: categories.length + 10
                });
            }

			book.ID = books.length + 1;
			books.push(book);
			return book;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;

