## 1.What database models do you know?
#### A database model is a type of data model that determines the logical structure of a database and fundamentally determines in which manner data can be stored, organized, and manipulated.

### Logical data models:
* Hierarchical database model
* Network model
* Relational model
* Entity–relationship model
* Object model
* Document model
* Entity–attribute–value model
* Star schema

### Physical data models:
* Inverted index
* Flat file

### Other models:
* Associative model
* Multidimensional model
* Multivalue model
* Semantic model
* XML database
* Named graph
* Triplestore

## 2.Which are the main functions performed by a Relational Database Management System (RDBMS)?

#### A relational database management system (RDBMS) is a program that lets you create, update, and administer a relational database. Most commercial RDBMS's use the Structured Query Language (SQL) to access the database, although SQL was invented after the development of the relational model and is not necessary for its use.

### Main Functions:
* Data Organization Management
* Data Storage Management
* Data Access Management
* Data Security Management
* Data integrity Management

## 3.Define what is "table" in database terms.

#### A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.

#### In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns (identifiable by name) and horizontal rows, the cell being the unit where a row and column intersect. A table has a specified number of columns, but can have any number of rows. Each row is identified by one or more values appearing in a particular column subset. The columns subset which uniquely identifies a row is called the primary key.

##4.Explain the difference between a primary and a foreign key.

###Primary Key:
* Primary key uniquely identify a record in the table.
* Primary Key can't accept null values.
* By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index.
* We can have only one Primary key in a table.

###Foreign Key:
* Foreign key is a field in the table that is primary key in another table.
* Foreign key can accept multiple null value.
* Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
* We can have more than one foreign key in a table.

## 5.Explain the different kinds of relationships between tables in relational databases.

### One-to-one relationship:
In a one-to-one relationship, each row in one database table is linked to 1 and only 1 other row in another table. The number of rows in the furst table must equal the number of rows in the second table.

### One-to-many relationship:
In a one-to-many relationship, each row in the related to table can be related to many rows in the relating table. This allows frequently used information to be saved only once in a table and referenced many times in all other tables.

### Many-to-many relationship:
In a many-to-many relationship, one or more rows in a table can be related to 0, 1 or many rows in another table. In a many-to-many relationship between Table A and Table B, each row in Table A is linked to 0, 1 or many rows in Table B and vice versa. A 3rd table called a mapping table is required in order to implement such a relationship.

## 6.When is a certain database schema normalized? What are the advantages of normalized databases?

#### Database normalization is the process of organizing the columns (attributes) and tables (relations) of a relational database to minimize data redundancy. Normalization involves decomposing a table into less redundant (and smaller) tables without losing information; defining foreign keys in the old table referencing the primary keys of the new ones.

#### The advantages of normalized databases are: 
* Reducing duplicate data
* Smaller database

## 7.What are database integrity constraints and when are they used?

* NOT NULL Constraint: Ensures that a column cannot have NULL value.
* DEFAULT Constraint: Provides a default value for a column when none is specified.
* UNIQUE Constraint: Ensures that all values in a column are different.
* PRIMARY Key: Uniquely identified each rows/records in a database table.
* FOREIGN Key: Uniquely identified a rows/records in any another database table.
* CHECK Constraint: The CHECK constraint ensures that all values in a column satisfy certain conditions.
* INDEX: Use to create and retrieve data from the database very quickly.

## 8.Point out the pros and cons of using indexes in a database.

### Advantages: 
Use an index for quick access to a database table specific information. The index is a structure of the database table the value of one or more columns to sort. As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table. The index take up disk space and reduce to add, delete, and update the line speed. In most cases, the speed advantages of indexes for data retrieval greatly exceeds it.

### Disadvantages:
Index will affect the speed of update and insert, because it requires the same update each index file. For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes. In some cases, the indexing words may not be fast, for example, the index is placed in a contiguous memory space, which will increase the burden of disk read, which is optimal, it should be through the actual use of the environment to be tested.

## 9.What's the main purpose of the SQL language?

Structured Query Language is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).

## 10.What are transactions used for?

#### A transaction symbolizes a unit of work performed within a database management system (or similar system) against a database, and treated in a coherent and reliable way independent of other transactions. A transaction generally represents any change in database. Transactions in a database environment have two main purposes:

1. To provide reliable units of work that allow correct recovery from failures and keep a database consistent even in cases of system failure, when execution stops (completely or partially) and many operations upon a database remain uncompleted, with unclear status.

2. To provide isolation between programs accessing a database concurrently. If this isolation is not provided, the programs' outcomes are possibly erroneous.

Transactions provide an "all-or-nothing" proposition, stating that each work-unit performed in a database must either complete in its entirety or have no effect whatsoever.

__Example:__
A money transfer action contains two operations:

* withdraw the money from the first account;
* add the money to the second account;

When this two operations are in one database transaction if on of the operations fail the whole operation will be canceled.

## 11.What is a NoSQL database?

#### A NoSQL ("non SQL" or "non relational") database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases. NoSQL databases are increasingly used in big data and real-time web applications.

## 12.Explain the classical non-relational data models.

* Document model (e.g. MongoDB, CouchDB)
	* Set of documents, e.g. JSON strings
* Key-value model (e.g. Redis)
	* Set of key-value pairs
* Hierarchical key-value
	* Hierarchy of key-value pairs
* Wide-column model (e.g. Cassandra)
	* Key-value model with schema
* Object model (e.g. Cache)
	* Set of OOP-style objects

## 13.Give few examples of NoSQL databases and their pros and cons.

### MongoDB

#### Pros:
* schema-less;
* ease of scale-out
* cost - MongoDB is free;
* you can choose what level of consistency you want depending on the value of the data 

#### Cons:
* Data size in MongoDB is typically higher due to e.g. each document has field names stored it;
* less flexibity with querying;
* no support for transactions;
* less up to date information available

### Redis

#### Pros: 
* Stores data in a variety of formats: list, array, sets and sorted sets;
* Multiple commands at once;
* Blocking reads -- will sit and wait until another process writes data to the cache
* Really fast

#### Cons:
* Super complex to configure -- requires consideration of data size to configure well;
* Master-slave architecture means if the master wipes out, and SENTINEL doesn't work, the system is sad