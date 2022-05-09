CREATE TABLE [dbo].[Dispatchers]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [Name] nVARCHAR(200) NOT NULL, 
    [Surname] nVARCHAR(200) NOT NULL, 
    [MiddleName] nVARCHAR(200) NOT NULL
)
