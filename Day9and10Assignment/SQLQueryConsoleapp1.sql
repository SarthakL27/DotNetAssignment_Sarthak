create database NeoPolicy;

create table Users(
CustomerID int PRIMARY KEY,
CustomerName VARCHAR(50),
CustPassword VARCHAR(50)
);



alter table Users alter column CustomerID int identity ;

select * from users;

create table Policies(
PolicyID int PRIMARY KEY IDENTITY,
PolicyHolderName VARCHAR(50),
CustomerID int foreign key references Users(CustomerID),
PolicyType Int not null,
StartDate date,
EndDate date);

select * from Policies;



