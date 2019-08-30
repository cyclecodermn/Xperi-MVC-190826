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

-- Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ToDoGetAll')
      DROP PROCEDURE ToDoGetAll
GO

CREATE PROCEDURE ToDoGetAll
AS
	SELECT * FROM ToDoTableTable
	ORDER BY Id
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ToDoGetById')
      DROP PROCEDURE ToDoGetById
GO

CREATE PROCEDURE ToDoGetById (
	@Id int
)
AS
	SELECT *
	FROM ToDoTable
	WHERE Id = @Id
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ToDoInsert')
      DROP PROCEDURE ToDoInsert
GO

CREATE PROCEDURE ToDoInsert (
	@Id int output,
	@Name Varchar(50),
	@Completed bit,
	@Note nvarchar(100)
)
AS
	INSERT INTO ToDo (Name, Completed, Note)
	VALUES (@Name, @Completed, @Note)

	SET @Id = SCOPE_IDENTITY()
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ToDoUpdate')
      DROP PROCEDURE ToDoUpdate
GO

CREATE PROCEDURE ToDoUpdate (
	@Name Varchar(50),
	@Id int,
	@Completed bit,
	@Note nvarchar(100)
)
AS
	UPDATE ToDo
		SET Completed = @Completed,
		Note = @Note,
		Name = @Name
	WHERE Id = @Id
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ToDoDelete')
      DROP PROCEDURE ToDoDelete
GO

CREATE PROCEDURE ToDoDelete (
	@Id int
)
AS
	DELETE FROM ToDoTable
	WHERE Id = @Id
GO

-- Sample Data

SET IDENTITY_INSERT ToDoTable ON

INSERT INTO ToDoTable (Id, Name, Note, Completed)
VALUES (0, '(SQL Repo0) Go for a bike ride near home.', 'This is a note for task 0.', 0),
	(1, '(SQL Repo1) Go for a bike ride far from home.', 'This is a note for task 1.', 0),
	(2, '(SQL Repo2) Oil bike chain', 'This is a note for task 0.', 1)
SET IDENTITY_INSERT ToDoTable OFF


