IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'CareerProDB')
BEGIN
  Print '' print  ' *** dropping database CareerProDB'
  DROP DATABASE CareerProDB
End
GO
print '' print '*** creating database CareerProDB'
GO
CREATE DATABASE CareerProDB
GO

print '' print '*** using database CareerProDB'
GO
USE [CareerProDB]
GO

print ' ' print 'Creating Applicants Table'
GO 
Create table Applicants
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[Phone] NVARCHAR(100) NOT NULL,
	[AddressLine1] NVARCHAR(100) NOT NULL,
	[AddressLine2] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(100) NOT NULL,
	[State] NVARCHAR(2) NOT NULL,
	[Zip] NVARCHAR(100) NOT NULL,
	[EmailAddress] NVARCHAR(100) NOT NULL,
	[Username] NVARCHAR(20) NOT NULL,
	[Active] BIT
)
GO

print ' ' print 'Creating Job Positions'
GO
Create table JobPositions
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL
)
GO

SET IDENTITY_INSERT [dbo].[JobPositions] ON
INSERT INTO [dbo].[JobPositions] ([Id], [Name], [Description]) VALUES (2, N'C# Programmer', N'Programs in C#. Needs to be vigilant')
INSERT INTO [dbo].[JobPositions] ([Id], [Name], [Description]) VALUES (3, N'Java Programmer', N'Programs in Java. Needs to be vigilant even more. ')
INSERT INTO [dbo].[JobPositions] ([Id], [Name], [Description]) VALUES (4, N'Python Programmer', N'Needs to be able to kill pythons')
INSERT INTO [dbo].[JobPositions] ([Id], [Name], [Description]) VALUES (5, N'Sharepoint Developer', N'Develops sharepoint solutions for corporations')
SET IDENTITY_INSERT [dbo].[JobPositions] OFF

print ' ' print 'Creating Questions Table'
GO
Create table Questions
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[QxnString] NVARCHAR(100)	NOT NULL,
)
GO

SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT INTO [dbo].[Questions] ([Id], [QxnString]) VALUES (1, N'When was the last time you programmed.')
INSERT INTO [dbo].[Questions] ([Id], [QxnString]) VALUES (2, N'How many years of programming experience do you have?')
INSERT INTO [dbo].[Questions] ([Id], [QxnString]) VALUES (3, N'Write a piece of code to sort these numbers {1,2,3,6,20,5,2,90}')
INSERT INTO [dbo].[Questions] ([Id], [QxnString]) VALUES (4, N'Where do you see yourself in 5 years?')
INSERT INTO [dbo].[Questions] ([Id], [QxnString]) VALUES (5, N'Mention an experience in which you worked with a team.')
SET IDENTITY_INSERT [dbo].[Questions] OFF

print ' ' print 'Applicant Responses'
GO
Create table ApplicantResponse
(
	[Id]	INT NOT NULL PRIMARY KEY IDENTITY,
	[QuestionId]	INT,
	[JobId]			INT,
	[Answer]		NVARCHAR(200)
)

print '' print '*** Creating sp_retrieve_questions'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_questions]
AS
	BEGIN
		SELECT Id, QxnString
		FROM Questions
	END
GO



