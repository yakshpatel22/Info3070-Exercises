﻿-- create new database file in VS2017 Server Explorer
-- before proceeding
-- Data Connections -->Add Connection

-- uncomment these lines if you need to reset data
/*
DROP TABLE Problems
GO
DROP TABLE Employees
GO
DROP TABLE Departments
GO
*/

-- Problem Table with Constraints
CREATE TABLE Problems
( Id INT IDENTITY(1,1) NOT NULL,
  Description VARCHAR(50),
  Timer ROWVERSION,
  CONSTRAINT PK_Problem PRIMARY KEY(Id)  
)
GO

-- Let's load problem with some data (identity means we don't load id)
INSERT INTO Problems (Description) VALUES ('Device Not Plugged In')
INSERT INTO Problems (Description) VALUES ('Device Not Turned On')
INSERT INTO Problems (Description) VALUES ('Hard Drive Failure')
INSERT INTO Problems (Description) VALUES ('Memory Failure')
INSERT INTO Problems (Description) VALUES ('Power Supply Failure')
INSERT INTO Problems (Description) VALUES ('Password fails due to Caps Lock being on')
INSERT INTO Problems (Description) VALUES ('Network Card Faulty')
INSERT INTO Problems (Description) VALUES ('Cpu Fan Failure')
INSERT INTO Problems (Description) VALUES ('Memory Upgrade')
INSERT INTO Problems (Description) VALUES ('Graphics Upgrade')
INSERT INTO Problems (Description) VALUES ('Needs software upgrade')
GO

-- Department Table with Constraints
CREATE TABLE Departments
( Id INT IDENTITY(100,100) NOT NULL,
  DepartmentName VARCHAR(50),
  Timer ROWVERSION,
  CONSTRAINT PK_Department PRIMARY KEY(Id)  
)
GO

-- add the department data
INSERT INTO Departments (DepartmentName) VALUES ('Administration')
INSERT INTO Departments (DepartmentName) VALUES ('Sales')
INSERT INTO Departments (DepartmentName) VALUES ('Food Services')
INSERT INTO Departments (DepartmentName) VALUES ('Lab')
INSERT INTO Departments (DepartmentName) VALUES ('Maintenance')
GO

-- Employees Table with Constraints
CREATE TABLE Employees
( Id INT IDENTITY(1,1) NOT NULL,
  Title VARCHAR(4),
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  PhoneNo VARCHAR(25),
  Email VARCHAR(50),
  DepartmentId INT NOT NULL,
  IsTech BIT NULL,
  StaffPicture VARBINARY(MAX) NULL,
  Timer ROWVERSION,
  CONSTRAINT PK_Employee PRIMARY KEY(Id),
  CONSTRAINT FK_EmployeeInDept FOREIGN KEY(DepartmentId) REFERENCES Departments(Id)
)
GO

-- add initial data, we'll add staff pics later
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Bigshot','Smartypants','(555) 555-5551','bs@abc.com',100)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mrs.','Penny','Pincher','(555) 555-5551','pp@abc.com',100)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Smoke','Andmirrors','(555) 555-5552','sa@abc.com',200)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Sam','Slick','(555) 555-5552','ng@abc.com',200)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Sloppy','Joe','(555) 555-5553','sj@abc.com',300)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Franken','Beans','(555) 555-5553','wc@abc.com',300)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId,IsTech) VALUES ('Mr.','Bunsen','Burner','(555) 555-5554','sc@abc.com',400,1)
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId,IsTech) VALUES ('Ms.','Petrie','Dish','(555) 555-5554','td@abc.com',400,1) 
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Ms.','Mopn','Glow','(555) 555-5555','td@abc.com',500) 
INSERT INTO Employees (Title,FirstName,LastName,PhoneNo,Email,DepartmentId) VALUES ('Mr.','Spickn','Span','(555) 555-5555','td@abc.com',500) 
GO

SELECT COUNT(*) AS Problems FROM Problems
GO
SELECT COUNT(*) Departments FROM Departments
GO
SELECT COUNT(*) AS Employees FROM Employees
GO
SELECT * FROM Students;