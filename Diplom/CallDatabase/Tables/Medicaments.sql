CREATE TABLE [dbo].[Medicaments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Dosage] VARCHAR(150) NOT NULL
)
