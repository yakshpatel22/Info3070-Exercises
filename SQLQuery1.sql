﻿-- create new database file in VS2017 Server Explorer
-- before proceeding
-- Data Connections -->Add Connection

-- uncomment these lines if you need to reset data
/*
DROP TABLE Students
GO
DROP TABLE Divisions
GO
*/
-- Division Table with Constraints
CREATE TABLE Divisions
( Id INT IDENTITY(10,10) NOT NULL,
  Name VARCHAR(50),
  Timer ROWVERSION,
  CONSTRAINT PK_Division PRIMARY KEY(Id)  
)
GO

-- add the division data
INSERT INTO Divisions (Name) VALUES ('Information Technology')
INSERT INTO Divisions (Name) VALUES ('Hospitality')
INSERT INTO Divisions (Name) VALUES ('Business')
INSERT INTO Divisions (Name) VALUES ('Manufacturing Technology')
INSERT INTO Divisions (Name) VALUES ('Design')
GO

-- Students Table with Constraints
CREATE TABLE Students
( Id INT IDENTITY(1,1) NOT NULL,
  Title VARCHAR(4),
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  PhoneNo VARCHAR(25),
  Email VARCHAR(50),
  DivisionId INT NOT NULL,
  Picture VARBINARY(MAX) NULL,
  Timer ROWVERSION,
  CONSTRAINT PK_Student PRIMARY KEY(Id),
  CONSTRAINT FK_StudentInDiv FOREIGN KEY(DivisionId) REFERENCES Divisions(Id)
)
GO

-- add initial data, we'll add student pics later
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Brown','Nose','(555) 555-5551','bn@someschool.com',10)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mrs.','Teachers','Pet','(555) 555-5551','tp@someschool.com',10)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Total','Slacker','(555) 555-5552','ts@someschool.com',20)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Ab','Sent','(555) 555-5552','as@someschool.com',20)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Brain','Iac','(555) 555-5553','bi@someschool.com',30)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Plag','Iarism','(555) 555-5553','pi@someschool.com',30)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Always','Answers','(555) 555-5554','aa@someschook.com',40)
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Ms.','Tru','Ant','(555) 555-5554','ta@someschool.com',40) 
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Ms.','High','Gpa','(555) 555-5555','hg@someschool.com',50) 
INSERT INTO Students (Title,FirstName,LastName,PhoneNo,Email,DivisionId) VALUES ('Mr.','Know','Itall','(555) 555-5555','ki@someschool.com',50) 
GO

SELECT COUNT(*) AS Divisions FROM Divisions
GO
SELECT COUNT(*) AS Students FROM Students
GO
SELECT * FROM Students
GO