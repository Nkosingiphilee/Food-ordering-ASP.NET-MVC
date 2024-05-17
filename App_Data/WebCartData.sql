create database onlineshop
use onlineshop ;

create table Category(
CategoryId int not null identity(1,1) primary key,
CategoryCode char(5) not null,
CategoryName varchar(20) not null 
);
insert into Category values('no2','mobile'),('no3','Computer'),('no3','laptop'),('no4','Desktop');

create table Item(
ItemId int identity(1,1) not null primary key,
CategoryId int not null foreign key references Category,
ItemName varchar(20) not null,
Description varchar(30) not null,
ImagePath varchar(30) not null,
ItemPtice decimal(10,2) not null
);
insert into Item values(1,'computer','not','ifoni.png',67780.21);

create table Orders(
OrderId int not null identity(1,1) primary key,
OrderDate datetime not null,
OrderNumber varchar(20) not null 
);

create table OrderDetail(
OrderDetailId int identity(1,1) not null primary key ,
OrderId int not null foreign key references Orders,
ItemId int not null foreign key references Item,
Quantity int not null default(1),
UnitPrice decimal(10,2), 
Total decimal(10,2) 

);


select * from Orders
select * from OrderDetail
select * from Category
select * from Item