USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='ToDoXperi')
DROP DATABASE ToDoXperi
GO

CREATE DATABASE ToDoXperi
GO

USE ToDoXperi
GO

-- Tables
IF EXISTS(SELECT * FROM sys.tables WHERE name='ToDoTable')
	DROP TABLE ToDoTable
GO

CREATE TABLE ToDoTable (
	Id int identity(1,1) primary key not null,
	Name nvarchar(50) not null,
	Completed bit,
	Note nvarchar(100)
)
