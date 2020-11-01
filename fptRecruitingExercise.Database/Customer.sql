CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] nvarchar(max) NULL,
	[Phone] nvarchar(max) NULL,
	[Email] nvarchar(max) NULL,
	[Notes] nvarchar(max) NULL
)
