USE RandomTestData --заменить на имя своей базы данных.
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TEST_AUTHORS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NOT NULL,
	CONSTRAINT [PK_TEST_AUTHORS] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

INSERT INTO [dbo].[TEST_AUTHORS] ([FirstName], [LastName]) VALUES
('Marcin','Szeliga'),
('Juwal', 'Lowy'),
('Robert C.', 'Martin'),
('Wouter', 'de Kort');

CREATE TABLE [dbo].[TEST_BOOKS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[AuthorId] [int] NOT NULL,
	CONSTRAINT [PK_TEST_BOOKS] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TEST_BOOKS]
ADD CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId)
REFERENCES [dbo].[TEST_AUTHORS] (Id)
ON DELETE CASCADE
ON UPDATE CASCADE;

INSERT INTO [dbo].[TEST_BOOKS] ([Name], [AuthorId]) VALUES
('Data Science I uczenie maszynowe',	1),
('Praktyczne uczenie maszynowe',	1),
('Programming WCF Services',	2),
('Czysty kod - podręcznik dobrego programisty',	3),
('Agile Software Development, Principles, Patterns, and Practices',	3),
('Clean Agile: Back to Basics',	3),
('Programming in C# ExamRef 70-483',	4);
