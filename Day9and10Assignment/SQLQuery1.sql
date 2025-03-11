use BookStoreDB

create table Authors(
AuthorID int primary key not null ,
Name varchar(50),
Country varchar(50))

create table Books(
BookID int primary key not null,
Title varchar(50),
AuthorID int ,
foreign key( AuthorID) references  Authors(AuthorID),
PublishedYear date )


create table Customers(
CustomerID int primary key not null,
Name varchar(50),
Email varchar(50) unique ,
PhoneNo varchar(10) unique )


create table Orders(
OrderID int primary key not null,
CustomerID int,
foreign key(CustomerID) references Customers(CustomerID),
OrderDate date,
TotalAmount int )

create table OrderItems(
OrderItemID int primary key not null,
OrderID int,
BookID int,
foreign key(OrderID) references Orders(OrderID),
foreign key(BookID) references Books(BookID),
Quantity int,
SubTotal decimal)


-- Add the Price column to the Books 
ALTER TABLE Books
ADD Price DECIMAL(10, 2);

-- Insert records into Authors table
INSERT INTO Authors (AuthorID, Name, Country) 
VALUES
    (1, 'J.K. Rowling', 'United Kingdom'),
    (2, 'George R.R. Martin', 'United States'),
    (3, 'J.R.R. Tolkien', 'United Kingdom'),
    (4, 'Agatha Christie', 'United Kingdom'),
    (5, 'Isaac Asimov', 'United States');

	-- Insert records into Books table
INSERT INTO Books (BookID, Title, AuthorID, PublishedYear) 
VALUES
    (1, 'Harry Potter and the Philosopher''s Stone', 1, '1997-06-26'),
    (2, 'A Game of Thrones', 2, '1996-08-06'),
    (3, 'The Lord of the Rings', 3, '1954-07-29'),
    (4, 'Murder on the Orient Express', 4, '1934-01-01'),
    (5, 'I, Robot', 5, '1950-12-02');

	-- Insert records into Customers table
INSERT INTO Customers (CustomerID, Name, Email, PhoneNo) 
VALUES
    (1, 'John Doe', 'johndoe@example.com', '1234567890'),
    (2, 'Jane Smith', 'janesmith@example.com', '0987654321'),
    (3, 'Robert Brown', 'robertbrown@example.com', '1122334455'),
    (4, 'Emily White', 'emilywhite@example.com', '6677889900'),
    (5, 'Michael Green', 'michaelgreen@example.com', '5566778899');


	INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES
    (1, 1, '2025-02-01', 59),
    (2, 2, '2025-02-10', 89),
    (3, 3, '2025-02-15', 29),
    (4, 4, '2025-02-20', 19),
    (5, 5, '2025-02-25', 49);


	-- Insert records into OrderItems table
INSERT INTO OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal)
VALUES
    (1, 1, 1, 3, 59),
    (2, 2, 2, 2, 59),
    (3, 3, 3, 1, 29),
    (4, 4, 4, 1, 19),
    (5, 5, 5, 3, 44.97);

	update Books set Title='SQL Mastery'
	where BookID=2;

	
	update Books set Price = price*1.10
	where BookID=2

	select * from Books;