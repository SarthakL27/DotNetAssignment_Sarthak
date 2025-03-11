use BookStoreDB

select * from Books


update Books 
set Price=1200.00
where BookID=5 
AND BookID!=2;

update Orders 
set TotalAmount=56
where OrderID =1;

update Orders 
set OrderDate=null
where OrderID =1;

select * from Customers
select * from Orders

select * from Customers c
 left join Orders o on c.CustomerID=o.CustomerID where o.CustomerID is null

 Delete c
 from Customers c
 left join Orders o on c.CustomerID = o.OrderID
 where o.CustomerID is null

 select * from Customers
 select * from Orders

 INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES (6, 3, '2025-03-01', 100);


DELETE c
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.CustomerID IS NULL;

DELETE FROM Customers
WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders);

update Orders
set CustomerID=null 
where OrderID=6

SELECT * FROM Customers
INSERT INTO Customers VALUES (6,'Omi', 'omi@yahoo.com', 9898989898)

DELETE Customers FROM Customers
LEFT JOIN Orders
ON Orders.CustomerID = Customers.CustomerID
WHERE Orders.CustomerID IS NULL


select * from Books
--retrieve books with a price greater than 1000
select * from Books where Price>1000;

--find total no of books available
select  count(BookID) as total_No_Books from Books

--Total no of books published between 1995 and 2000
select	Title from Books where year(PublishedYear) between 1995 and 2000 


select * from Customers
select * from Orders
--find all customers who have placed at least one order
select Name  from Customers c left join Orders o 
on c.CustomerID =o.CustomerID where o.CustomerID is not null


--retrieve books where title contains	the word "SQL"
select * from Books where Title like '%SQL%'

-- Find the most expensive book in the store. 
SELECT *FROM Books WHERE Price = (SELECT MAX(Price) FROM Books);

-- Retrieve customers whose name starts with "A" or "J". 
select * from Customers 
where  name like  'J%' or name like  'A%'

select * from customers;

select * from Orders

SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders;


--JOINS--
select * from Orders
select * from Customers
select * from OrderItems
select * from Books

select * from Authors




-- Retrieve all book titles along with their respective author names
select Title ,Name from Books b inner join Authors A on B.AuthorID=A.AuthorID

-- List all customers and their orders (if any). 
select Name , c.CustomerID,o.OrderID,o.TotalAmount from Customers c join Orders o on c.CustomerID = o.CustomerID

-- Find all books that have never been ordered. 
insert into Books values(6,'none bought',2,'2025-03-03',800.00)
select Title from Books b left join OrderItems o on b.BookID = o.BookID where o.BookID is null

-- Retrieve the total number of orders placed by each customer. 
insert into Orders values(7,5,'2025-03-03',99)
select c.Name, Count(OrderID) as total_orders from Customers c join Orders o on c.CustomerID=o.CustomerID GROUP BY c.Name

-- Find the books ordered along with the quantity for each order.
select Title,Quantity from Books b join OrderItems o on o.BookID=b.BookID 

select * from Orders
select * from Customers
-- Display all customers, even those who haven’t placed any orders.
INSERT INTO Customers VALUES (6,'Rahul', 'rahul@gmail.com', 9898989878)
select * from Customers c left join Orders  o on c.CustomerID=o.CustomerID


select * from Authors
select * from Books
-- Find authors who have not written any books
insert into Authors values(6,'OM','India')
select Name ,Title from Books b right join Authors a on a.AuthorID=b.AuthorID where b.Title is null


--SubQueries

-- Find the customer(s) who placed the first order (earliest OrderDate).
select c.CustomerID ,c.Name , o.OrderDate from Customers c join Orders o on c.CustomerID=o.CustomerID where o.OrderID=(select Top 1 OrderID from Orders order by OrderDate asc)

-- Find the customer(s) who placed the most orders. 
select distinct (o.CustomerID), c.Name from Orders o JOIN Customers c ON c.CustomerID = o.CustomerID where o.CustomerID =(select top 1 CustomerID from orders group by CustomerID order by count(CustomerID)desc)

select * from Customers
select * from Orders
-- Find customers who have not placed any orders 

insert into Customers values(8,'shreekant','shree@gmail.com',628272372)
select c.CustomerID , c.Name from Customers c where c.CustomerID NOT IN (select o.CustomerID from Orders o)

select * from customers where CustomerID not in(select CustomerID from Orders where CustomerID is not null)

select * from customers c where not exists(select 1 from orders o where c.CustomerID=o.CustomerID)



