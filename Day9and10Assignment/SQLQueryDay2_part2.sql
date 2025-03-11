use  BookStoreDB

select * from Authors;
select * from Books;
select * from Customers;
select * from OrderItems;
select * from Orders;

-- Retrieve all books cheaper than the most expensive book written by( any  author based on your data) 
SELECT b.Title, b.Price
FROM Books b
WHERE b.Price < (
    SELECT MAX(b1.Price)
    FROM Books b1
    JOIN Authors a ON b1.AuthorID = a.AuthorID
);


-- List all customers whose total spending is greater than the average spending of all customers 
SELECT c.CustomerID, c.Name, SUM(o.TotalAmount) AS TotalSpending
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.Name
HAVING SUM(o.TotalAmount) > (
    SELECT AVG(TotalAmount)
    FROM Orders
);


--stored procedures
--Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer

CREATE PROCEDURE GetOrdersByCustomer
    @CustomerID INT
AS
BEGIN
    -- Retrieve all orders placed by the customer
    SELECT o.OrderID, o.CustomerID, o.OrderDate, o.TotalAmount
    FROM Orders o
    WHERE o.CustomerID = @CustomerID;
END;

EXEC GetOrdersByCustomer @CustomerID = 1;

--Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range 

CREATE PROCEDURE GetBooksByPriceRange
    @MinPrice DECIMAL(10, 2),
    @MaxPrice DECIMAL(10, 2)
AS
BEGIN
    SELECT b.BookID, b.Title, b.Price, b.PublishedYear, a.Name AS AuthorName
    FROM Books b
    JOIN Authors a ON b.AuthorID = a.AuthorID
    WHERE b.Price BETWEEN @MinPrice AND @MaxPrice
    ORDER BY b.Price;
END;

EXEC GetBooksByPriceRange @MinPrice = 100.00, @MaxPrice = 800.00;

--1.Create a view named AvailableBooks that shows only books that are in stock, including BookID, Title, AuthorID, Price, and PublishedYear
CREATE VIEW AvailableBooks AS
SELECT 
    b.BookID, 
    b.Title, 
    b.AuthorID, 
    b.Price, 
    b.PublishedYear
FROM Books b
WHERE b.Price > 0;

SELECT * FROM AvailableBooks;


