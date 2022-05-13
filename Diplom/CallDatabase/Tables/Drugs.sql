CREATE TABLE [dbo].[Drugs]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1),
	[Name] nVARCHAR(MAX) NOT NULL, 
    [Dosage] NVARCHAR(200) NOT NULL,
)
