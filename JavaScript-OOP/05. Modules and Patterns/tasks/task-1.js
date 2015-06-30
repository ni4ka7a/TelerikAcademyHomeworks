/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

    var studentId = 0;

    var Course = {
        init: function (title, presentations) {
            if (!validateTitle(title)) {
                throw new Error('Invalid title');
            }

            if (!validatePresentationTitles(presentations)) {
                throw new Error('Invalid Presentation title');
            }

            this.title = title;
            this.presentations = presentations;
            this.students = [];

            return this;
        },

        addStudent: function (name) {

            if (!validateStudentName(name)) {
                throw new Error('Invalid Student name');
            }

            this.students.push(
                {
                    firstname: name.split(' ')[0],
                    lastname: name.split(' ')[1],
                    id: studentId += 1,
                    homeworksCounter: 0,
                    examResult: 0,
                    alreadyPushedResults: false,
                    finalResult: 0
                }
            );

            return studentId;
        },

        getAllStudents: function () {
            return getStudents(this.students);
        },

        submitHomework: function (studentID, homeworkID) {
            if (!validateStudentID(studentID, this.students)) {
                throw new Error('Invalid student ID');
            }

            if (!validateHomeworkID(homeworkID, this.presentations)) {
                throw new Error('Invalid homework ID');
            }

            this.students.forEach(function (currentStudent) {
                if (currentStudent.id === studentID) {
                    return currentStudent.homeworksCounter += 1;
                }
            });

            return this;
        },

        pushExamResults: function (results) {
            pushExamResults(results, this.students);
        },

        getTopStudents: function () {
            calculateFinalScore(this.students, this.presentations.length);
            return this.students.sort(function(first, second) {
                return second.finalResult - first.finalResult;
            }).slice(0, 10);
        }
    };


    function validateTitle(str) {
        var i,
            len = str.length;

        if (len === 0 || str[0] === ' ' || str[len - 1] === ' ') {
            return false;
        }

        for (i = 0; i < len; i += 1) {
            if (str[i] === ' ' && str[i + 1] === ' ') {
                return false;
            }
        }

        return true;
    }

    function validatePresentationTitles(presentationTitles) {
        var i,
            len = presentationTitles.length;

        if (len === 0) {
            return false;
        }

        for (i = 0; i < len; i += 1) {
            if (!validateTitle(presentationTitles[i])) {
                return false;
            }
        }

        return true;
    }

    function validateStudentName(name) {
        var i,
            j,
            len,
            fullName = name.split(' ');

        if (fullName.length !== 2) {
            return false;
        }


        for (i = 0; i < 2; i += 1) {
            if (fullName[i][0] < 'A' || fullName[i][0] > 'Z') {
                return false;
            }

            for (j = 1, len = fullName[i].length; j < len; j += 1) {
                if (fullName[i][j] < 'a' || fullName[i][j] > 'z') {
                    return false;
                }
            }
        }

        return true;
    }

    function validateStudentID(id, studentsCollection) {
        return studentsCollection.some(function (currentStudent) {
            return currentStudent.id === id;
        });
    }

    function validateHomeworkID(id, presentationsCollection) {
        if (id > presentationsCollection.length || id < 1) {
            return false;
        }

        return true;
    }

    function getStudents(studentsCollection) {
        var tempStudents = [];

        studentsCollection.forEach(function (currentStudent) {
            return tempStudents.push(
                {
                    firstname: currentStudent.firstname,
                    lastname: currentStudent.lastname,
                    id: currentStudent.id
                }
            )
        });

        return tempStudents;
    }

    function pushExamResults(results, studentsCollection) {
        var i,
            currentResult,
            len = results.length;

        for (i = 0; i < len; i += 1) {
            currentResult = results[i];
            if (!validateStudentID(currentResult.id, studentsCollection)) {
                throw new Error('Invalid Student ID!');
            }

            if (isNaN(currentResult.Score)) {
                throw new Error('Invalid Exam result!');
            }

            studentsCollection.forEach(function (currentStudent) {
                if (currentStudent.id === currentResult.id) {

                    if (currentStudent.alreadyPushedResults) {
                        throw new Error('Student ' + currentStudent.firstname + ' ' +
                            currentStudent.lastname + ' is trying to cheat!!!');
                    }

                    currentStudent.examResult = currentResult.Score;
                    currentStudent.alreadyPushedResults = true;
                }
            });

        }
    }

    function calculateFinalScore(studentsCollection, numberOfAllHomeworks) {
        var i,
            len = studentsCollection.length,
            currentHomeworkScore = 0;

        for (i = 0; i < len; i += 1) {
            currentHomeworkScore = studentsCollection[i].homeworksCounter / numberOfAllHomeworks;
            studentsCollection[i].finalResult = (0.75 * studentsCollection[i].examResult) + currentHomeworkScore;
        }
    }

    return Course;
}

module.exports = solve;



