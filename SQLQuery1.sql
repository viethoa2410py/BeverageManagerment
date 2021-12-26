CREATE DATABASE BEVERAGEMANAGERMENT
GO

USE BEVERAGEMANAGERMENT
GO
CREATE TABLE UNIT
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName nvarchar(max)
)
GO

CREATE TABLE SUPLIER
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	Contractdate DateTime
)
GO

CREATE TABLE CUSTOMER
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	Contractdate DateTime
)
GO

CREATE TABLE OBJECTS
(
	Id nvarchar(128) PRIMARY KEY,
	Displayname nvarchar(max),
	IdUnit int not null,
	IdSuplier int not null,
	QRCode nvarchar(max),
	BarCode nvarchar(max)

	FOREIGN KEY (IdUnit) REFERENCES UNIT(ID),
	FOREIGN KEY (IdSuplier) REFERENCES SUPLIER(ID),
)
GO

CREATE TABLE USERROLE
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName NVARCHAR(100),
)
GO

INSERT INTO USERROLE(DisplayName) VALUES (N'ADMIN')
GO
INSERT INTO USERROLE(DisplayName) VALUES (N'STAFF')
GO
CREATE TABLE USERINFO
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdRole INT NOT NULL,
	Username NVARCHAR(200),
	Userpassword NVARCHAR(MAX),

	FOREIGN KEY (IdRole) REFERENCES USERROLE(Id),
)
GO
INSERT INTO USERINFO(Username,Userpassword,IdRole) VALUES (N'admin',N'db69fc039dcbd2962cb4d28f5891aae1',1)
GO
INSERT INTO USERINFO(Username,Userpassword,IdRole) VALUES (N'staff',N'978aae9bb6bee8fb75de3e4830a1be46',2)
GO

Create table Input
(
	Id nvarchar(128) primary key,
	DateInput DateTime
)
go

Create table InputInfo
(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdInput nvarchar(128) not null,
	Counts int,
	InputPrice float default 0,
	OutputPrice float default 0,
	Status nvarchar(max)

	foreign key (IdObject) references OBJECTS(Id),
	foreign key (IdInput) references Input(Id),
)
go

Create table Output
(
	Id nvarchar(128) primary key,
	DateOutput DateTime
)
go

Create table OutputInto
(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdInputInfo nvarchar(128) not null,
	IdCustomer int not null,
	Counts int,
	Status nvarchar(max)

	foreign key (IdObject) references OBJECTS(Id),
	foreign key (IdInputInfo) references InputInfo(Id),
	foreign key (IdCustomer) references CUSTOMER(Id),
)
go