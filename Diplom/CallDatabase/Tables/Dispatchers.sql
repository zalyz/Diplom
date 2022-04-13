CREATE TABLE [dbo].[Dispatchers]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [Name] VARCHAR(200) NOT NULL, 
    [Surname] VARCHAR(200) NOT NULL, 
    [MiddleName] VARCHAR(200) NOT NULL
)
