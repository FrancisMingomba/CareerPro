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
	[Zip] NVARCHAR(5) NOT NULL,
	[EmailAddress] NVARCHAR(100) NOT NULL,
	[Username] NVARCHAR(20) NOT NULL,
	[Active] BIT
)
GO

print ' ' print 'Creating Job Positions'
GO
Create table Jobs
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL
)
GO

SET IDENTITY_INSERT [dbo].[Jobs] ON
INSERT INTO [dbo].[Jobs] ([Id], [Name], [Description]) VALUES (1, N'C# UI Programmer', N'Programs in C#. Needs to be vigilant')
INSERT INTO [dbo].[Jobs] ([Id], [Name], [Description]) VALUES (2, N'Java Programmer', N'Programs in Java. Needs to be vigilant even more. ')
INSERT INTO [dbo].[Jobs] ([Id], [Name], [Description]) VALUES (3, N'Python Programmer', N'Needs to be able to kill pythons')
INSERT INTO [dbo].[Jobs] ([Id], [Name], [Description]) VALUES (4, N'Sharepoint Developer', N'Develops sharepoint solutions for corporations')
SET IDENTITY_INSERT [dbo].[Jobs] OFF

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
	[Id]			INT NOT NULL PRIMARY KEY IDENTITY,
	[QuestionId]	INT,
	[ApplicantId]	INT,
	[JobId]			INT,
	[Answer]		NVARCHAR(200)
)

print '' print '*** ApplicantRespone /Applicant Foreign Key Constraint'
GO	
ALTER TABLE [dbo].[ApplicantResponse]  WITH NOCHECK 
	ADD CONSTRAINT [fk_ApplicantID] FOREIGN KEY([ApplicantId])
	REFERENCES [dbo].[Applicants] ([Id])
	ON UPDATE CASCADE
GO	

print '' print '*** ApplicantRespone /Question Foreign Key Constraint'
GO	
ALTER TABLE [dbo].[ApplicantResponse]  WITH NOCHECK 
	ADD CONSTRAINT [fk_QuestionId] FOREIGN KEY([QuestionId])
	REFERENCES [dbo].[Questions] ([Id])
	ON UPDATE CASCADE
GO

print '' print '*** ApplicantRespone /Job Foreign Key Constraint'
GO	
ALTER TABLE [dbo].[ApplicantResponse]  WITH NOCHECK 
	ADD CONSTRAINT [fk_JobPositionId] FOREIGN KEY([JobId])
	REFERENCES [dbo].[Jobs] ([Id])
	ON UPDATE CASCADE
GO

print '' print '*** Creating sp_retrieve_questions'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_questions]
AS
	BEGIN
		SELECT Id, QxnString
		FROM Questions
	END
GO

print '' print '*** Creating sp_retrieve_jobs'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_jobs]
AS
	BEGIN
		SELECT Id, Name, Description
		FROM Jobs
	END
GO

print '' print '*** Creating sp_insert_response'
GO
CREATE PROCEDURE [dbo].[sp_insert_response]
	(
		@QuestionId		[INT],
		@ApplicantId	[INT],
		@JobId			[INT],
		@Answer			NVARCHAR(200)
	)
AS
	BEGIN
		INSERT INTO [dbo].[ApplicantResponse]
			([QuestionId], [ApplicantId], [JobId], [Answer])
		VALUES
			(@QuestionId, @ApplicantId, @JobId, @Answer)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_insert_applicant'
GO
CREATE PROCEDURE [dbo].[sp_insert_applicant]
	(
		@FirstName		NVARCHAR(100),
		@LastName		NVARCHAR(100),
		@Phone			NVARCHAR(100),
		@AddressLine1	NVARCHAR(100),
		@AddressLine2	NVARCHAR(100),
		@City			NVARCHAR(100),
		@State			NVARCHAR(2),
		@Zip			NVARCHAR(5),
		@EmailAddress	NVARCHAR(100),
		@UserName		NVARCHAR(20),
		@Active			bit

	)
AS
	BEGIN
		INSERT INTO [dbo].[Applicants]
			([FirstName], [LastName], [Phone], [AddressLine1], 
			[AddressLine2], [City], [State], [Zip], [EmailAddress], [Username], [Active] )
		VALUES
			(	
				@FirstName,	
				@LastName,		
				@Phone,			
				@AddressLine1,	
				@AddressLine2,
				@City,			
				@State,			
				@Zip,			
				@EmailAddress,	
				@UserName,		
				@Active
			)				
		RETURN @@ROWCOUNT
	END
GO

SET IDENTITY_INSERT [dbo].[Applicants] ON
INSERT INTO [dbo].[Applicants] ([Id], [FirstName], [LastName], [Phone], [AddressLine1], [AddressLine2], [City], [State], [Zip], [EmailAddress], [Username], [Active]) VALUES (1, N'Francis', N'Mingomba', N'3192222222', N'11 Oak Dr', N'St5', N'Iowa City', N'IA', N'52333', N'mingomba@gmail.com', N'fmingomba', 1)
SET IDENTITY_INSERT [dbo].[Applicants] OFF

print '' print '*** Creating sp_retrieve_applicants'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_applicants]
AS
	BEGIN
		SELECT Id, FirstName, LastName, Phone, AddressLine1, AddressLine2, City, State, Zip, EmailAddress, Username, Active
		FROM Applicants
	END
GO

print '' print '*** Creating sp_retrieve_applicant_response'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_applicant_response]
AS
	BEGIN
		SELECT QuestionId, ApplicantId, JobId, Answer
		FROM ApplicantResponse
	END
GO





